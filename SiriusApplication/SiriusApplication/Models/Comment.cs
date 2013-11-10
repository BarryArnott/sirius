using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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

        public virtual Image Image { get; set; }
    }
}