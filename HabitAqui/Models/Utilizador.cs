using Microsoft.AspNetCore.Identity;

namespace HabitAqui.Models
{
    public class Utilizador : IdentityUser
	{
		[PersonalData]
		public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
	}
}
