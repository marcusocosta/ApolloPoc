const express = require('express');
var morgan = require('morgan')
var uuid = require('node-uuid');
const { ApolloServer } = require('apollo-server-express');
const { mergeSchemas } = require('graphql-tools');
const schemas = require('./schemas/introspect.schemas');
const commons = require('./commons');

(async () => {
  const port = commons.conf.get('PORT');

  const server = new ApolloServer({
    schema: mergeSchemas({
      schemas: await schemas(),
    }),
    formatError: error => {
      commons.logger.error(error);
      return error;
    },
    formatResponse: response => {
      return response;
    },
  });

  morgan.token('id', function getId(req) {
    return req.id
  });

  const app = express();

  app.use(assignId);
  app.use(morgan(':id :method :url :response-time :status', { stream: commons.logger.stream }));

  server.applyMiddleware({ app, path: commons.conf.get('ROOT_PATH') });

  app.listen(port, () => {
    commons.logger.info(`Server listening on port ${port}`);
  });
})();

const assignId = (req, res, next) => {
  req.id = uuid.v4();
  next();
};