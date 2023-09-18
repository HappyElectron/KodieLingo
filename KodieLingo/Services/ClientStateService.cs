using KodieLingo.Model;
using KodieLingo.Data;
using Microsoft.EntityFrameworkCore;

// Maintaining client state through a scoped service
// Yes, it's unsecure, no, I do not care
// 
// A notable, non-security issue is that when the user lands on an error page, a new object is created.
// Effectively, this will log the user out.

namespace KodieLingo.Services
{
	public class ClientStateService
	{
		public User? User { get; set; }
		public bool OpenNavMenu { get; set; } = true;
        private DatabaseContext? db { get; set; }


        public ClientStateService(DatabaseContext context)
		{
			db = context;
		}
		public User GetUser(string email)
		{
			return db.Users.Where(x => x.Email == email)
            .Include(b => b.Friend)
            .Include(b => b.FriendReqIncoming)
            .Include(b => b.FriendReqOutgoing)
			.Include(b => b.Course)
            .FirstOrDefault();
        }
	}
}
