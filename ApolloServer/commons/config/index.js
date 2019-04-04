const conf = require('nconf');
const logger = require('../logger');
const LINKS = [];

conf.argv()
  .env({
    transform: function(obj) {
      if ((new RegExp('_INTROSPECT_URL')).test(obj.key)) {
        logger.info(`Variável: ${obj.key} url: ${obj.value}`);
        LINKS.push(obj.value);
      }
      return obj;
    }
  })
  .defaults(
    {
      PORT : 5005,
      PRECO_INTROSPECT_URL:'http://localhost:8005',
      PRODUTO_INTROSPECT_URL:'http://localhost:8006',
      LINKS,
      PATH_GRAPHQL: '/graphql',
      ROOT_PATH: '/apollo'
    }
  );

module.exports = conf;