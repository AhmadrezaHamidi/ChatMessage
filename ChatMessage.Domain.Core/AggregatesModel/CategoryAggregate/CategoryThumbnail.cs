using ChatMesssage.Domain.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMesssage.Domain.Core.AggregatesModel.CategoryAggregate
{
    public class CategoryThumbnail : ValueObject<CategoryThumbnail>
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int Size { get; set; }

        protected override bool EqualsCore(CategoryThumbnail other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
