using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ProductInsertResponse
    {
        public InsertProductResponseData Data { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }

    }
}
