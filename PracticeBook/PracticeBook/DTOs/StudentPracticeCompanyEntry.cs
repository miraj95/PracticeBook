using PB.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticeBook.DTOs
{
    public class StudentPracticeCompanyEntry
    {

        [Required]
        public string PracticeCompanies { get; set; }
    }
}