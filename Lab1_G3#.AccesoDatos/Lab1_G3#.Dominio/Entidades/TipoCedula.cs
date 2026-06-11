using System;
using System.Collections.Generic;

namespace Lab1_G3.Dominio;

public partial class TipoCedula
{
    public int TipoCedula1 { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<SegUsuario> SegUsuarios { get; set; } = new List<SegUsuario>();
}
