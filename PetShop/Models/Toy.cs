﻿namespace PetShop.Models
{
    public class Toy
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public virtual Hamster hamster { get; set; }

    }
}