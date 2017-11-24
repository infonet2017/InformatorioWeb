using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaFiles.Models
{
    public class Support
    {
        public int SupportId { get; set; }

        [Required(ErrorMessage = "Please Enter Your Name")]
        [Display(Name = "Name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Summary")]
        [Display(Name = "Summary")]
        [MaxLength(500)]
        public string Summary { get; set; }

        public virtual List<FileDetail> FileDetails { get; set; }

        public string GetExtension()
        {
            return FileDetails[0].Extension;
        }

        public string GetFileName()
        {
            return FileDetails[0].FileName;
        }

        public String GetFileID()
        {
            return FileDetails[0].Id.ToString();
        }

        public String GetSupportID()
        {
            return SupportId.ToString();
        }
    }
}