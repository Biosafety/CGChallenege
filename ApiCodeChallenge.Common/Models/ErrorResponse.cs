using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ApiCodeChallenge.Common.Models
{
    public class ErrorResponse
    {
        public string Status { get; set; }
        public string Detail { get; set; }

        public ErrorResponse(HttpStatusCode status, string detail)
        {
            Status = status.ToString();
            Detail = detail;
        }
        public ErrorResponse(HttpStatusCode status)
        {
            Status = status.ToString();
        }
    }
}
