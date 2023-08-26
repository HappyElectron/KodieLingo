using KodieLingo.Model;

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
	}
}
