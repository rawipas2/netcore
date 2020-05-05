using System;
using System.Collections.Generic;
namespace FeedFackbook.Models
{
    public class UserViewModel
    {
        public int UserId​ { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public string Nat { get; set; }
        public string Imagehighlights { get; set;}
        public string Imagebg { get; set; }


        public NameViewModel Name { get; set; }
        public LocationViewModel Location { get; set; }
        public LoginViewModel Login { get; set; }
        public DobViewModel Dob { get; set; }
        public RegisteredViewModel Registered { get; set; }
        public IdViewModel Id { get; set; }
        public PictureViewModel Picture { get; set; }

        public List<TitlesViewModel> Titles { get; set; }
        public List<FriendViewModel> Friends { get; set; }


        public UserViewModel()
        {
        }
    }
 
}
