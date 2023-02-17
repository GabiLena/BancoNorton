namespace BancoNorton.Api.DTO
{
    public class TansferenciaDTO
    {
        public int? Id { get; set; }
        public int Valor { get; set; }
        public int IdContaOrigem { get; set; }
        public int IdContaDestino { get; set; }
    }
}
