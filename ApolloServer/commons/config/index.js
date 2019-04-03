const conf = require('nconf');
const LINKS = [];

conf.argv()
  .env({
    transform: function(obj) {
      if ((new RegExp('_INTROSPECT_URL')).test(obj.key)) {
        LINKS.push(obj.value);
      }
      return obj;
    }
  })
  .defaults(
    {
      PORT : 5000,
      PRECO_INTROSPECT_URL:'http://localhost:8005',
      PRODUTO_INTROSPECT_URL:'http://localhost:8006',
      LINKS,
      PATH_GRAPHQL: '/graphql'
    }
  );

  console.log('Graphql urls: ', LINKS);

module.exports = conf;