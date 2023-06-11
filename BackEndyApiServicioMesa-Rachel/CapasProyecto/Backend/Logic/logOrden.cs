using Backend.dataAccess;
using Backend.Entities.AtributosProductos;
using Backend.Entities.Response.Productos;
using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Backend.Logic
{
    public class logOrden
    {
        public ResIngresarOrden crearOrden(ReqIngresarOrden req)
            // agregar metodo que valide si existe id mesa, que si no tire error, y que valide id usuario, sino tire error
        {
            ResIngresarOrden res = new ResIngresarOrden();
            res.listaMensajesOErrores = new List<string>();
            try
            {
                if (req == null || req.laOrden == null)
                {

                    res.listaMensajesOErrores.Add("Request faltante");
                    res.result = false;
                }
                else if (req.laOrden.idMesa == 0)
                {
                    res.listaMensajesOErrores.Add("Id de Mesa faltante");
                    res.result = false;
                }
                else if (req.laOrden.idUsuario == 0)
                {

                    res.listaMensajesOErrores.Add("Id de Usuario faltante");
                    res.result = false;
                }

                else
                {
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    int? errorId = 0;
                    int orderID = 0;
                    var result = laConexion.PA_CrearOrden(req.laOrden.idMesa, req.laOrden.idUsuario, ref errorId);
                    if (errorId == 0)
                    {
                        var firstResult = result.First();
                        orderID = (int)firstResult.OrderID;
                        res.orderID = orderID;
                        res.listaMensajesOErrores.Add("Has creado una nueva orden de forma exitosa!");
                        res.result = true;

                    }
                    else if (errorId == 2)
                    {
                        res.listaMensajesOErrores.Add("El ID de Mesa no existe o está ocupada, no se pudo crear la orden.");
                        res.result = false;
                    }
                    else if (errorId == 1) 
                    {
                        res.listaMensajesOErrores.Add("El ID de Usuario no existe, no se pudo crear la orden.");
                        res.result = false;
                    }

                }

            }
            catch (Exception ex)
            {

                res.listaMensajesOErrores.Add("Error al procesar la solicitud de crear Orden" + ex.Message);
                res.result = false;

            }
            return res;
        }

        //listar todas las ordenes
        public ResObtenerTodasOrdenes obtenerTodasOrdenes(ReqObtenerTodasOrdenes req)
        {
            ResObtenerTodasOrdenes res = new ResObtenerTodasOrdenes();
            try
            {

                conexionLinqDataContext laConexion = new conexionLinqDataContext();
                List<SP_ListarOrdenesResult> result = laConexion.SP_ListarOrdenes().ToList();
                if (result.Count != 0)
                {
                    res.listaTodasOrdenes = new List<ordenObtenerTodas>();
                    res.listaTodasOrdenes = this.armarListadoOrdenes(result);

                    res.result = true;
                }
                else
                {
                    res.listaMensajesOErrores = new List<string>();
                    res.listaMensajesOErrores.Add("No hay ordenes");
                    res.result = false;
                }


            }
            catch (Exception ex)
            {
                res.listaMensajesOErrores = new List<string>();
                res.listaMensajesOErrores.Add("Error al procesar la solicitud de obtener todas las ordenes" + ex.Message);
                res.result = false;
            }
            return res;
        }
        //listado para el metodo de obtener todas las ordenes
        private List<ordenObtenerTodas> armarListadoOrdenes(List<SP_ListarOrdenesResult> allOrdenesListLinq)
        {
            List<ordenObtenerTodas> allOrdenesListaArmada = new List<ordenObtenerTodas>();
            foreach (SP_ListarOrdenesResult elementoLinq in allOrdenesListLinq)
            {
                ordenObtenerTodas listaOrdenes = new ordenObtenerTodas();
                listaOrdenes.idOrden = elementoLinq.idOrden;
                listaOrdenes.nombreMesa = elementoLinq.nombreMesa;  

                allOrdenesListaArmada.Add(listaOrdenes);
            }
            return allOrdenesListaArmada;
        }

        //metodo para actualizar una orden en especifico
        public ResActualizarOrden actualizarOrden(ReqActualizarOrden req)
        {
            ResActualizarOrden res = new ResActualizarOrden();
            try
            {
                res.listaMensajesOErrores = new List<string>();
                // Validar datos
                if (req == null)
                {

                    res.listaMensajesOErrores.Add("Request faltante");
                    res.result = false;
                }
                else if (req.laOrden.idOrden == 0)
                {
                    res.listaMensajesOErrores.Add("Id de Orden faltante");
                    res.result = false;
                }
                else if (req.laOrden.idMesa == 0)
                {

                    res.listaMensajesOErrores.Add("Id de Mesa faltante");
                    res.result = false;
                }
                else if (req.laOrden.idUsuario == 0)
                {
                    res.listaMensajesOErrores.Add("Id de Usuario faltante");
                    res.result = false;
                }

                else
                {
                    // Conectar a la base de datos
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    // Ejecutar el procedimiento almacenado
                    int? errorId = 0;
                    laConexion.PA_ActualizarOrden(req.laOrden.idOrden, req.laOrden.idMesa, req.laOrden.idUsuario, ref errorId);
                    if (errorId == 0)
                    {
                        res.listaMensajesOErrores.Add("Has actualizado una orden de forma exitosa!");
                        res.result = true;

                    }
                    else if (errorId == 4)
                    {
                        res.listaMensajesOErrores.Add("Id de Orden no existe o ya no está activa.");
                        res.result = false;
                    }
                    else if (errorId == 3)
                    {
                        res.listaMensajesOErrores.Add("Id de Mesa no existe, intente con otra.");
                        res.result = false;
                    }
                    else if (errorId == 2)
                    {
                        res.listaMensajesOErrores.Add("Id de Usuario no existe, intente con otro.");
                        res.result = false;
                    }
                    else if(errorId == 1) 
                    {
                        res.listaMensajesOErrores.Add("Mesa ya está ocupada, intente con otra.");
                        res.result = false;
                    }

                }
            }
            catch (Exception ex)
            {
                res.listaMensajesOErrores = new List<string>();
                res.listaMensajesOErrores.Add("Error al procesar la solicitud de actualizar una orden" + ex.Message);
                res.result = false;

            }
            return res;
        }
        //metodo para obtener solo una orden
        public ResObtenerOrden obtenerUnaOrden(ReqObtenerOrden req)
        {
            ResObtenerOrden res = new ResObtenerOrden();
            try
            {

                if (req == null)
                {

                    res.listaMensajesOErrores.Add("Request faltante");
                    res.result = false;
                }
                else if (req.idOrden == 0)
                {
                    res.listaMensajesOErrores = new List<string>();
                    res.listaMensajesOErrores.Add("No se envió el Id de Orden para obtener una orden.");
                    res.result = false;
                }
                else
                {
                    // Conectar a la base de datos
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    // Ejecutar el procedimiento almacenado
                    int? errorId = 0;
                    List<SP_ListarOrdenResult> result = laConexion.SP_ListarOrden(req.idOrden, ref errorId).ToList();
                    if (result.Count != 0 && errorId == 0)

                    {
                        res.laOrden = new ordenObtenerUna()
                        {
                            idOrden = result[0].idOrden,
                            montoOrden = (float)result[0].montoOrden

                        };

                        res.result = true;
                        res.listaMensajesOErrores.Add("Has encontrado una orden con el id: " + req.idOrden);

                    }

                    else if(errorId == 1)
                    {
      
                        res.listaMensajesOErrores = new List<string>();
                        res.listaMensajesOErrores.Add("No has encontrado una orden con este ID.");
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
        //eliminar una orden
        public ResEliminarOrden eliminarOrden(ReqEliminarOrden req)
        {
            ResEliminarOrden res = new ResEliminarOrden();
            res.listaMensajesOErrores = new List<string>();
            try
            {
                if (req == null)
                {

                    res.listaMensajesOErrores.Add("Request faltante");
                    res.result = false;
                }
                else if (req.idOrden == 0)
                {
                    res.listaMensajesOErrores = new List<string>();
                    res.listaMensajesOErrores.Add("No se envio el id de orden");
                    res.result = false;
                }
                else if (req.idMesa == 0)
                {
                    res.listaMensajesOErrores = new List<string>();
                    res.listaMensajesOErrores.Add("No se envio el id de orden");
                    res.result = false;
                }
                else
                {
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    int? errorId = 0;
                    laConexion.PA_EliminarOrden(req.idOrden, ref errorId);

                    if (errorId == 0)
                    {
                        res.result = true;
                        res.listaMensajesOErrores.Add("Has eliminado la orden con éxito!");
                    }
                    else if (errorId == 1)
                    {
                        res.listaMensajesOErrores = new List<string>();
                        res.listaMensajesOErrores.Add("ID de Orden no existe, no se pudo eliminar la orden.");
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

        //public ResObtenerProductosOrden obtenerProductosOrden(ReqObtenerProductosOrden req)
        //{
        //    ResObtenerProductosOrden res = new ResObtenerProductosOrden();
        //    try
        //    {

        //        if (req == null)
        //        {

        //            res.listaMensajesOErrores.Add("Request faltante");
        //            res.result = false;
        //        }
        //        else if (req.idOrden == 0)
        //        {
        //            res.listaMensajesOErrores = new List<string>();
        //            res.listaMensajesOErrores.Add("No se envio el Id de Orden para obtener los productos de la orden");
        //            res.result = false;
        //        }
        //        else
        //        {
        //            // Conectar a la base de datos
        //            conexionLinqDataContext laConexion = new conexionLinqDataContext();
        //            // Ejecutar el procedimiento almacenado
        //            int? errorId = 0;
        //            List<SP_ListaProductosOrdenResult> result = laConexion.SP_ListaProductosOrden(req.idOrden, ref errorId).ToList();
        //            if (result.Count != 0 && errorId == 0)

        //            {
        //                res.elProductoyOrden = new ordenObtenerProductos()
        //                {
        //                    idOrden = result[0].idOrden,
        //                    idProducto = result[0].idProducto,
        //                    nombre = result[0].nombre,
        //                    precio = (double)result[0].precio,
        //                    idCategoria = result[0].idCategoria,
        //                    cantidad = result[0].cantidad

        //                };

        //                res.result = true;
        //                res.listaMensajesOErrores.Add("Has encontrado los productos de la orden, con el id: " + req.idOrden);

        //            }

        //            else if (errorId == 1)
        //            {

        //                res.listaMensajesOErrores = new List<string>();
        //                res.listaMensajesOErrores.Add("No has encontrado productos en una orden con este id");
        //                res.result = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //se quito la lista de errores porque aunque diera resultado, tambien daba al catch.
        //        //res.listaMensajesOErrores = new List<string>();
        //        // res.listaMensajesOErrores.Add("Error al procesar la solicitud de obtener un usuario" + ex.Message);
        //        // res.result = false;
        //    }
        //    return res;
        //}

        public ResObtenerProductosOrden obtenerProductosOrden(ReqObtenerProductosOrden req)
        {
            ResObtenerProductosOrden res = new ResObtenerProductosOrden();
            res.listaMensajesOErrores = new List<string>();


            try
            {

                conexionLinqDataContext laConexion = new conexionLinqDataContext();
                int? errorId = 0;
                List<SP_ListaProductosOrdenResult> result = laConexion.SP_ListaProductosOrden(req.idOrden, ref errorId).ToList();
                if (result.Count != 0 && errorId == 0)
                {
                    res.listaTodosProductosOrden = new List<ordenObtenerProductos>();
                    res.listaTodosProductosOrden = this.armarListadoProductosOrden(result);
                    res.listaMensajesOErrores.Add("Se pudo localizar los productos asociados a este ID de Orden!");
                    res.result = true;
                }
                else if (errorId == 1)
                {
                    res.listaMensajesOErrores = new List<string>();
                    res.listaMensajesOErrores.Add("ID de Orden no existe, intente con otro.");
                    res.result = false;
                }


            }
            catch (Exception ex)
            {
                res.listaMensajesOErrores = new List<string>();
                res.listaMensajesOErrores.Add("Error al procesar la solicitud de obtener productos de la orden: " + ex.Message);
                res.result = false;
            }
            return res;
        }
        //listado para el metodo de obtener todas las ordenes
        private List<ordenObtenerProductos> armarListadoProductosOrden(List<SP_ListaProductosOrdenResult> allProductosOrdenListLinq)
        {
            List<ordenObtenerProductos> allProductosOrdenListaArmada = new List<ordenObtenerProductos>();
            foreach (SP_ListaProductosOrdenResult elementoLinq in allProductosOrdenListLinq)
            {
                ordenObtenerProductos listaProductosOrden = new ordenObtenerProductos();
                listaProductosOrden.idOrden = elementoLinq.idOrden;
                listaProductosOrden.idProducto = elementoLinq.idProducto;
                listaProductosOrden.nombre = elementoLinq.nombre;
                listaProductosOrden.precio = (double)elementoLinq.precio;
                listaProductosOrden.idCategoria = elementoLinq.idCategoria;
                listaProductosOrden.cantidad = elementoLinq.cantidad;

                allProductosOrdenListaArmada.Add(listaProductosOrden);
            }
            return allProductosOrdenListaArmada;
        }

        /*
        DECLARE @errorId2 int;
		EXEC [dbo].[SP_ListaProductosOrden] '68', @errorId2 
	    print @errorId2;

        */
        public ResCancelarOrden cancelarOrden(ReqCancelarOrden req)
        {
            
            ResCancelarOrden res = new ResCancelarOrden();
            res.listaMensajesOErrores = new List<string>();
            try 
            {
                if (req == null)
                {

                    res.listaMensajesOErrores.Add("Request faltante");
                    res.result = false;
                }
                else if (req.idOrden == 0)
                {
                    res.listaMensajesOErrores.Add("Id de Orden faltante");
                    res.result = false;
                }
                else
                {
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    int? errorId = 0;
                    laConexion.PA_CancelarOrden(req.idOrden, ref errorId);
                    if (errorId == 0)
                    {
                        res.listaMensajesOErrores.Add("Orden cancelada con éxito!");
                        res.result = true;
                    }
                    else if (errorId == 3) 
                    {
                        res.listaMensajesOErrores.Add("ID de Orden no existe, no se pudo cancelar la orden.");
                        res.result = false;
                    }
                    else if (errorId == 2) 
                    {
                        res.listaMensajesOErrores.Add("ID de Mesa no existe, no se pudo cancelar la orden.");
                        res.result = false;
                    }
                    else if (errorId == 1)
                    {
                        res.listaMensajesOErrores.Add("ID de Usuario no existe, no se pudo cancelar la orden.");
                        res.result = false;
                    }

                }

            }
            catch (Exception ex) 
            {
    
                res.listaMensajesOErrores.Add("Ocurrió un error con la solicitud para cancelar una orden: " + ex.Message);
                res.result = false;
            }
           return res;
        }

        public ResCobrarOrden cobrarOrden(ReqCobrarOrden req)
        { 
            ResCobrarOrden res = new ResCobrarOrden();
            res.listaMensajesOErrores = new List<string>();
            try 
            { 
                if (req == null)
                {
                    res.listaMensajesOErrores.Add("Request faltante");
                    res.result = false;

                }
                    
                else if (req.idOrden == 0) 
                {
                    
                    res.listaMensajesOErrores.Add("Id de Orden faltante");
                    res.result = false;
                }
                else
                {
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    int? errorId = 0;
                    laConexion.PA_CobrarOrden(req.idOrden, ref errorId);
                    if (errorId == 0)
                    {
                        res.listaMensajesOErrores.Add("Orden cobrada con éxito!");
                        res.result = true;
                    }
                    else if (errorId == 3)
                    {
                        res.listaMensajesOErrores.Add("ID de Orden no existe, no se pudo cobrar.");
                        res.result = false;
                    }
                    else if (errorId == 2) 
                    {
                        res.listaMensajesOErrores.Add("ID de Mesa no existe, no se pudo cobrar.");
                        res.result = false;
                    }
                    else if (errorId == 1)
                    {
                        res.listaMensajesOErrores.Add("ID de Usuario existe, no se pudo cobrar.");
                        res.result = false;
                    }
                    
                }
            }
            catch (Exception ex) 
            {
                res.listaMensajesOErrores.Add("Ocurrió un error con la solicitud para cobrar una orden: " + ex.Message);
                res.result = false;
            }
            return res;
        }

    }

    }
