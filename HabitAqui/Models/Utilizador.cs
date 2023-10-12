using Microsoft.AspNetCore.Identity;

namespace HabitAqui.Models
{
	
	public class Utilizador : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
