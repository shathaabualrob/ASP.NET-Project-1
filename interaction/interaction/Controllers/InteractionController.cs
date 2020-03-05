using System;
using interaction.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

namespace interaction.Controllers
{
    public class InteractionController : Controller
    {
        // GET: Interaction
        public ActionResult Index(Interaction search)
        {
            IEnumerable<Interaction> obj = null;
            Interaction obj2 = new Interaction();

            if(search !=null)
            {
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("http://localhost:10557/");
                var consumap1 = hc.GetAsync("api/Interaction?Data=" + search);
                consumap1.Wait();//the time needed to get the data and return it
                var readdata = consumap1.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    var displaydata = readdata.Content.ReadAsAsync<List<Interaction>>();
                    displaydata.Wait();
                    obj = displaydata.Result;
                    ViewBag.resultList = obj;
                }
            }
            return View();
        }
    }
}