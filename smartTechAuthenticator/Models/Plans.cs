using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace smartTechAuthenticator.Models
{
    public class Plans
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string PlanName { get; set; }
        public string Price { get; set; }
        public string Validity { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}