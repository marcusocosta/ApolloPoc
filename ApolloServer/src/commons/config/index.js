const nconf = require('nconf');

nconf.argv()
  .env()
  .file({ file: 'config.json' })
  .defaults({
    PORT: 5005,
    PATH_GRAPHQL: '/graphql',
    ROOT_PATH: '/apollo',
    INTROSPECT_URL_PATH: '_INTROSPECT_URL',
  });

module.exports = nconf;
