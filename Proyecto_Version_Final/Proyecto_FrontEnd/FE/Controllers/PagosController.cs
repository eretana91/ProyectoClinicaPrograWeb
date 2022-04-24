using Microsoft.AspNetCore.Mvc;
using FE.Models;
using System;
using System.Web;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FE.Controllers
{
    public class PagosController : Controller
    {
        public ActionResult Index()
        {

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(GlobalVariables.strUri);
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = client.GetAsync("api/Categoria").Result;

            List<Pagos> ListaPago = new List<Pagos>();
            Pagos pago = new Pagos();
            pago.tipoPago = 1;
            pago.idPago = 1;
            pago.monto = 10000;
            pago.banco = "BAC";
            pago.cedula = "114830553";
            //pago.fechaPago = 12/11/1991;
            pago.notas = "Adelanto de pago";

            ListaPago.Add(pago);

            //if (response.IsSuccessStatusCode)
            if (true)
            {
                ViewBag.result = ListaPago;
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
