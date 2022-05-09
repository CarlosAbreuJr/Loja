using Loja.Domain.Interface.External;
using Loja.Domain.Models.External;
using Newtonsoft.Json;

namespace Loja.Service.External
{
    public class SentMessage : IMessage
    {
        private readonly ConsoleColor _backColor;
        private readonly ConsoleColor _foreColor;

        public SentMessage()
        {
            _backColor=Console.BackgroundColor;
            _foreColor=Console.ForegroundColor;
        }

        public void EMAIL(MessageEmailModel email)
        {
            var texto = ".....Enviandoooooo Faça de conta que é um servico de email ......";
            SimularEnvio(texto, ConsoleColor.Blue, ConsoleColor.Yellow, email);

        }


        public void SMS(MessageSmsModel sms)
        {
            var texto = ".....Enviandoooooo Faça de conta que é um servico de SMS ......";
            SimularEnvio(texto, ConsoleColor.Green, ConsoleColor.White, sms);

        }
        private void SimularEnvio(string texto, ConsoleColor backColor, ConsoleColor foreColor, object data)
        {
            Console.BackgroundColor = backColor;
            Console.ForegroundColor =foreColor;

            var lstTexto = texto.Select(x => x.ToString()).ToList();
            Console.WriteLine("-------------------------------------");
            lstTexto.ForEach(x =>
            {
                Console.Write(x);
                Thread.Sleep(90);
            });
            Console.WriteLine("");
            Console.WriteLine(JsonConvert.SerializeObject(data));
            Console.WriteLine("-----Envio concluído ---------------------------");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.BackgroundColor = _backColor;
            Console.ForegroundColor = _foreColor;
        }
    }
}