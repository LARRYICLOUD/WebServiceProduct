﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceProduct.Dto
{
    public class ProductoDto
    {
        public string codigo { get; set; }
        public string nombre{ get; set; }
        public string descripcion{ get; set; }
        public string cantidad{ get; set; }
        public string costo{ get; set; }
        public string margen{ get; set; }
        
    }
}