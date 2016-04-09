using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Collections;
using System.Net;

namespace RestApiTests
{
    [TestClass]
    public class RestTests
    {
        [TestMethod]
        public void ReturnPatientWith1Episode()
        {
            var context = new RestApi.Models.PatientInMemoryContext();
            var controller = new RestApi.Controllers.PatientsController(context);

            var result = controller.Get(2);
            Assert.AreEqual(((ICollection)result.Episodes).Count, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void ReturnPatientWith0Episodes()
        {
            var context = new RestApi.Models.PatientInMemoryContext();
            var controller = new RestApi.Controllers.PatientsController(context);

            try
            {
                var result = controller.Get(3);
            }
            catch (HttpResponseException ex)
            {
                Assert.AreEqual(ex.Response.StatusCode, HttpStatusCode.NotFound, "404 received");
                throw;
            }
        }

    }
}
