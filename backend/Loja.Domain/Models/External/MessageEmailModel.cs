using System.Collections.Generic;

namespace Loja.Domain.Models.External
{
    public class MessageEmailModel
    {
        public string EmailDestinatario { get; set; }
        public string Remetente { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }
        public List<EmailAnexo>? Anexos { get; set; }
    }

    public class EmailAnexo
    {
        public string Nome { get; set; }
        public string Mime { get; set; }
        public string Base64 { get; set; }
    }
}
