using System;

namespace Application.Payload.Response.Bank
{
    public class BankResponse
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? BankNo { get; set; }
        public string? Location { get; set; }
        public Guid? WareHouseId { get; set; }
        public string? WareHouseName { get; set; }
        public string? Address { get; set; }
        public string? Lat { get; set; }
        public string? Lon { get; set; }
    }
}
