﻿using PB.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Entities
{
    public class Company
    {
        public Company()
        {
        }

        public Company(CustomId id)
        {
            this.Id = string.IsNullOrEmpty(Convert.ToString(id)) ? new CustomId().ToString() : id.ToString();
        }

        public Company(string name, int capacity, string practiceId, CustomId id = null)
            :this(id)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.PracticeId = practiceId;
        }

        public Company(string name, int capacity, CustomId id = null)
            : this(id)
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Capacity { get; set; }
        public string PracticeId { get; set; }
    }
}
