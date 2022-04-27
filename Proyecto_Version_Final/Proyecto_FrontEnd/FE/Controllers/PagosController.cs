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


        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                TempData["esCrear"] = true;
                return View();

            }

            TempData["esCrear"] = false;


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
        public ActionResult Edit(Pagos pagos)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.strUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = new HttpResponseMessage();

            var id = pagos.idPago;
            bool esCrear = Convert.ToBoolean(TempData["esCrear"]);


            if (esCrear)
            {
                response = client.PostAsJsonAsync("api/Pagos", pagos).Result;
            }
            else
            {
                response = client.PutAsJsonAsync($"api/Pagos/{id}", pagos).Result;
            }

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
