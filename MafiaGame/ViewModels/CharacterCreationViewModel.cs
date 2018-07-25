using MafiaGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MafiaGame.ViewModels
{
    public class CharacterCreationViewModel
    {
        [Required]
        public string Name { get; set; }

        public IEnumerable<SelectListItem> GenderList { get; }

        [Required]
        public string SelectedGender { get; set; }

        public IEnumerable<SelectListItem> StartingCities { get; set; }

        [Required]
        public string SelectedStartingCity { get; set; }

        public CharacterCreationViewModel()
        {
            this.GenderList = GetGenders();
        }

        //TODO: move to service?
        private List<SelectListItem> GetGenders()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "male", Text = "Male" },
                new SelectListItem { Value = "female", Text = "Female" },
            };
        }
    }
}