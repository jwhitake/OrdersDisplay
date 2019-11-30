using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrdersDisplay.Domain
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string LoginName { get; set; }
        [Required]
        [MaxLength(256)]
        public string Password { get; private set; }
        [Required]
        [MaxLength(256)]
        private string Salt { get; set; }
        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }



        public User SetUserPassword(string password)
        {
            this.Password = password;
            return this;
        }

        public User SetUserSalt(string salt)
        {
            this.Salt = salt;
            return this;
        }

        public string GetSaltProperty() => this.Salt;
        

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
