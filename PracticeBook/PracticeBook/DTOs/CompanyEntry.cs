using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticeBook.DTOs
{
    public class CompanyEntry
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        //[Range(1, 20, ErrorMessage = "Value must be between 1 to 15")]
        public string Address { get; set; }
    }
}