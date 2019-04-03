const conf = require('nconf');

conf.argv()
  .env()
  .defaults(
    {
      PORT : 5000,
      LINKS : [
        'http://localhost:8005/graphql',
        'http://localhost:8006/graphql'
      ]
    }
  );

export default conf;