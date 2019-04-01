import { ApolloServer, gql } from 'apollo-server';
import { ProdutoGraphQLAPI } from './ProdutoDataSource';
import { PrecosGraphQLAPI } from './PrecosDataSource';
import { PrecoGraphQLAPI } from './PrecoDataSource';


const typeDefs = gql`
  type Produto {
    codigo: Int!
    nome: String!
    codigoBarras: String!
    precos: [Preco]
  }
  type Preco {
    codigoProduto: Int!
    valor: Float!
    data: String!
  }
  type Query {
    produtos: [Produto],
    preco(codigoProduto: Int): Preco,
    precos: [Preco],
  }
`;

const resolvers = {
  Query: {
    produtos: (root, args, { dataSources }) => dataSources.produtoGraphQLAPI.getAllProdutos(),
    precos: (root, args, { dataSources }) => dataSources.precosGraphQLAPI.getAllPrecos(),
    preco: (root, args, { dataSources }) => dataSources.precoGraphQLAPI.getAllPrecoPorCodigoProduto(args.codigoProduto),
  
  },
};

const server = new ApolloServer({
  typeDefs,
  resolvers,
  dataSources: () => ({
    produtoGraphQLAPI: new ProdutoGraphQLAPI(),
    precosGraphQLAPI: new PrecosGraphQLAPI(),
    precoGraphQLAPI: new PrecoGraphQLAPI(),
  }),
});

server.listen().then(({ url }) => {
  console.log(`🚀 Server ready at ${url}`);
});