using System;
using Backend.dataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Backend.Entities;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Web.UI;

namespace Backend.Logic
{
    public class logUsuario
    {   
        //crear una nueva persona junto a un usuario
        public ResIngresarUsuario crearUsuario(ReqIngresarUsuario req)
        {   
            ResIngresarUsuario res = new ResIngresarUsuario();
            res.listaMensajesOErrores = new List<string>();
            try
            {
                if (req == null || req.elUsuario == null)
                    {
                    
                    res.listaMensajesOErrores.Add("Request faltante");
                    res.result = false;
                    }
                    else if(String.IsNullOrEmpty(req.elUsuario.NombrePersona))
                    {
                        res.listaMensajesOErrores.Add("Nombre de persona faltante");
                        res.result = false;
                    }
                    else if (String.IsNullOrEmpty(req.elUsuario.Apellido))
                    {
                        
                        res.listaMensajesOErrores.Add("Apellido de persona faltante");
                        res.result = false;
                    }
                    else if (req.elUsuario.Telefono == 0)
                    {
                        res.listaMensajesOErrores.Add("Telefono de persona faltante");
                        res.result = false;
                    }
                    else if (req.elUsuario.Cedula == 0)
                    {
                        res.listaMensajesOErrores.Add("Cedula de persona faltante");
                        res.result = false;
                    }
                    else if (String.IsNullOrEmpty(req.elUsuario.contrasena))
                    {
                        res.listaMensajesOErrores.Add("Contrasena de usuario faltante");
                        res.result = false;
                    }
                    else if (String.IsNullOrEmpty(req.elUsuario.correo))
                    {
                        res.listaMensajesOErrores.Add("Correo de usuario faltante");
                        res.result = false;
                    }

                    else if (Convert.ToInt32(req.elUsuario.idTipoUsuario) != 1 && (Convert.ToInt32(req.elUsuario.idTipoUsuario) != 2))
                    {
                    res.listaMensajesOErrores.Add("Tipo de Usuario Inválido");
                        res.result = false;

                    }
                    else
                    {
                    
                        conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    int? errorId = 0;
                    laConexion.PA_RegistrarUsuario(req.elUsuario.NombrePersona, req.elUsuario.Apellido, req.elUsuario.Telefono, req.elUsuario.Cedula, req.elUsuario.contrasena, req.elUsuario.correo,  req.elUsuario.idTipoUsuario, ref errorId);
                    if (errorId == 0)
                    {
                        res.listaMensajesOErrores.Add("Has creado un nuevo usuario de forma exitosa!");
                        res.result = true;

                    }
                    else if (errorId == 4)
                    {

                        res.listaMensajesOErrores.Add("Esta cedula ya existe, no se puede crear la persona.");
                        res.result = false;
                        
                    }
                    else if (errorId == 3)

                    {

                        res.listaMensajesOErrores.Add("Tipo de usuario no válido, no se puede crear la persona.");
                        res.result = false;
                        //repetitivo en DB, lo mismo que el errorId == 1

                        
                    }
                    else if (errorId == 2)
                    {
                        res.listaMensajesOErrores.Add("Esta persona ya existe, no se puede agregar el usuario.");
                        res.result = false;
                        //esto no se valida ya que no le paso el idpersona porque es identity
                    }
                    else if (errorId == 1)
                    {
                        res.listaMensajesOErrores.Add("El tipo de usuario no existe, el usuario no se pudo agregar.");
                        res.result = false;
                    }

                    }
                    
            }
            catch (Exception ex)
            {
                
                res.listaMensajesOErrores.Add("Error al procesar la solicitud de crear usuario" + ex.Message);
                res.result = false;

            }
            return res;
        }

        //listar todos los usuarios
        public ResObtenerTodosUsuarios obtenerTodosUsuarios(ReqObtenerTodosUsuarios req)
        {
            ResObtenerTodosUsuarios res = new ResObtenerTodosUsuarios();
            try
            {

                conexionLinqDataContext laConexion = new conexionLinqDataContext();
                List<PA_ListaUsuariosResult> result = laConexion.PA_ListaUsuarios().ToList();
                if (result.Count != 0)
                {
                    res.listaTodosUsuarios = new List<usuarioObtenerTodos>();
                    res.listaTodosUsuarios = this.armarListadoUsuarios(result);

                    res.result = true;
                }
                else
                {
                    res.listaMensajesOErrores = new List<string>();
                    res.listaMensajesOErrores.Add("No hay usuarios");
                    res.result = false;
                }


            }
            catch (Exception ex)
            {
                res.listaMensajesOErrores = new List<string>();
                res.listaMensajesOErrores.Add("Error al procesar la solicitud de obtener todos los usuarios" + ex.Message);
                res.result = false;
            }
            return res;
        }
        //listado para el metodo de obtener allusers
        private List<usuarioObtenerTodos> armarListadoUsuarios(List<PA_ListaUsuariosResult> allUsersListLinq)
        {
            List<usuarioObtenerTodos> allUsersListArmada = new List<usuarioObtenerTodos>();
            foreach (PA_ListaUsuariosResult elementoLinq in allUsersListLinq)
            {
                usuarioObtenerTodos listaUsuarios = new usuarioObtenerTodos();
                listaUsuarios.idUsuario = elementoLinq.idUsuario;
                listaUsuarios.correo = elementoLinq.correo;
                listaUsuarios.Persona_ID = elementoLinq.Persona_ID;
                listaUsuarios.NombrePersona = elementoLinq.NombrePersona;
                listaUsuarios.Apellido = elementoLinq.Apellido;
                listaUsuarios.idTipoUsuario = elementoLinq.idTipoUsuario;
                listaUsuarios.TipoUsuario = elementoLinq.TipoUsuario;
                allUsersListArmada.Add(listaUsuarios);
            }
            return allUsersListArmada;
        }

        //metodo para actualizar un usuario en especifico
        public ResActualizarUsuario actualizarUsuario(ReqActualizarUsuario req)
        {
            ResActualizarUsuario res = new ResActualizarUsuario();
            try
            {
                res.listaMensajesOErrores = new List<string>();
                // Validar datos
                if (req.elUsuario.idUsuario == 0)
                {
                    
                    res.listaMensajesOErrores.Add("Id de Usuario Faltante");
                    res.result = false;

                }

                else if (string.IsNullOrEmpty(req.elUsuario.NombrePersona))
                {
             
                    res.listaMensajesOErrores.Add("Nombre de Usuario Faltante");
                    res.result = false;
                }

                else if (string.IsNullOrEmpty(req.elUsuario.Apellido))
                {
                    res.listaMensajesOErrores.Add("Apellido de Usuario Faltante");
                    res.result = false;
                }

                else if (string.IsNullOrEmpty(req.elUsuario.correo))
                {
                    res.listaMensajesOErrores.Add("Correo de Usuario faltante");
                    res.result = false;
                }
                else if (req.elUsuario.Telefono == 0)
                {
                    res.listaMensajesOErrores.Add("Telefono de Usuario faltante");
                    res.result = false;
                }
                else if (req.elUsuario.Cedula == 0)
                {
                    res.listaMensajesOErrores.Add("Cedula de Usuario Faltante");
                    res.result = false;
                }
                else if (string.IsNullOrEmpty(req.elUsuario.contrasena))
                {
                    res.listaMensajesOErrores.Add("Contrasena de Usuario Faltante");
                    res.result = false;
                }
                else if (req.elUsuario.idTipoUsuario == 0)
                {
                    res.listaMensajesOErrores.Add("Id de Tipo de Usuario Faltante");
                    res.result = false;
                }
                else
                {
                    // Conectar a la base de datos
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    // Ejecutar el procedimiento almacenado
                    int? errorId = 0;
                    laConexion.PA_ActualizarUsuario(req.elUsuario.idUsuario, req.elUsuario.NombrePersona, req.elUsuario.Apellido, req.elUsuario.correo, req.elUsuario.Telefono, req.elUsuario.Cedula, req.elUsuario.contrasena, req.elUsuario.idTipoUsuario, ref errorId);
                    if (errorId == 0)
                    {
                        res.listaMensajesOErrores.Add("Has actualizado un usuario y persona de forma exitosa!");
                        res.result = true;
                    }
                    else if (errorId == 3)
                    {
                        res.listaMensajesOErrores.Add("Compruebe que el tipo de usuario exista, no se puede actualizar.");
                        res.result = false;
                    }
                    else if (errorId == 2)
                    {
                        res.listaMensajesOErrores.Add("Compruebe que el usuario exista, no se puede actualizar.");
                        res.result = false;
                    }
                    else if (errorId == 1)
                    {
                        res.listaMensajesOErrores.Add("La persona no existe, no se puede actualizar.");
                        res.result = false;
                    }

                }
            }
            catch (Exception ex)
            {
                res.listaMensajesOErrores = new List<string>();
                res.listaMensajesOErrores.Add("Error al procesar la solicitud de actualizar usuario" + ex.Message);
                res.result = false;

            }
            return res;
        }
        //metodo para obtener solo un usuario
        public ResObtenerUsuario obtenerUnUsuario(ReqObtenerUsuario req)
        {
            ResObtenerUsuario res = new ResObtenerUsuario();
            try
            {
                if (req.idUsuario == 0)
                {
                    res.listaMensajesOErrores = new List<string>();
                    res.listaMensajesOErrores.Add("No se envio el ID para obtener un usuario");
                    res.result = false;
                }
                else 
                {
                    // Conectar a la base de datos
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    // Ejecutar el procedimiento almacenado
                    int? errorId = 0;
                    List<PA_ListarUsuarioResult> result = laConexion.PA_ListarUsuario(req.idUsuario, ref errorId).ToList();
                    if (result.Count != 0 && errorId == 0)
                    {
                        res.elUsuario = new usuarioObtenerUno()
                        {
                            idUsuario = result[0].idUsuario,
                            Persona_ID = result[0].Persona_ID,
                            NombrePersona = result[0].NombrePersona,
                            Apellido = result[0].Apellido,
                            correo = result[0].correo,
                            Telefono = result[0].Telefono,
                            Cedula = result[0].Cedula,
                            contrasena = result[0].contrasena,
                            idTipoUsuario = (int)result[0].idTipoUsuario
                            //TipoUsuario = result[0].TipoUsuario;

                        };
                        
                        res.result = true;
                        res.listaMensajesOErrores.Add("Has encontrado un usuario con el id: " + req.idUsuario);

                    }
                    else if (errorId == 1)
                    {
                        //res.elUsuario = null;
                        res.listaMensajesOErrores = new List<string>();
                        res.listaMensajesOErrores.Add("ID de Usuario no existe, intente con otro.");
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

        public ResEliminarUsuario eliminarUsuario(ReqEliminarUsuario req)
        {
            ResEliminarUsuario res = new ResEliminarUsuario();
            res.listaMensajesOErrores = new List<string>();
            try
            {
                if (req.idUsuario == 0)
                {
                    res.listaMensajesOErrores = new List<string>();
                    res.listaMensajesOErrores.Add("No se envio el id");
                    res.result = false;
                }
                else
                {
                    conexionLinqDataContext laConexion = new conexionLinqDataContext();
                    int? errorId = 0;
                    laConexion.PA_EliminarUsuario(req.idUsuario, ref errorId);
                    
                    if (errorId == 0)
                    {
                        res.listaMensajesOErrores.Add("El usuario y la persona han sido eliminados con éxito!");
                        res.result = true;
                    }
                    else if(errorId == 2) 
                    {
                        res.listaMensajesOErrores.Add("El usuario no existe, no se puede eliminar, intente con otro.");
                        res.result = false;
                    }
                    else if (errorId == 1)
                    {
                        res.listaMensajesOErrores.Add("La persona no existe, no se puede eliminar el usuario, intente con otro.");
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



