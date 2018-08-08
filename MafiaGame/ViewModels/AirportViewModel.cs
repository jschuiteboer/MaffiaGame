using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MafiaGame.ViewModels
{
    public class AirportViewModel
    {
        public IEnumerable<SelectListItem> Cities { get; set; }

        [Required]
        public string SelectedCity { get; set; }
    }
}