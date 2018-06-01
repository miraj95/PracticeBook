using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Entities
{
    class Company
    {
        public Company(string id, string name, string userId)
        {
            this.Id = id;
            this.Name = name;
            this.UserId = userId;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
    }
}
