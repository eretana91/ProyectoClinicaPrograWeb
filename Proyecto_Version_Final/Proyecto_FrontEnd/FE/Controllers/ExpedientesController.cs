using Microsoft.AspNetCore.Mvc;
using FE.Models;
using System;
using System.Web;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FE.Controllers
{
    public class ExpedientesController : Controller
    {
        public ActionResult Index()
        {

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(GlobalVariables.strUri);
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = client.GetAsync("api/Categoria").Result;

            List<Expedientes> ListaExpediente = new List<Expedientes>();
           Expedientes expediente = new Expedientes();
            expediente.cedula = "114830553";
            //expediente.fechaN = (2021,04,02);
            expediente.ciudad = "Heredia";
            expediente.canton = "Heredia";
            expediente.distrito = "Mercedes Norte";
            expediente.diagnostico = "N/A";
            expediente.antecendente = "N/A";
            expediente.mediUtilizados = "N/A";
            expediente.anteQuirurgicos = "N/A";
            expediente.fracturas = "N/A";
            expediente.anteFamiliares = "N/A";
        

            ListaExpediente.Add(expediente);

            //if (response.IsSuccessStatusCode)
            if (true)
            {
                ViewBag.result = ListaExpediente;
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
