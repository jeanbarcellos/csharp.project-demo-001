using System.Collections.Generic;

namespace Demo.Api.ViewModel
{
    public class ErrorResultViewModel
    {
        public bool Success = false;
        public string Message { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
    }
}
