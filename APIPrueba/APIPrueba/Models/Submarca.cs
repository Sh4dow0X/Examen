using System;
using System.Collections.Generic;

namespace APIPrueba.Models
{
    public partial class Submarca
    {
        public Submarca()
        {
            Modelos = new HashSet<Modelo>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int? IdMarca { get; set; }

        public virtual Marca? IdMarcaNavigation { get; set; }
        public virtual ICollection<Modelo> Modelos { get; set; }
    }
}
