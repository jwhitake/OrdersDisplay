using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrdersDisplay.Domain
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        [MaxLength(25)]
        public string Type { get; set; }
        [Required]
        public string Entry { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
