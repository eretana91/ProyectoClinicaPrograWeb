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

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.strUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/Expedientes").Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.OperacionExitosa = true;
                ViewBag.result = response.Content.ReadAsAsync<List<Expedientes>>().Result;
            }
            else
            {
                ViewBag.OperacionExitosa = false;
                ViewBag.result = "Error al consultar la información";
            }

            return View();
        }
        public ActionResult create(Expedientes expedientes)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.strUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var id = expedientes.idExpediente;

            HttpResponseMessage response = client.PutAsJsonAsync($"api/Usuarios/", expedientes).Result;

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
        public ActionResult Edit(int id)
        {
            if (id == 0)
                return View();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.strUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Expedientes/" + id.ToString()).Result;

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.OperacionExitosa = false;
                ViewBag.result = "Error al consultar la información";
            }
            else
            {
                ViewBag.OperacionExitosa = true;
            }

            return View(response.Content.ReadAsAsync<Expedientes>().Result);
        }

        [HttpPost]
        public ActionResult Edit(Expedientes expediente)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.strUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var id = expediente.idExpediente;

            HttpResponseMessage response = client.PutAsJsonAsync($"api/Expedientes/{id}", expediente).Result;

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
            HttpResponseMessage response = client.DeleteAsync("api/Expedientes/" + id.ToString()).Result;

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
