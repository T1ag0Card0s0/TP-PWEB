using Microsoft.AspNetCore.Identity;

namespace HabitAqui.Models
{
	
	public class Utilizador : IdentityUser
	{
		public int UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email {  get; set; }
		public string Password { get; set; }
	}
}
