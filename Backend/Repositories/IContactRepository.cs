using Backend.Models;

namespace Backend.Repositories
{
    public interface IContactRepository
    {
        Task<Contact> CreateAsync(Contact contact);
        Task<Contact> UpdateAsync(int id, Contact contact);
        Task<Contact> DeleteAsync(int id);
        Task<Contact> GetAsync(int id);
        Task<IEnumerable<Contact>> GetAllContacts();
    }
}
