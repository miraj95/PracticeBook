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
            this.Practice = practice;
            this.Company = company;
            this.Capacity = capacity;
        }
        [Key]
        public string Id { get; set; }
        [Required]
        public string Practice { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public int Capacity { get; set; }

        public List<Practice> PracticeCollection { get; set; }
        public List<Company> CompanyCollection { get; set; }
    }
}
