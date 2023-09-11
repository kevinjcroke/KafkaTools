const Kafka = require('node-rdkafka');
const request = require('request');

// process.argv[2] is the first command line argument
const env = process.argv[2] || 'local';

const environments = {
    'development': {
        topicPrefix: 'development',
        schemaRegistryUrl: 'https://schema-registry.kube.sslocal.com'
    },
    'staging': {
        topicPrefix: 'staging',
        schemaRegistryUrl: 'https://schema-registry.kube.sslocal.com'
    },
    'integration': {
        topicPrefix: 'integration',
        schemaRegistryUrl: 'https://schema-registry.kube.sslocal.com'
    },
    'production': {
        topicPrefix: 'production',
        schemaRegistryUrl: 'https://schema-registry.kube.sslocal.com'
    },
    'local': {
        topicPrefix: 'development',
        brokers: ['localhost:9092'],
        schemaRegistryUrl: 'http://localhost:8081'
    },
    // Add more environments here as needed...
};

if (!environments[env]) {
    console.error(`Unknown environment: ${env}`);
    process.exit(1);
}

const config = environments[env];

// Note: This tool is designed to create a topic and schema locally. For any other environment
//      only the schema will be created. To create topics remotely use http://kafka-manager.kube.sslocal.com/, click the cluster and then Topic>Create.
//      Make sure you use a replication factor of 3.
const topicsAndSchemas = [
    {
        topicSuffix: '_fulfillment_move_to_shipped_v1',
        schemas:
            [
                {
                    schemaSuffix: "_fulfillment_move_to_shipped_v1-value",
                    schema: {
                        type: 'record',
                        name: 'MovedToShipped',
                        fields: [
                            { name: 'TenantId', type: 'string' },
                            { name: 'ExternalId', type: 'string' }
                        ]
                    }
                },
                {
                    schemaSuffix: "_fulfillment_move_to_shipped_v1-key",
                    schema: { "type": "record", "name": "FulfillmentEventKey", "namespace": "SS.Business.KafkaEvents.Fulfillments", "fields": [{ "name": "EnvironmentType", "type": "string" }, { "name": "FulfillmentId", "type": "string" }, { "name": "FulfillmentType", "type": { "type": "enum", "name": "FulfillmentType", "symbols": ["Unknown", "Label", "External"] } }, { "name": "PartitionId", "type": "string" }] }
                }
            ]
    },
    // Add more topics and schemas here...
];

// Create Topics
// If brokers are defined then create the topics
if (config.brokers && config.brokers.length > 0) {
    const adminClient = Kafka.AdminClient.create({
        'metadata.broker.list': config.brokers.join(',')
    });

    topicsAndSchemas.forEach((item) => {
        const topicName = `${config.topicPrefix}${item.topicSuffix}`;

        adminClient.createTopic({
            topic: topicName,
            num_partitions: 3,
            replication_factor: 1
        }, (err) => {
            if (err) {
                console.error('Failed to create topic', err);
            } else {
                console.log(`Topic ${topicName} created successfully`);
            }
        });
    });
}

// Register Schemas
topicsAndSchemas.forEach((item) => {
    item.schemas.forEach((schemaDefinition) => {
        const schemaName = `${config.topicPrefix}${schemaDefinition.schemaSuffix}`;
        console.log(schemaName);
        const body = { schema: JSON.stringify(schemaDefinition.schema) };

        // Register Schema
        request.post({
            url: `${config.schemaRegistryUrl}/subjects/${schemaName}/versions`,
            body,
            json: true
        }, (err, res, body) => {
            if (err) {
                console.error('Failed to register schema', err);
            } else {
                console.log(`Schema ${schemaName} registered successfully with ID ${body.id}`);
            }
        });
    });
});