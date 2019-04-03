const express = require('express');
const { ApolloServer } = require('apollo-server-express');
const schemas = require('./schemas/introspect.schemas');
const commons = require('./commons');
const { mergeSchemas } = require('graphql-tools');

(async () => {
  const port = commons.conf.get('PORT');

  const server = new ApolloServer({
    schema: mergeSchemas({
      schemas: await schemas(),
    })
  });

  const app = express();
  server.applyMiddleware({ app });

  app.listen(port, () => {
    console.log(`Server listening on port ${port}`);
  });
})();

