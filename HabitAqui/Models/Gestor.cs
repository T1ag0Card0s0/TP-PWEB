﻿namespace HabitAqui.Models
{
    public class Gestor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Locador>? Locadores { get; set; }
        public ICollection<Estado>? Estados { get; set; }
    }
}
