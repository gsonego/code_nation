using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CodeNation
{
    public class Criptografia
    {
        const string Alfabeto = "abcdefghijklmnopqrstuvwxyz";

        public static string Decifrar(int casas, string texto)
        {
            string result = string.Empty;

            foreach (var letra in texto)
            {
                int pos = Alfabeto.IndexOf(letra);

                // caractere não localizado no alfabeto
                if (pos < 0)
                {
                    result += letra;
                    continue;
                }

                // desloca a posição da letra
                pos -= casas;

                // ajusta a posição caso ultrapasse o início
                if (pos < 0)
                {
                    pos = Alfabeto.Length + pos;
                }

                char novaLetra = Alfabeto[pos];

                result += novaLetra;
            }

            return result;
        }

        private static string GenerateHashString(HashAlgorithm algo, string text)
        {
            // Compute hash from text parameter
            algo.ComputeHash(Encoding.UTF8.GetBytes(text));

            // Get has value in array of bytes
            var result = algo.Hash;

            // Return as hexadecimal string
            return string.Join(string.Empty, result.Select(x => x.ToString("x2")));
        }
        
        public static string GerarHashSha1(string text)
        {
            var result = default(string);

            using (var algo = new SHA1Managed())
            {
                result = GenerateHashString(algo, text);
            }

            return result;
        }
    }
}