using System;
using System.ComponentModel.DataAnnotations;
namespace CRUDDelicious.Models
{
    public class Dish
    {
        [Key]
        public int DiSId {get; set;}
        [Required(ErrorMessage = "ChefName is required")]
        [MinLength(4)]
        public string ChefName {get; set;}
        [Required(ErrorMessage = "Dish Name is required")]
        public string DishName {get; set;}
        [Display(Name = "Description:")] 
        public  string Description {get; set;}
        [Required(ErrorMessage = "Calories is required")]
        [Display(Name = "Calories:")]
        [Range(1,1000)]
        
        public int calories {get; set;}
        [Required(ErrorMessage = "Tastiness is required")]
        [Display(Name = "Tastiness:")]
        [Range(1, 5)]

        public string Tastiness {get; set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}