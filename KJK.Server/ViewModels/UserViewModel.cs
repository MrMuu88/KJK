using KJK.Data.Models;
using System;

namespace KJK.Server.ViewModels
{
    public class UserViewModel : BaseViewModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }

        // during register pase the Password is non hashed, but the underlying model needs to store the password hashed
        // hasing is called on this when registering logic kicks in
        public string Password { get; set; }

    }
}
