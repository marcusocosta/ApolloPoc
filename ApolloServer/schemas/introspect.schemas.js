import { makeRemoteExecutableSchema, introspectSchema } from 'graphql-tools';
import { HttpLink } from 'apollo-link-http';
import fetch from 'node-fetch';

const links = [
    new HttpLink({ uri: 'http://localhost:8005/graphql', fetch }),
    new HttpLink({ uri: 'http://localhost:8006/graphql', fetch })];

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