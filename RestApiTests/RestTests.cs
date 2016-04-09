using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Collections;
using System.Net;
using System.Linq;

namespace RestApiTests
{
    [TestClass]
    public class RestTests
    {
        [TestMethod]
        public void ReturnPatientWith1Episode()
        {
            int TESTPATIENTID = 2;
            int TESTPATIENTEPISODEQUANTITY = 1;
            int TESTPATIENTEPISODEID = 4;

            var context = new RestApi.Models.PatientInMemoryContext();
            var controller = new RestApi.Controllers.PatientsController(context);

            var result = controller.Get(TESTPATIENTID);
            // Check that retrieve correct Patient
            Assert.AreEqual(result.PatientId, TESTPATIENTID);
            // Check that Patient has correct number of episodes
            Assert.AreEqual(result.Episodes.Count(), TESTPATIENTEPISODEQUANTITY);
            // check that Patient has correct Episode
            Assert.AreEqual(result.Episodes.First().EpisodeId, TESTPATIENTEPISODEID);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void ReturnPatientWith0Episodes()
        {
            // ID of Patient with no episodes
            int TESTPATIENTID = 3;

            var context = new RestApi.Models.PatientInMemoryContext();
            var controller = new RestApi.Controllers.PatientsController(context);

            try
            {
                var result = controller.Get(TESTPATIENTID);
            }
            catch (HttpResponseException ex)
            {
                // Should throw this
                Assert.AreEqual(ex.Response.StatusCode, HttpStatusCode.NotFound, "404 received");
                throw;
            }
        }

    }
}
