import express from 'express';
import { ApolloServer, gql } from 'apollo-server-express';
import schemas from './schemas/introspect.schemas';
import commons from './lib/commons';
import { mergeSchemas } from 'graphql-tools';

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

