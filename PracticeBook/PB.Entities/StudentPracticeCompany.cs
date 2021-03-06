﻿using PB.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Entities
{
    public class StudentPracticeCompany
    {
        public StudentPracticeCompany()
        {
        }

        public StudentPracticeCompany(CustomId id)
        {
            this.Id = string.IsNullOrEmpty(Convert.ToString(id)) ? new CustomId().ToString() : id.ToString();
        }

        public StudentPracticeCompany(string practiceCompanies, /*string userId,*/ CustomId id = null)
            : this(id)
        {
            this.PracticeCompanies = practiceCompanies;
            //this.UserId = userId;
        }

        [Key]
        public string Id { get; set; }
        [Required]
        public string PracticeCompanies { get; set; }
        //[Required]
        //public string UserId { get; set; }
    }
}
