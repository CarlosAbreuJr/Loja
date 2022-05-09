using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loja.Domain.Models.Shared
{
    public class ResponseCreatedBase<T> : ObjectResult
    {
        public ResponseCreatedBase(T data) : base(data)
        {
            Value = data;
            StatusCode = StatusCodes.Status201Created;
        }
    }
}