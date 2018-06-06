using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticeBook.DTOs
{
    public class PracticeEntry
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        //[StringLength(50)]
        public DateTime StartDate { get; set; }

        [Required]
        //[StringLength(50)]
        public DateTime EndDate { get; set; }

        //public DateTime GetStartDate()
        //{
        //    return DateTime.ParseExact(this.StartDate, "dd/mm/yyyy", null);
        //}

        //public DateTime GetEndDate()
        //{
        //    return DateTime.ParseExact(this.EndDate, "dd/mm/yyyy", null);
        //}
    }
}