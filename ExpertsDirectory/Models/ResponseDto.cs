using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ResponseDto
    {
        public System.Net.HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
