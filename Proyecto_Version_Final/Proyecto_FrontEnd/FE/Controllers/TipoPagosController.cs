using Microsoft.AspNetCore.Mvc;
using FE.Models;
using System;
using System.Web;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FE.Controllers
{
    public class TipoPagosController : Controller
    {
        public ActionResult Index()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.strUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/TipoPagoes").Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.OperacionExitosa = true;
                ViewBag.result = response.Content.ReadAsAsync<List<TipoPagos>>().Result;
            }
            else
            {
                ViewBag.OperacionExitosa = false;
                ViewBag.result = "Error al consultar la información";
            }

            return View();
        }

 
        public ActionResult Edit(int id)
        {

            if (id == 0)
               return View();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.strUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/TipoPagoes/" + id.ToString()).Result;

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.OperacionExitosa = false;
                ViewBag.result = "Error al consultar la información";
            }
            else
            {
                ViewBag.OperacionExitosa = true;
            }

            return View(response.Content.ReadAsAsync<TipoPagos>().Result);
        }

        [HttpPost]
        public ActionResult Edit(TipoPagos TipoPagos)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.strUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var id = TipoPagos.tipoPago1;
  
            HttpResponseMessage response = client.PutAsJsonAsync($"api/TipoPagoes/{id}", TipoPagos).Result;

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.OperacionExitosa = false;
                ViewBag.result = "Error al consultar la información";
            }
            else
            {
                ViewBag.OperacionExitosa = true;
            }

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.strUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.DeleteAsync("api/TipoPagoes/" + id.ToString()).Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.OperacionExitosa = true;
            }
            else
            {
                ViewBag.OperacionExitosa = false;
                ViewBag.result = "Error al consultar la información";
            }

            return RedirectToAction("Index");
        }

    }
}
