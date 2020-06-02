using System;
using System.ComponentModel.DataAnnotations;
using RegistrationService.Models;

namespace RegistrationService.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            
        }

        public UserViewModel(User user)
        {
            this.UserName = user.UserName;
            this.Email = user.Email;
            this.FullName = user.FullName;
            this.BirthDate = user.BirthDate;
        }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Электронный адрес")]
        public string Email { get; set; }

        [Display(Name = "ФИО")]
        public string FullName { get; set; }

        [Display(Name = "Год рождения")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime BirthDate { get; set; }
    }
}