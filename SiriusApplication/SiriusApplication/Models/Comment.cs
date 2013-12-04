using System.ComponentModel.DataAnnotations;

namespace SiriusApplication.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int ImageID { get; set; }

        [Required(ErrorMessage = "The description is required.")]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters.")]
        public string Subject { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(250, ErrorMessage = "Maximum of 250 characters.")]
        public string Body { get; set; }

        // relationship property
        public virtual Image Image { get; set; }
    }
}