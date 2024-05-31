using System.ComponentModel.DataAnnotations;

namespace PhoneApp.Models
{
       public class ContactModel
    {
        // Parameterless constructor
        public ContactModel()
        {
        }

        // Parameterized constructor
        public ContactModel(int id, string firstName, string lastName, string email, string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }

        public int Id { get; set; }

        [Display(Name = "Firat Name")]
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name can't be longer than 50 characters")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name can't be longer than 50 characters")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }
    }
}
