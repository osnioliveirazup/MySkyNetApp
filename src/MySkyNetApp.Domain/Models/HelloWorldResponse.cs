using System;

namespace MySkyNetApp.Domain.Models
{
    public class HelloWorldResponse
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public int Level { get; set; }
    }
}