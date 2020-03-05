using interaction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace interaction.Controllers
{
    public class InteractionControllerAPI : ApiController
    {
        //public HttpResponseMessage
        public List<interaction.Models.Interaction> GetData(string Data)
        {
            using (ReportServerEntities db = new ReportServerEntities()) {
                Interaction result = new Interaction();
                List<Interaction> list = db.Interactions.Where(x =>
                (x.description == result.description &&
                 x.diseaseCode == result.drugCode &&
                 x.type == result.type
                )).ToList();
            }
            return null;
        }
    }
}
