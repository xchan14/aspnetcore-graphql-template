using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlSample.GraphQLModels
{
    public class GqlSampleSchema : Schema
    {
        public GqlSampleSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<GqlSampleQuery>();
            Mutation = resolver.Resolve<GqlSampleMutation>();
        }
    }
}
