import { GraphQLDataSource } from 'apollo-datasource-graphql';
import { gql } from 'apollo-server-express';

const typeDefs = gql`
  query {
    precos {
      codigoProduto,
      valor,
      data
    }
  }
`;

export class PrecosGraphQLAPI extends GraphQLDataSource {
  constructor() {
    super();
    this.baseURL = 'http://localhost:5000/graphql';
  }

  async getAllPrecos(codigoProduto) {
    try {    
      const response = await this.query(typeDefs, {
        variables: {
          codigoProduto,
        },
      });
      return response.data.precos;
    } catch (error) {
      console.error(error);
    }
  }
}