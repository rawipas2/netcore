using System;
namespace FeedFackbook.Models
{
    public class FeedViewModel
    {
            public int ParentUserId { get; set; }
            public int FeedId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Image { get; set; }
            public int Like { get; set; }
            public bool ParentUserLiked { get; set; }
            public int Shareds { get; set; }
            public string Imagepost { get; set; }

            public CommentViewModel Comment { get; set; }
            public UserViewModel User { get; set; }


        public FeedViewModel()
        {
        }
    }
}
