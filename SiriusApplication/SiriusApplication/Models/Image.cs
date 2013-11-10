using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace SiriusApplication.Models
{
    public class Image
    {
        public int ImageID { get; set; }

        [Required]
        public string Title { get; set; }
        public byte[] ImageFile { get; set; }
        public string ImageMimeType { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Comment>Comments { get; set; }
    }
}