using System;

namespace Application.DTOs
{
    public class ProyectoDTO
    {
        public Guid ProId { get; set; }
        public string ProdNom { get; set; }
        public string ProdDesc { get; set; }
        public DateTime? ProdFecha { get; set; }
        public string ProdUrl { get; set; }
    }
}
