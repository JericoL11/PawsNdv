using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paws.Application.Helpers
{
    public class ApiResponse<T>
    {
        public IEnumerable<T> Data { get; set; } = new List<T>();

        public int TotalCount { get; set; }


        //constructor
        public ApiResponse(IEnumerable<T> data, int totalCount) 
        {
            Data = data;
            TotalCount = totalCount;
        }
    }
}
