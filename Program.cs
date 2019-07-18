using System;

namespace CodeNation
{
    public class Program
    {
        static void Main(string[] args)
        {
            CodeNationResult dados = CodeNationService.ConsultarDesafio().Result;

            Console.WriteLine($"casas: {dados.NumeroCasas}");
            Console.WriteLine($"token: {dados.Token}");
            Console.WriteLine($"cifrado: {dados.Cifrado}");

            // decifra texto
            dados.Decifrado = Criptografia.Decifrar(dados.NumeroCasas, dados.Cifrado);
            Console.WriteLine($"decifrado: {dados.Decifrado}");

            // calcula resumo
            Console.WriteLine($"resumo: {dados.ResumoCriptografico}");
        }
    }
}