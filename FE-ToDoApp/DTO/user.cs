using System;

namespace FE_ToDoApp.DTO
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
        public byte[] Avatar { get; set; }
    }
}