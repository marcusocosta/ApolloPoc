const { makeRemoteExecutableSchema, introspectSchema } = require('graphql-tools');
const { HttpLink } = require('apollo-link-http');
const fetch = require('node-fetch');
const commons = require('../commons');

const getUrls = () => Object.keys(commons.conf.get())
  .filter(name => new RegExp('_INTROSPECT_URL').test(name))
  .map(name => commons.conf.get(name));

const urls = getUrls()
  .map(link => new HttpLink({ uri: `${link}${commons.conf.get('PATH_GRAPHQL')}`, fetch }));

const createExecutableSchema = async (link) => {
  const schema = await introspectSchema(link);

  return makeRemoteExecutableSchema({
    schema,
    link,
  });
};

module.exports = async () => Promise.all(urls.map(link => createExecutableSchema(link)));
