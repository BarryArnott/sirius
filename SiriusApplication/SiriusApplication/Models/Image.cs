using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SiriusApplication.Models
{
    public class Image
    {
        public int ImageId { get; set; }

        public int? AlbumId { get; set; }

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
        [DisplayName("Uploaded Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime UploadedDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Captured Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime ImageTakenOnDate { get; set; }

        [DisplayName("ISO Rating")]
        [StringLength(7, ErrorMessage = "Maximum of 7 characters.")]
        public string IsoRating { get; set; }

        [StringLength(10, ErrorMessage = "Maximum of 10 characters.")]
        [DisplayName("Focal Length")]
        public string FocalLength { get; set; }

        [StringLength(5, ErrorMessage = "Maximum of 5 characters.")]
        public string Aperture { get; set; }

        [StringLength(12, ErrorMessage = "Maximum of 12 characters.")]
        [DisplayName("Shutter Speed")]
        public string ShutterSpeed { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        // relationship property
        public virtual ICollection<Comment> Comments { get; set; }
    }
}