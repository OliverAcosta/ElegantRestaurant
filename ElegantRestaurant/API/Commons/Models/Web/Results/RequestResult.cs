using Commons.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Web.Results
{
    public class RequestResult
    {
        public RequestResult(){}
        public RequestResult(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
        }
        public RequestResult(string message, ref object data)
        {
            this.Success = Success; 
            this.Data = data;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public ErrorResult Errors { get; set; }

        public static RequestResult UserTaked = new RequestResult(false, "The username or email is taken");
        public static RequestResult BadWebToken = new RequestResult(false, "The token is no valid");
        public static RequestResult BadLogging = new RequestResult(false, "Wrong username or password");
        public static RequestResult NotDataFound = new RequestResult(false, "Not data found");

        public static RequestResult ContactTheAdministrator = new RequestResult
        {
            Message = "The request fail see Errors for check errors",
            Errors = new ErrorResult
            {
                Message = "Please, contact the administrator some errors happends"
            }
        };
    }
}
