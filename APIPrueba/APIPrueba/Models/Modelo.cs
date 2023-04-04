using System;
using System.Collections.Generic;

namespace APIPrueba.Models
{
    public partial class Modelo
    {
        public Modelo()
        {
            Descripcions = new HashSet<Descripcion>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int? IdSubmarca { get; set; }

        public virtual Submarca? IdSubmarcaNavigation { get; set; }
        public virtual ICollection<Descripcion> Descripcions { get; set; }
    }
}
