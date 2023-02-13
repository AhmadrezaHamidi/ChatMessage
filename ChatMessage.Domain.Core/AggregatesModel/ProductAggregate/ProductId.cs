using ChatMesssage.Domain.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMesssage.Domain.Core.AggregatesModel.ProductAggregate
{
    public sealed class ProductId : StronglyTypedId<ProductId>
    {
        public ProductId(Guid value):base(value)
        {

        }
    }
}
