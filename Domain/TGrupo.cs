﻿using System;
using System.Collections.Generic;

namespace CodiJobServices.Domain
{
    public partial class TGrupo
    {
        public TGrupo()
        {
            TUsuariogrupo = new HashSet<TUsuariogrupo>();
        }

        public Guid GrupoId { get; set; }
        public string GrupoNom { get; set; }
        public string GrupoFoto { get; set; }
        public string GrupoProm { get; set; }

        public ICollection<TUsuariogrupo> TUsuariogrupo { get; set; }
    }
}
