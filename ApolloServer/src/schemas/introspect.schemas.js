const { makeRemoteExecutableSchema, introspectSchema } = require('graphql-tools');
const { HttpLink } = require('apollo-link-http');
const fetch = require('node-fetch');
const commons = require('../commons');

const links = commons.conf.get('LINKS')
  .map(link => new HttpLink({ uri: `${link}${commons.conf.get('PATH_GRAPHQL')}`, fetch }));

const createExecutableSchema = async (link) => {
  const schema = await introspectSchema(link);

  return makeRemoteExecutableSchema({
    schema,
    link,
  });
};

module.exports = async () => Promise.all(links.map(link => createExecutableSchema(link)));