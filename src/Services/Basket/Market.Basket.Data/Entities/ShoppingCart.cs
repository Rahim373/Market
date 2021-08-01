using System.Collections.Generic;
using System.Linq;

namespace Market.Basket.Data.Entities
{
    public class ShoppingCart
    {
        public ShoppingCart() { }
        public ShoppingCart(string username)
        {
            UserName = username;
        }

        public string UserName { get; set; }
        public List<ShoppingCartItem> Items { get; set; }
        public decimal SubTotal { get => Items?.Sum(x => x.Total) ?? 0; }
    }
}
