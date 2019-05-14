const { makeRemoteExecutableSchema, introspectSchema } = require('graphql-tools');
const { HttpLink } = require('apollo-link-http');
const fetch = require('node-fetch');
const commons = require('../commons');

const getEnvironmentVariableWithPattern = name => new RegExp(commons.conf.get('INTROSPECT_URL_PATH')).test(name);

const getEnvironmentVariableValue = (name) => {
  const url = commons.conf.get(name);
  commons.logger.info(`Introspect url load: ${url}`);
  return url;
};

const getApolloHttpLink = url => new HttpLink({ uri: `${url}${commons.conf.get('PATH_GRAPHQL')}`, fetch });

const getIntrospectUrls = () => Object.keys(commons.conf.get())
  .filter(getEnvironmentVariableWithPattern)
  .map(getEnvironmentVariableValue)
  .map(getApolloHttpLink);

const createExecutableSchema = async (link) => {
  const schema = await introspectSchema(link);

  return makeRemoteExecutableSchema({
    schema,
    link,
  });
};

module.exports = async () => Promise
  .all(getIntrospectUrls().map(link => createExecutableSchema(link)));
