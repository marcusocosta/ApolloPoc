const conf = require('nconf');

conf.argv()
  .env()
  .defaults(
    {
      PORT : 5000
    }
  );

export default conf;