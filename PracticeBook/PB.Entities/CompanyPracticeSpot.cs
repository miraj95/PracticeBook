using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Entities
{
    class CompanyPracticeSpot
    {
        public CompanyPracticeSpot(Company company, Practice practice)
        {
            this.companyId = company.Id;
            this.practiceId = practice.Id;
        }

        public int Capacity { get; set; }
        public String Id { get; set; }
        public String companyId { get; set; }
        public String practiceId { get; set; }
    }
}
