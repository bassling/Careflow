using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Collections;
using System.Net;
using System.Linq;
using RestApi.Models;
using Microsoft.Practices.Unity;
using Microsoft.Practices.ServiceLocation;
using RestApi.Controllers;

namespace RestApiTests
{
    [TestClass]
    public class RestTests
    {
        // Each test should be properly independent, so initialise the Controller every time.
        private PatientsController Controller
        {
            get
            {
                var container = RestApi.UnityConfig.GetUnityContainer();
                var context = container.Resolve<IPatientContext>("test_context");
                var controller = new RestApi.Controllers.PatientsController(context);
                return controller;
            }
        }

        [TestMethod]
        public void ReturnPatientWith1Episode()
        {
            int TESTPATIENTID = 2;
            int TESTPATIENTEPISODEQUANTITY = 1;
            int TESTPATIENTEPISODEID = 4;

            var result = Controller.Get(TESTPATIENTID);
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

            try
            {
                var result = Controller.Get(TESTPATIENTID);
            }
            catch (HttpResponseException ex)
            {
                // Should have no episodes so should throw this
                Assert.AreEqual(ex.Response.StatusCode, HttpStatusCode.NotFound, "404 received");
                throw;
            }
        }

    }
}
