using System;
using System.Collections.Generic;

namespace APIPrueba.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Submarcas = new HashSet<Submarca>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Submarca> Submarcas { get; set; }
    }
}
