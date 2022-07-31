using System.Collections.Generic;
using System.Linq;

namespace HelperExtentions
{
    public class ResultViewModel<T>
    {
        public T Result { get; set; }

        public List<string> Errors { get; set; }
        public bool ValidOperation => !Errors.Any();

        public ResultViewModel(T result, List<string> errors)
        {
            Result = result;
            Errors = errors;
        }

        public ResultViewModel()
        {
            Errors = new List<string>();
        }

        public ResultViewModel<T> AddResult(T model)
        {
            Result = model;
            return this;
        }

        public ResultViewModel<T> AddError(string error)
        {
            Errors.Add(error);
            return this;
        }

        public ResultViewModel<T> AddError(List<string> errors)
        {
            Errors.AddRange(errors);
            return this;
        }
    }
}
