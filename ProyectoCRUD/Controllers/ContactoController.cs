using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Configuration;
using ProyectoCRUD.Models;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace ProyectoCRUD.Controllers
{
    public class ContactoController : Controller
    {
        //con este comando le indicamo que vaya a leer dentro de "Web.config" un elemento lladado cadea
        private static string conexion = ConfigurationManager.ConnectionStrings["cadena"].ToString();

        private static List<Contacto> olista = new List<Contacto>();

        // GET: Contacto
        public ActionResult Inicio()
        {
            using (SqlConnection oconection = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM CONTACTO", oconection);
                cmd.CommandType = CommandType.Text;
                oconection.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        Contacto nuevoContcto = new Contacto();

                        nuevoContcto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        nuevoContcto.Nombre = dr["Nombre"].ToString();
                        nuevoContcto.Apellido = dr["Apellido"].ToString();
                        nuevoContcto.Telefono = dr["Telefono"].ToString();
                        nuevoContcto.Correo = dr["Correo"].ToString();

                        olista.Add(nuevoContcto);
                    }
                }
            }
                return View(olista);
        }
    }
}