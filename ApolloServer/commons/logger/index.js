const { createLogger, format, transports } = require('winston');
const colorizer = format.colorize();

const logger = createLogger({
  level: 'debug',
  format: format.combine(
    format.timestamp(),
    format.simple(),
    format.printf(msg =>
      colorizer.colorize(msg.level, `${msg.timestamp} - ${msg.level}: ${msg.message}`)
    )
  ),
  transports: [
    new transports.Console(),
  ]
});

logger.stream = {
  write: function(message, encoding){
      logger.info(message);
  }
};

module.exports = logger;