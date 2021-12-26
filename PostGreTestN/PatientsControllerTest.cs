/*....https://www.c-sharpcorner.com/article/crud-operations-unit-testing-in-asp-net-core-web-api-with-xunit/   */

using System;
using System.Collections.Generic;
using System.Text;
using postgre1;
using postgre1.DataAccess;
using postgre1.Models;
using postgre1.Controllers;
using Moq;
using Autofac.Extras.Moq;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using System.Linq;
using FluentAssertions;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Hosting;
using System.Web.Http.Results;


namespace PostGreTestN
{
    public class PatientsControllerTest
    {
        private readonly Mock<IDataAccessProvider> service;

        public PatientsControllerTest()
        {
            service = new Mock<IDataAccessProvider>();
        }

        [Fact]
        //naming convention MethodName_expectedBehavior_StateUnderTest
        public void GetEmployee_ListOfEmployee_EmployeeExistsInRepo()
        {
            //arrange
            var employee = GetSamplePatients();
            service.Setup(x => x.GetPatientRecords())
                .Returns(GetSamplePatients);
            var controller = new PatientsController(service.Object);

            //act
            var actionResult = controller.Get();
            //var result = actionResult.result as OkObjectResult;
            //var actual = actionResult.value as IEnumerable<Patient>;

            //assert
            //Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(GetSamplePatients().Count(), actionResult.Count());
        }

        [Fact]
        public void GetEmployeeById_EmployeeObject_EmployeewithSpecificeIdExists()
        {
            //arrange
            var Patients = GetSamplePatients();
            var firstPatient = Patients[0];
            service.Setup(x => x.GetPatientSingleRecord((long)1)).Returns(firstPatient);
            var controller = new PatientsController(service.Object);

            //act 
            var result = controller.Details((long)1);
            //var result = result.Result as OkObjectResult;

            //Assert
            //Assert.IsType<OkObjectResult>(result);
            result.Should().BeEquivalentTo(firstPatient);
        }

        [Fact]
        public void GetEmployeeById_shouldReturnBadRequest_EmployeeWithIDNotExists()
        {
            //arrange
            var Patients = GetSamplePatients();
            var firstPatient = Patients[0];
            service.Setup(x => x.GetPatientSingleRecord((long)1)).Returns(firstPatient);
            var controller = new PatientsController(service.Object);

            //Act
            var actionResult = controller.Details((long)2);

            //Assert
            Assert.IsType<NotFoundObjectResult>(actionResult);

        }



        private List<Patient> GetSamplePatients()
        {
            List<Patient> output = new List<Patient>
            {
                new Patient
                {
                    name = "Jhon",
                    address = "Bhilai",
                    city = "Bhilai",
                    age = 30,
                    gender = "Male"
                },
                new Patient
                {
                    name = "Aniket",
                    address = "Durg",
                    city = "Durg",
                    age = 32,
                    gender = "Male"
                },
                new Patient
                {
                    name = "Rohit",
                    address = "Raipur",
                    city = "RAIPUR",
                    age = 31,
                    gender = "Male"
                }
            };
            return output;
        }

    }

}
