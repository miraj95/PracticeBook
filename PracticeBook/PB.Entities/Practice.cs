using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PB.Common;

namespace PB.Entities
{
    public class Practice
    {
        public Practice()
        {
        }

        public Practice(CustomId id)
        {
            this.Id = string.IsNullOrEmpty(Convert.ToString(id)) ? new CustomId().ToString() : id.ToString();
        }

        public Practice(string name, DateTime startDate, DateTime endDate, CustomId id = null) : this(id)
        {
            this.Name = name;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        [Key]
        public string Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
