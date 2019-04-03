import express from 'express';
import { ApolloServer, gql } from 'apollo-server-express';
import schemas from './schemas';
import commons from './lib/commons';
import {
  makeExecutableSchema,
  addMockFunctionsToSchema,
  mergeSchemas,
} from 'graphql-tools';

(async () => {
  const port = commons.conf.get('PORT');

  var schemaPreco = await schemas.precoSchema();
  var schemaProduto = await schemas.produtoSchema();

  const server = new ApolloServer({
    schema: mergeSchemas({
      schemas: [
        schemaPreco,
        schemaProduto,
      ],
    })
  });

  const app = express();
  server.applyMiddleware({ app });

  app.listen(port, () => {
    console.log(`Server listening on port ${port}`);
  });
})();

