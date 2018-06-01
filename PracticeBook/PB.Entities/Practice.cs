using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Entities
{
    class Practice
    {
        public Practice(string id, string name, DateTime startDate, int duration)
        {
            this.Id = id;
            this.Name = name;
            this.StartDate = startDate;
            this.Duration = duration;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
    }
}
