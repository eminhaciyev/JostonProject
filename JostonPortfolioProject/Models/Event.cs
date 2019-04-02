using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JostonPortfolioProject.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required,StringLength(50)]
        public string Title { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required, StringLength(50)]
        public string SubTitle { get; set; }

        [Required, StringLength(50)]
        public string Hours { get; set; }

        [Required, StringLength(50)]
        public string HowManyPhoto { get; set; }

        [Required, StringLength(50)]
        public string Content { get; set; }
    }
}