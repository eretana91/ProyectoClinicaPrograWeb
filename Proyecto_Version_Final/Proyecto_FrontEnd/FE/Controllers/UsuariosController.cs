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

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.strUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/Usuarios").Result;   

            if (response.IsSuccessStatusCode)
            {
                ViewBag.OperacionExitosa = true;
                ViewBag.result = response.Content.ReadAsAsync<List<Usuario>>().Result;
            }
            else
            {
                ViewBag.OperacionExitosa = false;
                ViewBag.result = "Error al consultar la información";  
            }                       
                         
            return View();
        }

        public ActionResult EditarUsuario(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.strUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Usuarios/"+id.ToString()).Result;

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.OperacionExitosa = false;
                ViewBag.result = "Error al consultar la información";
            }
            else
            {
                ViewBag.OperacionExitosa = true;
            }

            return View(response.Content.ReadAsAsync<Usuario>().Result);
        }

        [HttpPost]
        public ActionResult EditarUsuario(Usuario usuario)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalVariables.strUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var id = usuario.Cedula;

            HttpResponseMessage response = client.PutAsJsonAsync($"api/Usuarios/{id}", usuario).Result;

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
            HttpResponseMessage response = client.DeleteAsync("api/Usuarios/"+id.ToString()).Result;

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
