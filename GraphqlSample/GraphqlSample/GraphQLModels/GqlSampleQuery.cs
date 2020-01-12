using GraphQL.Types;
using GraphqlSample.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlSample.GraphQLModels
{
    public class GqlSampleQuery : ObjectGraphType
    {

        public GqlSampleQuery()
        {

            Field<ListGraphType<ItemType>>(
                name: "items",
                resolve: context => Item.Items
            );

            Field<ItemType>(
                name: "item",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>  
                    Item.Items
                        .Where(x => x.Id == context.GetArgument<int>("id"))
            );
        }

    }
}
