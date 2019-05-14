const { ApolloServer } = require('apollo-server-express');
const { mergeSchemas } = require('graphql-tools');
const schemas = require('./schemas/introspect.schemas');

module.exports = async () => new ApolloServer({
  schema: mergeSchemas({
    schemas: await schemas(),
  }),
  formatError: error => error,
});
