﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Models
{
    public class StoreKeeper
    {
        public int Id { get; set; }
        [Required]
        public string FullName{get;set;}
    }
}
