using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JostonPortfolioProject.Models
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required,StringLength(100)]
        public string Name { get; set; }

        [EmailAddress]
        [Required, StringLength(100)]
        public string Email { get; set; }

        [Required, StringLength(1000)]
        public string Message { get; set; }

    }
}