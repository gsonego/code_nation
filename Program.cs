using System;
using System.IO;
using System.Runtime.Serialization.Json;

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
            dados.ResumoCriptografico = Criptografia.GerarHashSha1(dados.Decifrado);
            Console.WriteLine($"resumo: {dados.ResumoCriptografico}");

            // salva as alterações no arquivo
            var serializer = new DataContractJsonSerializer(typeof(CodeNationResult));  
            var fileStream = new FileStream(@"C:\Temp\answer.json", FileMode.Open); 
            serializer.WriteObject(fileStream, dados);  
            fileStream.Close();

            // publicando arquivo
            CodeNationService.EnviarArquivo();
        }
    }
}