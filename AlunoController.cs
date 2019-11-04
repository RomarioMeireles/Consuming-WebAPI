using ConsumingWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ConsumingWebApi.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/Aluno");
                //HTTP GET
                var responseTask = client.GetAsync("aluno");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<Aluno[]>();
                    readTask.Wait();

                    var students = readTask.Result;

                   
                }
            }


            return View();
        }

        public ActionResult Post()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Post(Aluno aluno)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44380/api/Aluno");
            var postTask = client.PostAsJsonAsync("aluno", aluno);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<Aluno>();
                readTask.Wait();

                var insertedStudent = readTask.Result;

            }
            else
            {
            }
            return View();
        }
    }
}


//Install-Package System.Net.Http.Formatting.Extension -Version 5.2.3