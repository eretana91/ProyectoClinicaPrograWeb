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

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.strUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/Pagos").Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.OperacionExitosa = true;
                ViewBag.result = response.Content.ReadAsAsync<List<Pagos>>().Result;
            }
            else
            {
                ViewBag.OperacionExitosa = false;
                ViewBag.result = "Error al consultar la información";
            }

            return View();
        }

        public ActionResult EditarPago(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.strUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Pagos/" + id.ToString()).Result;

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.OperacionExitosa = false;
                ViewBag.result = "Error al consultar la información";
            }
            else
            {
                ViewBag.OperacionExitosa = true;
            }

            return View(response.Content.ReadAsAsync<Pagos>().Result);
        }

        [HttpPost]
        public ActionResult EditarPagos(Pagos Pagos)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.strUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var id = Pagos.idPago;

            HttpResponseMessage response = client.PutAsJsonAsync($"api/Pagos/{id}", Pagos).Result;

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

        [HttpDelete]
        public ActionResult Delete(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.strUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.DeleteAsync("api/Pagos/" + id.ToString()).Result;

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
