using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OrdersDisplay.Domain
{
    public class UserGroup
    {
        [Key]
        public int Id { get; set; }        
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public User User { get; set; }
        public Group Group { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
