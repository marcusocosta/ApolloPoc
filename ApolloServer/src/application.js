const morgan = require('morgan');
const commons = require('./commons');
const server = require('./apollo.server');

module.exports = async (app) => {
  const apolloServer = await server();

  app.use(morgan(':method :url :response-time :status', { stream: commons.logger.stream }));

  app.get('/health', (req, res) => {
    res.status(200);
    res.send();
  });

  apolloServer.applyMiddleware({ app, path: commons.conf.get('ROOT_PATH') });
};
