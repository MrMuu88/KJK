using KJK.Data.Models;
using System;

namespace KJK.Server.ViewModels
{
	public class UserViewModel : BaseViewModel<User>
	{
		
		public string FirstName {get=>Model.FirstName; set=>Model.FirstName=value;}
		public string LastName {get=>Model.LastName; set=>Model.LastName=value;}
		public string NickName {get=>Model.NickName; set=>Model.NickName=value;}
		public string Email {get=>Model.Email; set=>Model.Email=value;}
		public DateTime? BirthDate {get=>Model.BirthDate; set=>Model.BirthDate=value;}

		// during register pase the Password is non hashed, but the underlying model needs to store the password hashed
		// hasing is called on this when registering logic kicks in
		public string Password { get; set; } 


		public UserViewModel(User user) : base(user) { }

		public UserViewModel() : base(new User()) { }
	}
}
