using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JostonPortfolioProject.Models.ViewModel
{
    public class ViewModelClasses
    {
        public IEnumerable<Gallery> Gallery { get; set; }
        public IEnumerable<About> About { get; set; }
        public IEnumerable<Event> Event { get; set; }
        public Contact Contact { get; set; }

    }
}