﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AmazEng_WAPP.Models
{
    public class Feedback : ICustomSoftDelete
    {
        [Key, Required]
        public int Id { get; set; }
        public int IdiomId { get; set; }
        [Required]
        [StringLength(50)]
        public string IssuerName { get; set; }
        [Required]
        [StringLength(50)]
        public string IssuerEmail { get; set; }
        [Required]
        public DateTime SentAt { get; set; }
        [Required]
        [StringLength(3000)]
        public string Content { get; set; }
        public DateTime? DeletedAt { get; set; }


        public virtual Idiom Idiom { get; set; }
    }
}