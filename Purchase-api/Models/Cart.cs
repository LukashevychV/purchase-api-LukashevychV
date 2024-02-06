namespace PurchaseApi.Models
{
    public class Cart
    {
        public Card card { get; set; }
        public AddressInfo addressInfo { get; set; }
        public IEnumerable<CartItem> items { get; set; }

        public Cart(Card card, AddressInfo addressInfo, IEnumerable<CartItem> items)
        {
            this.card = card;
            this.addressInfo = addressInfo;
            this.items = items;
        }
    }
}
