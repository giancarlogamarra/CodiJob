using System;
using System.Collections.Generic;

namespace CodiJobServices.Domain
{
    public partial class TUsuarioproyecto
    {
        public Guid UsuproId { get; set; }
        public Guid UsuId { get; set; }
        public Guid ProId { get; set; }

        public TProyecto Pro { get; set; }
        public TUsuarioperfil Usu { get; set; }
    }
}
