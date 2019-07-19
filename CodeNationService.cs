using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace CodeNation
{
    public class CodeNationService
    {
        const string Url = "https://api.codenation.dev/v1/challenge/dev-ps/generate-data?token=edbd882b0fb77ae7fc2b703a92ebd8ff98eae41a";
        const string UrlPost = "https://api.codenation.dev/v1/challenge/dev-ps/submit-solution?token=edbd882b0fb77ae7fc2b703a92ebd8ff98eae41a";

        private static readonly HttpClient client = new HttpClient();

        public static async Task<CodeNationResult> ConsultarDesafio()
        {
            client.DefaultRequestHeaders.Accept.Clear();

            var header = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(header);

            client.DefaultRequestHeaders.Add("User-Agent", ".NET Core CodeNation");

            var json = await client.GetStringAsync(Url);

            // grava o arquivo json
            var arquivo = File.CreateText(@"C:\Temp\answer.json");
            arquivo.Write(json);
            arquivo.Close();

            // deserializa o json
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                var deserializer = new DataContractJsonSerializer(typeof(CodeNationResult));
                CodeNationResult bsObj2 = (CodeNationResult)deserializer.ReadObject(ms);

                return bsObj2;
            }
        }

        internal static void EnviarArquivo()
        {
            var paramFileStream = new FileStream(@"C:\Temp\answer.json", FileMode.Open);

            HttpContent fileStreamContent = new StreamContent(paramFileStream);
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(fileStreamContent, "answer", "answer.json");
                var response = client.PostAsync(UrlPost, formData);
                if (!response.Result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Não foi possível enviar o desafio..");
                }
                var result = response.Result.Content.ReadAsStringAsync();
                Console.WriteLine($"Resposta --> {result.Result}");
            }
        }
    }
}