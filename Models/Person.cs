using System;

namespace Shuttle.Models
{

    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JobTitle { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int FavoriteNumber { get; set; }
    }

}