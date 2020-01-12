using GraphQL.Types;
using GraphqlSample.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlSample.GraphQLModels
{
    public class ItemType : ObjectGraphType<Item>
    {

        public ItemType()
        {
            Field(x => x.Id);
            Field(x => x.Description);
            Field(x => x.Value);
        }
    }
}
