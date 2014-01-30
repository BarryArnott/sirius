using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SiriusApplication.Models
{
    public class Image
    {
        public int ImageID { get; set; }

        public int? AlbumID { get; set; }

        [Required(ErrorMessage = "The title is required.")]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters.")]
        public string Title { get; set; }

        [DisplayName("Picture")]
        public byte[] ImageFile { get; set; }
        public string ImageMimeType { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(250, ErrorMessage = "Maximum of 250 characters.")]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime CreatedDate { get; set; }
        
        // relationship property
        public virtual ICollection<Comment> Comments { get; set; }
    }
}