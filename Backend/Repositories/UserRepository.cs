using Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool IsUnique(string email)
        {
            var alreadyExists = _context.Users.FirstOrDefaultAsync(a => a.Email == email);
            if (alreadyExists == null)
            {
                return false;
            }
            return true;
        }
    }
}
