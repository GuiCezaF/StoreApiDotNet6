﻿namespace MP.ApiDotNet6.Application.DTOS
{
    public class PurchaseDetailDTO
    {
        public int Id { get; set; }
        public string Person { get; set; }
        public string Product { get; set; }
        public DateTime Date { get; set; }
    }
}