import { makeRemoteExecutableSchema, introspectSchema } from 'graphql-tools';
import { HttpLink } from 'apollo-link-http';
import fetch from 'node-fetch';

const link = new HttpLink({ uri: 'http://localhost:8006/graphql', fetch });

export default async() => {

    const schema = await introspectSchema(link);

    const executableSchema = makeRemoteExecutableSchema({
        schema,
        link,
    });

    return executableSchema
};