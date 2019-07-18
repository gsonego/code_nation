using System.Runtime.Serialization;

namespace CodeNation
{
    [DataContract]
    public class CodeNationResult
    {
        [DataMember(Name = "numero_casas")]
        public int NumeroCasas { get; set; }

        [DataMember(Name = "token")]
        public string Token;

        [DataMember(Name = "cifrado")]
        public string Cifrado;

        [DataMember(Name = "decifrado")]
        public string Decifrado;

        [DataMember(Name = "resumo_criptografico")]
        public string ResumoCriptografico;
    }
}