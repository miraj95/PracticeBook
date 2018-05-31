using System;
using System.ComponentModel.DataAnnotations;

namespace PB.Common
{
    public class CustomException : Exception
    {
        public CustomException(Exception ex)
        {
            this.OriginalException = ex;
            this.Id = new CustomId().ToString();
        }

        [Key]
        public string Id { get; set; }

        public Exception OriginalException { get; set; }

        public string ClientErrorMessage { get { return string.Format("Unexpected error with Id: {0} has occured on the server.", this.Id); } }

    }
}
