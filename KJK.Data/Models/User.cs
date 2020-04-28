using System;

namespace KJK.Data.Models
{
	public class User:BaseModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string NickName { get; set; }
		public string Email { get; set; }
		public DateTime? BirthDate { get; set; }
		public string Password { get; set; }
	}
}
