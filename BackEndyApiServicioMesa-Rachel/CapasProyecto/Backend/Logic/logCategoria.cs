using Backend.dataAccess;
using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Logic
{
    public class logCategoria
    {
        public ResIngresarCategoria crearCategoria(ReqIngresarCategoria req)
        {
            ResIngresarCategoria res = new ResIngresarCategoria();
            res.listaMensajesOErrores = new List<string>();
            //para almacenar listamensajes en un sitio y bitacorear, enums
            try
            {
                if (req == null || req.laCategoria == null)
                {

                    res.listaMensajesOErrores.Add("Request faltante");
                    res.result = false;
                    //enumErrores.
                }
                else if (String.IsNullOrEmpty(req.laCategoria.descripcion))
                {
                    res.listaMensajesOErrores.Add("Descripción faltante para crear una categoria");
                    res.result = false;
                }
                else
                {

                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    int? errorId = 0;
                    laConexion.SP_AgregarCategoria(req.laCategoria.descripcion, ref errorId);
                    
                    if (errorId == 0)
                    {
                        res.listaMensajesOErrores.Add("Has creado una nueva categoria de forma exitosa!");
                        res.result = true;

                    }
                    else if (errorId == 1)
                    {

                        res.listaMensajesOErrores.Add("Esta descripción de Categoría ya existe, no se puede crear la Categoría.");
                        res.result = false;
                    }
                }

            }
            catch (Exception ex)
            {

                res.listaMensajesOErrores.Add("Error al procesar la solicitud de crear una nueva categoria " + ex.Message);
                res.result = false;
                //enumErrores.errorNoControlado;

            }
            return res;
        }

        //listar todos los usuarios
        public ResObtenerTodasCategorias obtenerTodasCategorias(ReqObtenerTodasCategorias req)
        {
            ResObtenerTodasCategorias res = new ResObtenerTodasCategorias();
            try
            {

                conexionLinqDataContext laConexion = new conexionLinqDataContext();
                List<SP_ListarCategoriasResult> result = laConexion.SP_ListarCategorias().ToList();
                if (result.Count != 0)
                {
                    res.listaTodasCategorias = new List<Categoria>();
                    res.listaTodasCategorias = this.armarListadoCategorias(result);

                    res.result = true;
                }
                else
                {
                    res.listaMensajesOErrores = new List<string>();
                    res.listaMensajesOErrores.Add("No hay categorias para listar.");
                    res.result = false;
                }


            }
            catch (Exception ex)
            {
                res.listaMensajesOErrores = new List<string>();
                res.listaMensajesOErrores.Add("Error al procesar la solicitud de obtener todas las categorias. " + ex.Message);
                res.result = false;
            }
            return res;
        }
        //listado para el metodo de obtener allusers
        private List<Categoria> armarListadoCategorias(List<SP_ListarCategoriasResult> allCategoriasListLinq)
        {
            List<Categoria> allCategoriasListArmada = new List<Categoria>();
            foreach (SP_ListarCategoriasResult elementoLinq in allCategoriasListLinq)
            {
                Categoria listaCategorias = new Categoria();
                listaCategorias.idCategoria = elementoLinq.idCategoria;
                listaCategorias.descripcion = elementoLinq.descripcion;
                
                allCategoriasListArmada.Add(listaCategorias);
            }
            return allCategoriasListArmada;
        }

        public ResActualizarCategoria actualizarCategoria(ReqActualizarCategoria req)
        {
            ResActualizarCategoria res = new ResActualizarCategoria();
            res.listaMensajesOErrores = new List<string>();
            try
            {

                // Validar datos
                if (req.actualizarCategoria.idCategoria == 0)
                {

                    res.listaMensajesOErrores.Add("Id de Categoria faltante.");
                    res.result = false;

                }

                else if (string.IsNullOrEmpty(req.actualizarCategoria.descripcion))
                {

                    res.listaMensajesOErrores.Add("Descripcion de categoria faltante.");
                    res.result = false;
                }
                else
                {
                    // Conectar a la base de datos
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    // Ejecutar el procedimiento almacenado
                    int? errorId = 0;
                    laConexion.SP_ActualizarCategoria(req.actualizarCategoria.idCategoria, req.actualizarCategoria.descripcion, ref errorId);
                    

                   if (errorId == 0)
                    {
                        res.listaMensajesOErrores.Add("Has actualizado una categoria forma exitosa!");
                        res.result = true;
                    }
                    else if (errorId == 1)
                    {
                        res.listaMensajesOErrores.Add("Esta categoria no existe, no se puede actualizar.");
                        res.result = false;
                    }
                }
            }
            catch (Exception ex)
            {
                res.listaMensajesOErrores = new List<string>();
                res.listaMensajesOErrores.Add("Error al procesar la solicitud de actualizar una categoria " + ex.Message);
                res.result = false;

            }
            return res;
        }

        public ResEliminarCategoria eliminarCategoria(ReqEliminarCategoria req)
        {
            ResEliminarCategoria res = new ResEliminarCategoria();
            res.listaMensajesOErrores = new List<string>();
            try
            {
                if (req.idCateg == 0)
                {
                    res.listaMensajesOErrores = new List<string>();
                    res.listaMensajesOErrores.Add("No se envio el ID de Categoria.");
                    res.result = false;
                }
                else
                {
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    int? errorId = 0;
                    laConexion.SP_EliminarCategoria(req.idCateg, req.descripcion, ref errorId);

                    if (errorId == 0)
                    {
                        res.listaMensajesOErrores.Add("La categoria ha sido eliminada con éxito!");
                        res.result = true;
                    }
                    else if (errorId == 1)
                    {
                        res.listaMensajesOErrores.Add("ID de Categoria o nombre no existe, intente con otro.");
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