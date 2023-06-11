using Backend.dataAccess;
using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Web.UI;
using Backend.Entities.AtributosProductos;
using Backend.Entities.Response.Productos;

namespace Backend.Logic
{
    public class logProductos
    {
       
        public ResIngresarProducto crearProducto(ReqIngresarProducto req)
        {
            ResIngresarProducto res = new ResIngresarProducto();
            res.listaMensajesOErrores = new List<string>();
            try
            {
                if (req == null || req.elProducto == null)
                {

                    res.listaMensajesOErrores.Add("Request faltante");
                    res.result = false;
                }
                else if (Convert.ToDecimal(req.elProducto.precio) ==0)
                {
                    res.listaMensajesOErrores.Add("Precio de producto faltante");
                    res.result = false;
                }
                else if (req.elProducto.idCategoria==0)
                {

                    res.listaMensajesOErrores.Add("Categoria de producto faltante");
                    res.result = false;
                }

                else if (req.elProducto.cantidadProductos == 0)
                {
                    res.listaMensajesOErrores.Add("Cantidad de producto faltante");
                    res.result = false;
                }
                else if (String.IsNullOrEmpty(req.elProducto.nombre))
                {
                    res.listaMensajesOErrores.Add("Nombre de producto faltante");
                    res.result = false;
                }
               
                else
                {
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    int? errorId = 0;
                    laConexion.SP_AgregarProductos (Convert.ToDecimal(req.elProducto.precio), req.elProducto.idCategoria, req.elProducto.cantidadProductos, req.elProducto.nombre, ref errorId);
                    if (errorId == 0)
                    {
                        res.listaMensajesOErrores.Add("Has creado un nuevo producto de forma exitosa!");
                        res.result = true;
                    }
                    else if (errorId == 2) 
                    {
                        res.listaMensajesOErrores.Add("No existe ese ID de Categoria, intente con otro.");
                        res.result = false;
                    }
                    else if (errorId == 1)
                    {
                        res.listaMensajesOErrores.Add("Producto ya existe, intente con otro.");
                        res.result = false;
                    }
                    
                }

            }
            catch (Exception ex)
            {

                res.listaMensajesOErrores.Add("Error al procesar la solicitud de crear producto" + ex.Message);
                res.result = false;

            }
            return res;
        }

        //listar todos los productos
        public ResObtenerTodosProductos obtenerTodosProductos(ReqObtenerTodosProductos req)
        {
            ResObtenerTodosProductos res = new ResObtenerTodosProductos();
            try
            {

                conexionLinqDataContext laConexion = new conexionLinqDataContext();
                List<SP_ListaProductosResult> result = laConexion.SP_ListaProductos().ToList();
                if (result.Count != 0)
                {
                    res.listaTodosProductos = new List<productosObtenerTodos>();
                    res.listaTodosProductos = this.armarListadoProductos(result);

                    res.result = true;
                }
                else
                {
                    res.listaMensajesOErrores = new List<string>();
                    res.listaMensajesOErrores.Add("No hay productos");
                    res.result = false;
                }


            }
            catch (Exception ex)
            {
                res.listaMensajesOErrores = new List<string>();
                res.listaMensajesOErrores.Add("Error al procesar la solicitud de obtener todos los productos" + ex.Message);
                res.result = false;
            }
            return res;
        }
        //listado para el metodo de obtener todos los productos
        private List<productosObtenerTodos> armarListadoProductos(List<SP_ListaProductosResult> allUsersListLinq)
        {
            List<productosObtenerTodos> allUsersListArmada = new List<productosObtenerTodos>();
            foreach (SP_ListaProductosResult elementoLinq in allUsersListLinq)
            {
                productosObtenerTodos listaProductos = new productosObtenerTodos();
                listaProductos.idProducto = elementoLinq.idProducto;
                listaProductos.precio = (float)elementoLinq.precio;
                listaProductos.idCategoria = elementoLinq.idCategoria;
                listaProductos.cantidadProductos = (float)elementoLinq.cantidadProductos;
                listaProductos.nombre = elementoLinq.nombre;
                allUsersListArmada.Add(listaProductos);
            }
            return allUsersListArmada;
        }

        //metodo para actualizar un producto en especifico
        public ResActualizarProducto actualizarProducto(ReqActualizarProducto req)
        {
            ResActualizarProducto res = new ResActualizarProducto();
            try
            {
                res.listaMensajesOErrores = new List<string>();
                // Validar datos
                if (req.elProducto.idProducto == 0)
                {

                    res.listaMensajesOErrores.Add("Id de Producto Faltante");
                    res.result = false;

                }

                else if (Convert.ToDecimal(req.elProducto.precio) == 0)
                {

                    res.listaMensajesOErrores.Add("Precio de Producto Faltante");
                    res.result = false;
                }

                else if (req.elProducto.idCategoria==0)
                {
                    res.listaMensajesOErrores.Add("idCategoria Peroducto Faltante");
                    res.result = false;
                }

                else if (Convert.ToDecimal(req.elProducto.cantidadProductos) == 0)
                {
                    res.listaMensajesOErrores.Add("Cantidad de Producto faltante");
                    res.result = false;
                }
               
                else if (string.IsNullOrEmpty(req.elProducto.nombre))
                {
                    res.listaMensajesOErrores.Add("Nombre de Producto Faltante");
                    res.result = false;
                }
                
                else
                {
                    // Conectar a la base de datos
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    // Ejecutar el procedimiento almacenado
                    int? errorId = 0;
                    laConexion.SP_ActualizarProductos(req.elProducto.idProducto, Convert.ToDecimal(req.elProducto.precio), req.elProducto.idCategoria, req.elProducto.cantidadProductos, req.elProducto.nombre, ref errorId);
                    if (errorId == 0) 
                    {
                        res.listaMensajesOErrores.Add("Has actualizado un producto de forma exitosa!");
                        res.result = true;
                    }
                    else if (errorId == 1) 
                    {
                        res.listaMensajesOErrores.Add("Id de Producto no existe.");
                        res.result = false;
                    }
                    else if (errorId == 2) 
                    {
                        res.listaMensajesOErrores.Add("ID de Categoria de producto no existe.");
                        res.result = false;
                    }
                    
                    

                }
            }
            catch (Exception ex)
            {
                res.listaMensajesOErrores = new List<string>();
                res.listaMensajesOErrores.Add("Error al procesar la solicitud de actualizar producto" + ex.Message);
                res.result = false;

            }
            return res;
        }
        //metodo para obtener solo un producto
        public ResObtenerProducto obtenerUnProducto(ReqObtenerProducto req)
        {
            ResObtenerProducto res = new ResObtenerProducto();
            try
            {
                if (req.idProducto
                    == 0)
                {
                    res.listaMensajesOErrores = new List<string>();
                    res.listaMensajesOErrores.Add("No se envio el ID para obtener un Producto");
                    res.result = false;
                }
                else
                {
                    // Conectar a la base de datos
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    // Ejecutar el procedimiento almacenado
                    int? errorId = 0;
                    List<SP_ListaProductoResult> result = laConexion.SP_ListaProducto(req.idProducto, ref errorId).ToList();
                    if (result.Count != 0 && errorId == 0)

                    {
                        res.elProducto = new productosObtenerUno()
                        {
                            idProducto = result[0].idProducto,
                            nombre = result[0].nombre,
                            precio= (float)result[0].precio,
                            idCategoria= result[0].idCategoria,
                            descripcion = result[0].descripcion,

                         };

                        res.result = true;
                        res.listaMensajesOErrores.Add("Has encontrado un producto con el id: " + req.idProducto);

                    }

                    else if (errorId == 1)
                    {
                        //res.elUsuario = null;
                        res.listaMensajesOErrores = new List<string>();
                        res.listaMensajesOErrores.Add("Id de Producto no existe.");
                        res.result = false;
                    }
                }
            }
            catch (Exception ex)
            {
                //se quito la lista de errores porque aunque diera resultado, tambien daba al catch.
                //res.listaMensajesOErrores = new List<string>();
                // res.listaMensajesOErrores.Add("Error al procesar la solicitud de obtener un usuario" + ex.Message);
                // res.result = false;
            }
            return res;
        }

        public ResEliminarProducto eliminarProducto(ReqEliminarProducto req)
        {
            ResEliminarProducto res = new ResEliminarProducto();
            res.listaMensajesOErrores = new List<string>();
            try
            {
                if (req.idProducto == 0)
                {
                    res.listaMensajesOErrores = new List<string>();
                    res.listaMensajesOErrores.Add("No se envio el id");
                    res.result = false;
                }
                else
                {
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    int? errorId = 0;
                    laConexion.SP_EliminarProductos(req.idProducto, ref errorId);
                    if (errorId == 0) 
                    {
                        res.listaMensajesOErrores.Add("Producto eliminado con éxito!");
                        res.result = true;
                    }
                    else if (errorId == 1) 
                    {
                        res.listaMensajesOErrores.Add("Producto no existe, no se puede eliminar");
                        res.result = false;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                res.listaMensajesOErrores = new List<string>();
                res.listaMensajesOErrores.Add(ex.Message);
                res.result = false;
            }
            return res;

        }



    }
}