using System;
using System.Collections.Generic;

#nullable disable

namespace parcialAPI.Models
{
    public partial class Raza
    {
        public Raza()
        {
            Animales = new HashSet<Animale>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Animale> Animales { get; set; }
    }
}
