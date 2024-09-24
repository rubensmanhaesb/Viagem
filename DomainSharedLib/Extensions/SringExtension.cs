
namespace DomainSharedLib.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// Capitaliza cada palavra em uma string, convertendo a primeira letra de cada palavra para maiúscula
        /// e o restante das letras para minúsculas. Palavras com comprimento de 2 caracteres ou menos são mantidas
        /// no formato original.
        /// </summary>
        /// <param name="input">A string de entrada que será processada.</param>
        /// <returns>Uma nova string com cada palavra capitalizada.</returns>
        public static string CapitalizeWords(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            // Divide a string em palavras, removendo espaços em branco nas extremidades
            string[] words = input.Trim().Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrEmpty(words[i]))
                {
                    // Capitaliza a primeira letra de palavras com mais de 2 caracteres
                    if (words[i].Trim().Length > 2)
                        words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                    else
                        words[i] = words[i]; // Mantém palavras de 2 caracteres ou menos no formato original
                }
            }

            // Junta as palavras de volta em uma única string com espaços
            return string.Join(' ', words);
        }
    }
}
