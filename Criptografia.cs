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
    }
}