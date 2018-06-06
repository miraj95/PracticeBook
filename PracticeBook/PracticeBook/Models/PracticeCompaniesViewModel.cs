using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeBook.Models
{
    public class PracticeCompaniesViewModel
    {
        public string Id { get; set; }
        public IEnumerable<SelectListItem> Practice { get; set; }
        public IEnumerable<SelectListItem> Company { get; set; }
    }
}