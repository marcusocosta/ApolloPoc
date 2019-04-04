const morgan = require('morgan');
const uuid = require('node-uuid');
const commons = require('./commons');
const server = require('./apollo.server');

module.exports = async (app) => {
    const apolloServer = await server();

    morgan.token('id', function getId(req) {
        return req.id
    });

    app.use(assignId);
    app.use(morgan(':id :method :url :response-time :status', { stream: commons.logger.stream }));

    app.get('/health', function (req, res) {
        res.status(200);
        res.send();
    });

    apolloServer.applyMiddleware({ app, path: commons.conf.get('ROOT_PATH') });
};

const assignId = (req, res, next) => {
    req.id = uuid.v4();
    next();
};