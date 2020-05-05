using System;
namespace FeedFackbook.Models
{
    public class FriendViewModel
    {
        public int FriendId { get; set; }
        public int ParentUserId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public UserViewModel User { get; set; }

        public FriendViewModel()

        {
        }
    }
   

}
