using PB.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticeBook.DTOs
{
    public class PracticeCompanyEntry
    {
        [Required]
        public string PracticeId { get; set; }

        [Required]
        public string CompanyId { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Value must be between 1 to 15")]
        public int Capacity { get; set; }

    }
}