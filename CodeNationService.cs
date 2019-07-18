using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace CodeNation
{
    public class CodeNationService
    {
        const string Url = "https://api.codenation.dev/v1/challenge/dev-ps/generate-data?token=edbd882b0fb77ae7fc2b703a92ebd8ff98eae41a";

        private static readonly HttpClient client = new HttpClient();

        public static async Task<CodeNationResult> ConsultarDesafio()
        {
            client.DefaultRequestHeaders.Accept.Clear();

            var header = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(header);

            client.DefaultRequestHeaders.Add("User-Agent", ".NET Core CodeNation");

            var streamTask = await client.GetStreamAsync(Url);

            var serializer = new DataContractJsonSerializer(typeof(CodeNationResult));
            var result = serializer.ReadObject(streamTask) as CodeNationResult;

            return result;
        }
    }
}