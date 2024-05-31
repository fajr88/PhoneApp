using Microsoft.EntityFrameworkCore;
using PhoneApp.Data;
using PhoneApp.Entities;

namespace PhoneApp.Data
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Contact> GetAll()
        {
            return _dbContext.Contacts.ToList();
        }
        public void Add(Contact Contact)
        {
            _dbContext.Contacts.Add(Contact);
            _dbContext.SaveChanges();
        }
        public void Update(Contact Contact)
        {
            var entry = _dbContext.Contacts.Find(Contact.Id);
            _dbContext.Entry(entry).CurrentValues.SetValues(Contact);
            _dbContext.SaveChanges();
        }
        public Contact Find(int id)
        {
            var foundProduct = _dbContext.Contacts.Find(id);

            if (foundProduct is null)
                throw new Exception("Product not found");

            return foundProduct;
        }
        public void Delete(int id)
        {
            var entry = Find(id);
            _dbContext.Contacts.Remove(entry);
            _dbContext.SaveChanges();
        }

        public List<Contact> Search(string firstName, string lastName, string email, string phone)
        {
            var query = _dbContext.Contacts.AsQueryable();

            if (!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(c => c.FirstName.Contains(firstName));
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                query = query.Where(c => c.LastName.Contains(lastName));
            }

            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(c => c.Email.Contains(email));
            }

            if (!string.IsNullOrEmpty(phone))
            {
                query = query.Where(c => c.Phone.Contains(phone));
            }

            return query.ToList();
        }
    }
}
