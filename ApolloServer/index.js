const express = require('express');
const commons = require('./commons');
const application = require('./application');

const app = express();
const port = commons.conf.get('PORT');
application(app)
  .then(() => {
    app.listen(port, () => {
      commons.logger.info(`Server listening on port ${port}`);
    });
  }).catch(error => {
    commons.logger.error(`Startup application error: ${error}`);
  });
