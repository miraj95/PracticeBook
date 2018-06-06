using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Entities
{
    class PracticeCompany
    {
        public PracticeCompany()
        {

        }

        [Key]
        public string Id { get; set; }
        [Required]
        public string PracticeId { get; set; }
        [Required]
        public string PracticeName { get; set; }
        [Required]
        public string CompanyId { get; set; }

    }
}
