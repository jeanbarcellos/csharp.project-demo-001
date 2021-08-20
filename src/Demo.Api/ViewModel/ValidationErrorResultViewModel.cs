using System.Collections.Generic;

namespace Demo.Api.ViewModel
{
    public class ValidationErrorResultViewModel
    {
        public bool Success = false;
        public string Message { get; set; }
        public Dictionary<string, List<string>> Errors { get; private set; }

        public ValidationErrorResultViewModel()
        {
            Errors = new Dictionary<string, List<string>>();
        }

        public ValidationErrorResultViewModel AddError(string key, string value)
        {
            var exists = Errors.ContainsKey(key);

            if (exists)
            {
                Errors[key].Add(value);
            }
            else
            {
                Errors[key] = new List<string>
                {
                    value
                };
            }

            return this;
        }

        internal void AddError(string key, List<string> errors)
        {
            Errors[key] = errors;
        }
    }
}
