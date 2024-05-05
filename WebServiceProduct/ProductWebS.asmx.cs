using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebServiceProduct.Dto;

namespace WebServiceProduct
{
    /// <summary>
    /// Descripción breve de ProductWebS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ProductWebS : System.Web.Services.WebService
    {

        RegistroEntities db = new RegistroEntities();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public List<Producto> GetProducts()
        {
            return db.Producto.ToList();
        }




        [WebMethod]
        public Producto GetProductosDto(string code)
        {
            return db.Producto.Find(code);
        }
        /*-----------------------------------------------------------------*/
        [WebMethod]
        public Producto GetProductosByName(string name)
        {
           var producto = db.Producto.FirstOrDefault(p => p.nombre == name);
            if (producto != null)
            {
                var productDto = new ProductoDto
                {
                    codigo = producto.codigo,
                    nombre = producto.nombre,
                    descripcion = producto.descripcion,
                    costo = producto.costo,
                    margen = producto.margen
                };

                return producto;

            }
            else
            {

                return null;
            }
        }
        /*----------------------------------------------------------------------------------------*/


        [WebMethod]
        public Producto GetProductosByPrice(string price)
        {
            var producto = db.Producto.FirstOrDefault(p => p.costo == price);
            if (producto != null)
            {
                var productDto = new ProductoDto
                {
                    codigo = producto.codigo,
                    nombre = producto.nombre,
                    descripcion = producto.descripcion,
                    costo = producto.costo,
                    margen = producto.margen
                };

                return producto;

            }
            else
            {

                return null;
            }
        }
        /*-------------------------------------------------------------------------------*/

        [WebMethod]
        public Producto GetProductosByMargin(string margin)
        {
            var producto = db.Producto.FirstOrDefault(p => p.margen == margin);
            if (producto != null)
            {
                var productDto = new ProductoDto
                {
                    codigo = producto.codigo,
                    nombre = producto.nombre,
                    descripcion = producto.descripcion,
                    costo = producto.costo,
                    margen = producto.margen
                };

                return producto;

            }
            else
            {

                return null;
            }
        }


        /*----------------------------------------------------------------------------------------*/


       
        /*-------------------------------------------------------------------------------*/

        /*----------------------------------------------------------------------------------*/
        [WebMethod]
        public Producto UpdateProductosDto(string codigo, string nombre, string descripcion, string cantidad, string margen, string costo)
        {
            var p = db.Producto.Find(codigo);
            if (p != null)
            {
                /* Producto producto = new Producto     ();*/
                p.codigo = codigo;
                p.nombre = nombre;
                p.descripcion = descripcion;
                p.cantidad = cantidad;
                p.costo = costo;
                p.margen = margen;
                db.SaveChanges();

            }
            return p;

        }



        [WebMethod]
        public ProductoDto UpdateProductosDtoObjectos(ProductoDto productoDto)
        {
            /*var name = productoDto.nombre;
            return productoDto;*/

            var p = db.Producto.Find(productoDto.codigo);
            if (p != null)
            {
                /* Producto producto = new Producto     ();*/
                p.codigo = productoDto.codigo;
                p.nombre = productoDto.nombre;
                p.descripcion = productoDto.descripcion;
                p.cantidad = productoDto.cantidad;
                p.costo = productoDto.costo;
                p.margen = productoDto.margen;
                db.SaveChanges();

            }
            return new ProductoDto
            {
                codigo = p.codigo,
                nombre = p.nombre,
                descripcion = p.descripcion,
                cantidad = p.cantidad,
                costo = p.costo,
                margen = p.margen



            };


        }
    }
}

        
    
