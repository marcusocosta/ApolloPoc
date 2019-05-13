const nconf = require('nconf');

nconf.argv()
  .env()
  .defaults({
    PORT: 5005,
    PRECO_INTROSPECT_URL: 'http://localhost:8005',
    PRODUTO_INTROSPECT_URL: 'http://localhost:8006',
    PATH_GRAPHQL: '/graphql',
    ROOT_PATH: '/apollo',
  });

module.exports = nconf;
