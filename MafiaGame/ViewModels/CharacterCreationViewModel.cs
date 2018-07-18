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

        public IEnumerable<SelectListItem> StartingCities { get; }

        [Required]
        public string SelectedStartingCity { get; set; }

        public CharacterCreationViewModel()
        {
            this.GenderList = GetGenders();
            this.StartingCities = GetStartingCities();
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

        //TODO: move to service?
        private List<SelectListItem> GetStartingCities()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "city 1", Text = "City 1" },
                new SelectListItem { Value = "city 2", Text = "City 2" },
                new SelectListItem { Value = "city 2", Text = "City 3" },
                new SelectListItem { Value = "city 17", Text = "City 17" },
            };
        }
    }
}