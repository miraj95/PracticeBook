using PB.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Entities
{
    public class PracticeCompany
    {
        public PracticeCompany()
        {

        }

        public PracticeCompany(CustomId id)
        {
            this.Id = string.IsNullOrEmpty(Convert.ToString(id)) ? new CustomId().ToString() : id.ToString();
        }


        public PracticeCompany(string practice, string company, int capacity, CustomId id = null)
            :this(id)
        {
            this.PracticeId = practice;
            this.CompanyId = company;
            this.Capacity = capacity;
        }

        [Key]
        public string Id { get; set; }
        [Required]
        public string PracticeId { get; set; }
        [Required]
        public string CompanyId { get; set; }
        [Required]
        public int Capacity { get; set; }

    }
}
