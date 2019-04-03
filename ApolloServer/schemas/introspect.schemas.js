import { makeRemoteExecutableSchema, introspectSchema } from 'graphql-tools';
import { HttpLink } from 'apollo-link-http';
import fetch from 'node-fetch';
import commons from '../commons';

const links = commons.conf.get("LINKS").map(link => new HttpLink({ uri: link, fetch }));

export default async () => {
    return await Promise.all(links.map(link => createExecutableSchema(link)));
}

const createExecutableSchema = async (link) => {
    const schema = await introspectSchema(link);

    return makeRemoteExecutableSchema({
        schema,
        link,
    });
}