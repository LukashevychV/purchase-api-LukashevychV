namespace PurchaseApi.Models
{
    public class AddressInfo
    {
        public AddressInfo(string street, string address, string city, string postalCode, string phoneNumber)
        {
            Street = street;
            Address = address;
            City = city;
            PostalCode = postalCode;
            PhoneNumber = phoneNumber;
        }

        public string Street { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
