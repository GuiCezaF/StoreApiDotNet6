namespace MP.ApiDotNet6.Application.DTOS
{
    public class PurchaseDTO
    {
        public string CodeErp { get; set; }
        public string Document { get; set; }
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }
    }
}