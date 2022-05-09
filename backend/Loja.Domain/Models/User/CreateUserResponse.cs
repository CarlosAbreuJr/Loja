using Loja.Domain.Models.Shared;
using System.Collections.Generic;

namespace Loja.Domain.Models.User
{
    public class CreateUserResponse : ResponseBase<CreateUserNoPassModel>
    {
        public IEnumerable<string> Message { get; set; }
        public CreateUserResponse(bool success, IEnumerable<string> message, CreateUserNoPassModel user) : base(success, user)
        {
            Message = message;
        }
        public CreateUserResponse(bool success, string message, CreateUserNoPassModel user) : base(success, user)
        {
            Message = new List<string> { message };
        }

        public CreateUserResponse(bool success, CreateUserNoPassModel user) : base(success, user)
        {
        }
    }
}
