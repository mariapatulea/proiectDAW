using System;
using System.ComponentModel.DataAnnotations;

namespace proiectDAW.Models.Entities
{
    public class SessionToken
    {
        public SessionToken() { }
        public SessionToken(string jti, int userId, DateTime expirationDate)
        {
            this.UserId = userId;
            this.ExpirationDate = expirationDate;
            this.Jti = jti;
        }

        [Key]
        public string Jti { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
