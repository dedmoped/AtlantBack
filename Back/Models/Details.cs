using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Models
{
    public class Details
    {
        public int Id { get; set; }
        [Required]
        public string nunCode { get; set; }
        [Required]
        public string name { get; set; }
        public int? sum { get; set; }
        public int storeKeeperId { get; set; }
        public StoreKeeper storeKeeper { get; set; }
        [NotMapped]
        public string storeKepeerName { get; set; }
        [Required]
        public DateTime dateCreated { get; set; }
        public DateTime? dateDeleted { get; set; }
    }
}
