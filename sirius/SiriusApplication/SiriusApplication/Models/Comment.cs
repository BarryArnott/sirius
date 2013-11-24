using System.ComponentModel.DataAnnotations;

namespace SiriusApplication.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int ImageID { get; set; }

        [Required]
        [StringLength(250)]
        public string Subject { get; set; }

        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        // relationship property
        public virtual Image Image { get; set; }
    }
}