using PhoneApp.Models;
using PhoneApp.Entities;

namespace PhoneApp.Extensions
{
    public static class ContactExtensions
    {
        public static Contact ToEntity(this ContactModel contact)
        {
            return new Contact()
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                Phone = contact.Phone
            };
        }

        public static ContactModel ToModel(this Contact contact)
        {
            return new ContactModel()
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                Phone = contact.Phone
            };
        }
    }
}
