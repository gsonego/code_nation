using System;

namespace code_nation
{
    class Program
    {
        const string Alfabeto = "abcdefghijklmnopqrstuvwxyz"; 

        static void Main(string[] args)
        {
            //string textoDecifrado = "gkvusxq yx gkdob kxn nofovyzsxq cypdgkbo pbyw k czomspsmkdsyx kbo okci sp lydr kbo pbyjox. ongkbn f lobkbn";
            string textoDecifrado = "walking on water and developing software from a specification are easy if both are frozen. edward v berard";
            Console.WriteLine(textoDecifrado);

            string textoCifrado = Cifrar(10, textoDecifrado);
            Console.WriteLine(textoCifrado);

            // textoDecifrado = Decifrar(10, textoCifrado);
            // Console.WriteLine(textoDecifrado);
        }

        static string Cifrar(int casas, string texto){
            string result = string.Empty;

            foreach(var letra in texto){
                int pos = Alfabeto.IndexOf(letra);

                // caractere não localizado no alfabeto
                if (pos < 0){
                    result += letra;
                    continue;
                }

                // desloca a posição da letra
                pos += casas;

                if (pos >= Alfabeto.Length){
                    pos -= Alfabeto.Length;
                }

                char novaLetra = Alfabeto[pos];

                result += novaLetra;
            }

            return result;
        }      
    }
}
