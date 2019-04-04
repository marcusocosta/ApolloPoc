const { ApolloServer } = require('apollo-server-express');
const { mergeSchemas } = require('graphql-tools');
const schemas = require('./schemas/introspect.schemas');
const commons = require('./commons');

module.exports = async () => {
  return new ApolloServer({
    schema: mergeSchemas({
      schemas: await schemas(),
    }),
    formatError: error => {
      commons.logger.error(error);
      return error;
    },
  });
}