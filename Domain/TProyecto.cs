using System;
using System.Collections.Generic;

namespace CodiJobServices.Domain
{
    public partial class TProyecto
    {
        public TProyecto()
        {
            TUsuarioproyecto = new HashSet<TUsuarioproyecto>();
        }

        public Guid ProId { get; set; }
        public string ProdNom { get; set; }
        public string ProdDesc { get; set; }
        public DateTime? ProdFecha { get; set; }
        public string ProdUrl { get; set; }

        public ICollection<TUsuarioproyecto> TUsuarioproyecto { get; set; }
    }
}
