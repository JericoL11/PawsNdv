using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paws.Application.Helpers
{

    //wrapper for page response | mainly used for filtering
    public class PagedResponse<T>
    {
        public IEnumerable<T> Data { get; set; } = new List<T>();
        public int? TotalCount { get; set; }

        //constructor
        public PagedResponse(IEnumerable<T> data, int? totalCount) 
        {
            Data = data;
            TotalCount = totalCount;
        }

    }
}
