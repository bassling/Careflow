using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using RestApi.Models;

namespace RestApi.Controllers
{
    public class PatientsController : ApiController
    {
        private IPatientContext context;
        public PatientsController()
        {
            this.context = new PatientContext();
        }

        public PatientsController(IPatientContext patientContext)
        {
            this.context = patientContext;
        }

        [HttpGet]
        public Patient Get(int patientId)
        {
            var patientsAndEpisodes =
                from p in this.context.Patients
                join e in this.context.Episodes on p.PatientId equals e.PatientId
                where p.PatientId == patientId
                select new {p, e};

            if (patientsAndEpisodes.Any())
            {
                var first = patientsAndEpisodes.First().p;
                first.Episodes = patientsAndEpisodes.Select(x => x.e).ToArray();
                return first;
            }

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
    }
}