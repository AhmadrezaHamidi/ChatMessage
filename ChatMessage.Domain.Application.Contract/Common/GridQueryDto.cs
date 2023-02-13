using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMesssage.Application.Contract.Common
{
    public class GridQueryDto
    {
        public int Size { get; set; } = 10;
        public int Page { get; set; } = 1;
        public SortModel[] Sorted { get; set; } = new SortModel[]
        {
            new SortModel
            {
                column = "Id",
                desc = true
            }
        };
        public FilterModel[] Filtered { get; set; } = new FilterModel[] { };
    }

    public class FilterModel
    {
        public string column { get; set; }
        public string value { get; set; }
    }

    public class SortModel
    {
        public string column { get; set; }
        public bool desc { get; set; } = false;
    }
}
