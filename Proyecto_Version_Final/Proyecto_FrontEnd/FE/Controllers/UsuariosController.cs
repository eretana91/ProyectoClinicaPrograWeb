using Microsoft.AspNetCore.Mvc;
using FE.Models;
using System;
using System.Web;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FE.Controllers
{
    public class UsuariosController : Controller
    {
        public ActionResult Index()
        {

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(GlobalVariables.strUri);
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = client.GetAsync("api/Categoria").Result;

            List<Usuario> ListaUsuario = new List<Usuario>();
            Usuario usuario = new Usuario();
            usuario.IdTipoUsuario = 1;
            usuario.Nombre = "Erick";
            usuario.Email = "XXX";
            usuario.Apellidos = "Retana";
            usuario.Cedula = "113540616";
    
            ListaUsuario.Add(usuario);

            //if (response.IsSuccessStatusCode)
            if (true)
            {
                ViewBag.result = ListaUsuario;
                //ViewBag.result = response.Content.ReadAsAsync<List<Categoria>>().Result;
            }
            //else
            //{
            //    ViewBag.result = "Error";
            //}
                       
                         
            return View();
        }

        public ActionResult EditarUsuario(int cedula)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.strUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            //HttpResponseMessage response = client.GetAsync("api/Categoria/" + cedula.ToString()).Result;

            //if (!response.IsSuccessStatusCode)
            //{
            //    ViewBag.result = "Error";
            //}

            return View();

            //return View(response.Content.ReadAsAsync<Categoria>().Result);
        }

        //public ActionResult EditarUsuario(int cedula)
        //{

        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri(GlobalVariables.strUri);
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/json"));

        //    //HttpResponseMessage response = client.GetAsync("api/Categoria/" + cedula.ToString()).Result;

        //    //if (!response.IsSuccessStatusCode)
        //    //{
        //    //    ViewBag.result = "Error";
        //    //}

        //    return View();

        //    //return View(response.Content.ReadAsAsync<Categoria>().Result);
        //}



    }
}
