﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Postgress
{
    public class UsuarioPostGress
    {
        public int? id { get; set; }
        public string? email { get; set; }
        public object? apodos { get; set; }
        public imagen? imagenusuario { get; set; }

    }
    public class imagen
    {
        public string? imgbase { get; set; }
        public string? cabezera { get; set; }
    }

    public class inventario
    {
        public int? id { get; set; }
        public string? codigo { get; set; }

        public string? nombre { get; set; }

        public Proveedor? proveedor { get; set; }
    }
    public class Proveedor
    {
        public string? nombreprov { get; set; }
        public string? pais { get; set; }
        public string? cif { get; set; }
        public string? volumencompra { get; set; }
    }
}
