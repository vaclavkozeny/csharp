using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart2021.Models
{
    public class CartItem
    {
        [BindProperty]
        [Display(Name="Název položky")]
        [Required(ErrorMessage = "Název položky musí být vyplněn")]
        public string Name { get; set; }
        [BindProperty]
        [Display(Name = "Počet kusů")]
        [Range(1, 100)]
        [Required(ErrorMessage = "Počet položek musí být vyplněn")]
        public int Amount { get; set; }
        [BindProperty]
        [Display(Name = "Jednotková cena")]
        [Required(ErrorMessage = "Cena musí být vyplněna")]
        public double UnitPrice { get; set; }
    }
}
