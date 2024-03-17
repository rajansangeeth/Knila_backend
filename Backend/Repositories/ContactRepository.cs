using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private ApplicationDbContext _context;
        public ContactRepository(ApplicationDbContext dbContext)
        {
            _context=dbContext;
        }

        public async Task<Contact> CreateAsync(Contact contact)
        {
            var alreadyExists = _context.Contacts.FirstOrDefault(a => a.Email == contact.Email);
            if (alreadyExists != null)
            {
                return null;
            }

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> DeleteAsync(int id)
        {
            var existingContact = await _context.Contacts.FindAsync(id);
            if (existingContact != null)
            {
                _context.Contacts.Remove(existingContact);
                _context.SaveChanges();
            }
            return null;
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetAsync(int id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Contact> GetAsync(Contact contact)
        {
            throw new NotImplementedException();
        }

        public async Task<Contact> UpdateAsync(int id, Contact contact)
        {
            Contact existingContact = await _context.Contacts.FirstOrDefaultAsync(a => a.Id == id);
            if (existingContact == null)
            {
                return null;
            }
            existingContact.FirstName = contact.FirstName;
            existingContact.LastName = contact.LastName;
            existingContact.PhoneNumber = contact.PhoneNumber;
            existingContact.Email = contact.Email;
            existingContact.State = contact.State;
            existingContact.Address = contact?.Address;
            existingContact.City = contact.City;
            existingContact.Country = contact.Country;
            await _context.SaveChangesAsync();
            return existingContact;
        }
    }
}


