﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace smartTechAuthenticator.Models
{
    public class MultipleChoiceResponce
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid FormPropertyResponceId { get; set; }
        public Guid DropdownId { get; set; }
        public bool ChoiceValue { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}