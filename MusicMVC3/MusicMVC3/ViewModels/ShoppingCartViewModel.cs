using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicMVC3.Models;


namespace MusicMVC3.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }

}