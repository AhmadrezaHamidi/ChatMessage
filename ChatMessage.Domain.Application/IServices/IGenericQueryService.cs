using ChatMesssage.Application.Contract.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMesssage.Application.IServices
{
    public interface IGenericQueryService<T> where T : class
    {
        Task<ChatMesssageActionResult<List<T>>> QueryAsync(GridQueryDto args, IList<string> fields = null, IList<string> includes = null);
    }
}
