using Microsoft.AspNetCore.Mvc;
using FE.Models;
using System;
using System.Web;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FE.Controllers
{
    public class InventarioController : Controller
    {
        public ActionResult Index()
        {

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(GlobalVariables.strUri);
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = client.GetAsync("api/Categoria").Result;

            List<Inventario> ListaInventario = new List<Inventario>();
            Inventario inventario = new Inventario();
            inventario.tipoProducto = 1;
            inventario.idProducto = 1;
            inventario.nombreProducto = "Mesa";
            inventario.codigoBarras = "1615601";
            inventario.precio = "25000";
            inventario.cantidad = 2;
            //inventario.fechaExpiracion = 12/11/1991;
            inventario.notas = "Mesa para comedor";

            ListaInventario.Add(inventario);

            //if (response.IsSuccessStatusCode)
            if (true)
            {
                ViewBag.result = ListaInventario;
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
