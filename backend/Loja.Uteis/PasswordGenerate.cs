namespace Loja.Uteis
{
    public static class PasswordGenerate
    {
        public static string New()
        {
            const string CAIXA_BAIXA = "abcdefghijklmnopqrstuvwxyz";
            const string CAIXA_ALTA = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string NUMEROS = "0123456789";
            const string ESPECIAIS = @"!@#$%*+";


            // Faz uma lista de caracteres permitidos
            string permitido = "";
            permitido += CAIXA_BAIXA;
            permitido += CAIXA_ALTA;
            permitido += NUMEROS;
            permitido += ESPECIAIS;

            int numero_caracteres = NewCrypto.RandomInteger(8, 10);

            // Satisfaz as definições
            string _senha = "";
            if ((_senha.IndexOfAny(CAIXA_BAIXA.ToCharArray()) == -1))
                _senha += RandomChar(CAIXA_BAIXA);
            if ((_senha.IndexOfAny(CAIXA_ALTA.ToCharArray()) == -1))
                _senha += RandomChar(CAIXA_ALTA);
            if ((_senha.IndexOfAny(NUMEROS.ToCharArray()) == -1))
                _senha += RandomChar(NUMEROS);
            if ((_senha.IndexOfAny(ESPECIAIS.ToCharArray()) == -1))
                _senha += RandomChar(ESPECIAIS);


            // adiciona os caracteres restantes aleatorios
            while (_senha.Length < numero_caracteres)
                _senha += RandomChar(permitido);

            // mistura os caracteres requeridos 
            _senha = RandomizeString(_senha);

            return _senha;
        }

        // retorna um caractere aleatorio a partir de uma string
        private static string RandomChar(string str)
        {
            return str.Substring(NewCrypto.RandomInteger(0, str.Length - 1), 1);
        }

        // Retorna uma permutação aleatoria de uma string
        private static string RandomizeString(string str)
        {
            string resultado = "";
            while (str.Length > 0)
            {
                // Pega um numero aleatorio
                int i = NewCrypto.RandomInteger(0, str.Length - 1);
                resultado += str.Substring(i, 1);
                str = str.Remove(i, 1);
            }
            return resultado;
        }
    }

}