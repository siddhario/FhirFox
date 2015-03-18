using System;
using Moq;
using Xunit;
using FhirFox.Controllers;
using FhirFox.Services;
using Hl7.Fhir.Model;
using Hl7.Fhir;
using System.Threading.Tasks;
using FhirFox.Models;

namespace FhirFoxUnitTest
{
    public class FhirControllerUnitTest
    {
        [Fact]
        public void Test1()
        {
            Mock<IFhirService> mockFhirService = new Mock<IFhirService>();

            //mockFhirService.Setup(ss => ss.GetResourceById(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<Base>(new Patient()));

            FhirController fhirController = new FhirController(mockFhirService.Object);
            Task<Base> p = fhirController.Get("1", "Patient");

            mockFhirService.Verify(ms => ms.GetResourceById(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }
    }
}
