using Backend.dataAccess;
using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Logic

{
    public class logValidarLogin
    {

        public ResUsuarioLogin validarLogin(ReqUsuarioLogin req)
        {
            ResUsuarioLogin res = new ResUsuarioLogin();
            res.listaMensajesOErrores = new List<string>(); //si dice object referenced en postman, es porque esto no se referencia antes
            try
            {
                var dataContext = new conexionLinqDataContext();
                // Call the stored procedure using LINQ to SQL
                int? errorId = 0;
                var result = dataContext.SP_ValidarLogin(req.elUserLogin.correo, req.elUserLogin.contrasena, ref errorId).ToList();

                // Check if a user was found with the given credentials
                if (result.Any() && errorId == 0)
                {
                    // Get the user's information from the stored procedure result
                    var user = result.First();

                    // Check if the user is an admin or regular user
                    if (user.idTipoUsuario == 1)
                    {
                        res.esAdmin = true;
                    }
                    else if (user.idTipoUsuario == 2)
                    {
                        res.esAdmin = false;
                    }

                   
                        // Set the response properties with the user's information
                        res.idUsuario = user.idUsuario;
                        res.idTipoUsuario = (int)user.idTipoUsuario;
                        res.NombrePersona = user.NombrePersona;
                        res.Apellido = user.Apellido;
                        res.listaMensajesOErrores.Add("Credenciales válidas!");
                        res.result = true;

                    
                    
                }
                else if (errorId == 1)
                {
                    // No user was found with the given credentials
                    res.listaMensajesOErrores = new List<string>();
                    res.listaMensajesOErrores.Add("Credenciales inválidas, intente de nuevo.");
                    res.result = false;
                }
            }
            catch (Exception ex)
            {
                // An error occurred while processing the request
                res.listaMensajesOErrores = new List<string>();
                res.listaMensajesOErrores.Add("Error al procesar la solicitud de validar login: " + ex.Message);
                res.result = false;
            }
            return res;
        }


    }


}