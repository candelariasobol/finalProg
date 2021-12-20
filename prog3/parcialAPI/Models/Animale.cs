using System;
using System.Collections.Generic;

#nullable disable

namespace parcialAPI.Models
{
    public partial class Animale
    {
        public int Id { get; set; }
        public int TipoAnimal { get; set; }
        public string NombrePerro { get; set; }
        public int IdRaza { get; set; }
        public int Edad { get; set; }
        public double Peso { get; set; }
        public string NombreYapeDueno { get; set; }
        public string Telefono { get; set; }

        public virtual Raza IdRazaNavigation { get; set; }
    }
}
