
using Backend.dataAccess;
using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Logic
{
    public class logOrdenDetalle
    {
        public ResIngresarOrdenDetalle crearOrdenDetalle(ReqIngresarOrdenDetalle req)
        {
            ResIngresarOrdenDetalle res = new ResIngresarOrdenDetalle();
            res.listaMensajesOErrores = new List<string>();

            try
            {
                if (req == null || req.crearDetalleDeOrden == null)
                {
                    res.listaMensajesOErrores.Add("Request faltante");
                    res.result = false;
                }
                else if (req.crearDetalleDeOrden.cantidad == 0)
                {
                    res.listaMensajesOErrores.Add("Cantidad del detalle de la orden faltante");
                    res.result = false;
                }
                else if (req.crearDetalleDeOrden.idOrden == 0)
                {
                    res.listaMensajesOErrores.Add("ID de Orden del detalle de la orden faltante");
                    res.result = false;
                }
                else if (req.crearDetalleDeOrden.idProducto == 0)
                {
                    res.listaMensajesOErrores.Add("ID de Producto del detalle de la orden faltante");
                    res.result = false;
                }
                else
                {
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    int? errorId = 0;
                    laConexion.SP_CrearOrdenDetalle(req.crearDetalleDeOrden.cantidad, req.crearDetalleDeOrden.idOrden, req.crearDetalleDeOrden.idProducto, ref errorId);
                    if (errorId == 0)
                    {
                        res.listaMensajesOErrores.Add("Has creado un detalle de orden nuevo!");
                        res.result = true;
                    }
                    else if(errorId == 4) 
                    {
                        res.listaMensajesOErrores.Add("ID de Orden no existe o ya no está activa, no se pudo crear el detalle de la orden.");
                        res.result = false;
                    }
                    else if(errorId == 3) 
                    {
                        res.listaMensajesOErrores.Add("ID de Producto no existe, no se pudo crear el detalle de la orden.");
                        res.result = false;
                    }
                    else if (errorId == 2)
                    {
                        res.listaMensajesOErrores.Add("Cantidad de producto a ordenar mayor a cantidad disponible.");
                        res.result = false;

                    }
                    else if (errorId == 1)
                    {
                        res.listaMensajesOErrores.Add("Ya existe un detalle de orden con el mismo producto, intente con otro producto o actualice el detalle de orden.");
                        res.result = false;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                res.listaMensajesOErrores.Add("Error al procesar la solicitud de crear un detalle de orden" + ex.Message);
                res.result = false;

            }

            return res;

        }

        public ResEliminarOrdenDetalle eliminarOrdenDetalle(ReqEliminarOrdenDetalle req)
        {
            ResEliminarOrdenDetalle res = new ResEliminarOrdenDetalle();
            res.listaMensajesOErrores = new List<string>();

            try
            {
                if (req == null)
                {
                    res.listaMensajesOErrores.Add("Request faltante");
                    res.result = false;
                }
                else if (req.idDetalleOrden == 0)
                {
                    res.listaMensajesOErrores.Add("ID del detalle de la orden faltante");
                    res.result = false;
                }
                else
                {
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    int? errorId = 0;
                    laConexion.PA_EliminarOrdenDetalle(req.idDetalleOrden, ref errorId);
                    if (errorId == 0) 
                    {
                        res.listaMensajesOErrores.Add("Has eliminado un detalle de orden de forma exitosa!");
                        res.result = true;
                    }
                    else if(errorId == 1) 
                    {
                        res.listaMensajesOErrores.Add("ID de Detalle no existe, no se pudo eliminar.");
                        res.result = false;
                    }
                    
                }
            }
            catch (Exception ex) 
            {
                res.listaMensajesOErrores.Add("Error al procesar la solicitud de eliminar un detalle de orden" + ex.Message);
                res.result = false;

            }
            return res;
        }
        public ResActualizarOrdenDetalle actualizarOrdenDetalle(ReqActualizarOrdenDetalle req)
        {
            ResActualizarOrdenDetalle res = new ResActualizarOrdenDetalle();
            res.listaMensajesOErrores = new List<string>();

            try
            {
                if (req == null)
                {
                    res.listaMensajesOErrores.Add("Request faltante");
                    res.result = false;
                }
                else if (req.actualizarDetalleDeOrden.cantidad == 0)
                {
                    res.listaMensajesOErrores.Add("Cantidad del detalle de la orden faltante");
                    res.result = false;
                }
                else if (req.actualizarDetalleDeOrden.IdOrden == 0)
                {
                    res.listaMensajesOErrores.Add("ID de Orden del detalle de la orden faltante");
                    res.result = false;
                }
                else if (req.actualizarDetalleDeOrden.idProducto == 0)
                {
                    res.listaMensajesOErrores.Add("ID de Producto del detalle de la orden faltante");
                    res.result = false;
                }
                else
                {
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    int? errorId = 0;
                    laConexion.PA_ActualizarOrdenDetalle(req.actualizarDetalleDeOrden.cantidad, req.actualizarDetalleDeOrden.IdOrden, req.actualizarDetalleDeOrden.idProducto, ref errorId);
                    if (errorId == 0) 
                    {
                        res.listaMensajesOErrores.Add("Has actualizado un detalle de orden!");
                        res.result = true;
                    }
                    else if (errorId == 1) 
                    {
                        res.listaMensajesOErrores.Add("Cantidad de producto a ordenar mayor a lo existente, no se pudo actualizar el detalle de orden.");
                        res.result = false;
                    }
                    else if (errorId == 2)
                    {
                        res.listaMensajesOErrores.Add("ID de Producto no existe, no se pudo actualizar el detalle de orden.");
                        res.result = false;
                    }
                    else if (errorId == 3)
                    {
                        res.listaMensajesOErrores.Add("ID de Orden no existe o no está activa, no se pudo actualizar el detalle de orden.");
                        res.result = false;
                    }
                    else if (errorId == 4) 
                    {
                        res.listaMensajesOErrores.Add("ID de Detalle Orden no existe, no se pudo actualizar el detalle de orden.");
                        res.result = false;
                    }
                    
                }
            }
            catch (Exception ex) 
            {
                res.listaMensajesOErrores.Add("Error al procesar la solicitud de actualizar un detalle de orden" + ex.Message);
                res.result = false;
            }
            return res;
        }
    }
}