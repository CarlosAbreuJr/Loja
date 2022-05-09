using Loja.Domain.Models.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Domain.Interface.External
{
    public interface IMessage
    {
        void SMS(MessageSmsModel sms);
        void EMAIL(MessageEmailModel email);
    }
}
