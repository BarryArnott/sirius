using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SiriusApplication.Models
{
    public class Album
    {
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "The title is required.")]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The description is required.")]
        [StringLength(250, ErrorMessage = "Maximum of 250 characters.")]
        public string Description { get; set; }

        public byte[] AlbumCoverFile { get; set; }

        public string AlbumCoverMimeType { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime CreatedDate { get; set; }

        // relationship property
        public virtual ICollection<Image> Images { get; set; }
    }
}