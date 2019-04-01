import { GraphQLDataSource } from 'apollo-datasource-graphql';
import { gql } from 'apollo-server-express';

const typeDefs = gql`
  query {
    preco(codigoProduto: Int) {
      codigoProduto,
      valor,
      data
    }
  }
`;

export class PrecoGraphQLAPI extends GraphQLDataSource {
  constructor() {
    super();
    this.baseURL = 'http://localhost:5000/graphql';
  }

  async getAllPrecoPorCodigoProduto(codigoProduto) {
    try {  
      console.log('-----> ', codigoProduto);  
      const response = await this.query(typeDefs);
      return response.data.precos;
    } catch (error) {
      console.error(error);
    }
  }
}