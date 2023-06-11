using Backend.dataAccess;
using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Logic
{
    public class logMesa
    {
        //metodo para obtener todas las mesas
        public ResObtenerTodasMesas obtenerTodasMesas(ReqObtenerTodasMesas req)
        {
            ResObtenerTodasMesas res = new ResObtenerTodasMesas();
            try
            {

                conexionLinqDataContext laConexion = new conexionLinqDataContext();
                List<SP_ListarMesasResult> result = laConexion.SP_ListarMesas().ToList();
                if (result.Count != 0)
                {
                    res.listaTodasMesas = new List<Mesa>();
                    res.listaTodasMesas = this.armarListadoMesas(result);

                    res.result = true;
                }
                else
                {
                    res.listaMensajesOErrores = new List<string>();
                    res.listaMensajesOErrores.Add("No hay mesas");
                    res.result = false;
                }


            }
            catch (Exception ex)
            {
                res.listaMensajesOErrores = new List<string>();
                res.listaMensajesOErrores.Add("Error al procesar la solicitud de obtener todas las mesas" + ex.Message);
                res.result = false;
            }
            return res;
        }
        //listado para el metodo de obtener allusers
        private List<Mesa> armarListadoMesas(List<SP_ListarMesasResult> allTablesListing)
        {
            List<Mesa> allMesasListaArmada = new List<Mesa>();
            foreach (SP_ListarMesasResult elementoLinq in allTablesListing)
            {
                Mesa listaMesas = new Mesa();
                listaMesas.idMesa = elementoLinq.idMesa;
                listaMesas.nombreMesa = elementoLinq.nombreMesa;
                
                allMesasListaArmada.Add(listaMesas);
            }
            return allMesasListaArmada;
        }
    }
}