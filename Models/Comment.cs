
namespace CollectionsWebApp.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }

        public virtual User User { get; set; }
        public string UserId { get; set; }

    }
}
