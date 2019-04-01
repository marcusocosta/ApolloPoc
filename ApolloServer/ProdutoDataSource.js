import { GraphQLDataSource } from 'apollo-datasource-graphql';
import { gql } from 'apollo-server-express';

const typeDefs = gql`
  query {
    produtos {
      codigo,
      nome,
      codigoBarras
    }
    produto(codigo: $codigo) {
      codigo,
      nome,
      codigoBarras
    }
  }
`;

export class ProdutoGraphQLAPI extends GraphQLDataSource {
  constructor() {
    super();
    this.baseURL = 'http://localhost:8006/graphql';
  }

  async getAllProdutos() {
    try {
      const response = await this.query(typeDefs);
      console.log(response.data);
      return response.data.produtos;
    } catch (error) {
      console.error(error);
    }
  }
}