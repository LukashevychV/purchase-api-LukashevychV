namespace PurchaseApi.Models
{
    public class Card
    {
        public Card(string cardNumber, string name, DateTime validTo)
        {
            CardNumber = cardNumber;
            Name = name;
            ValidTo = validTo;
        }
        public string CardNumber { get; set; }
        public string Name { get; set; }
        public DateTime ValidTo { get; set; }
    }
}