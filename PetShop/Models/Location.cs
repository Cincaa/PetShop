using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetShop.Models
{
    public class Location
    {
        public int Id { get; set; }
        public Adress Adress { get; set; }
    } }