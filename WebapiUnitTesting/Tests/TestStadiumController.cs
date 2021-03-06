﻿using Xunit;
using FBMWebApi.Controllers;
using FBMWebApi.Interfaces;
using FBMWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebapiUnitTesting.Tests
{
    public class TestStadiumController
    {
        private readonly IStadiumService stadiumService;


        [Fact]
        public void Test_GetbyID_Return_OkResult()
        {
            //Arrange  
            var controller = new StadiumController(stadiumService);
            //Act  
            var data = controller.Get(1);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Test_Post_Return_OkResult()
        {
            //Arrange  
            var controller = new StadiumController(stadiumService);
            var request =  new StadiumModel { StadiumID = 1, StadiumName = "Centurion" };
            //Act  
            var data = controller.Post(request);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Test_Put_Return_OkResult()
        {
            //Arrange  
            var controller = new StadiumController(stadiumService);
            var request = new StadiumModel { StadiumID = 1, StadiumName = "capetown" }; ;
            //Act  
            var data = controller.Put(1, request);

            //Assert  
            Assert.IsType<OkResult>(data);
        }

        [Fact]
        public void Test_Delete_Return_OkResult()
        {
            //Arrange  
            var controller = new StadiumController(stadiumService);
            var request = 1;
            //Act  
            var data = controller.Delete(request);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        

    }
}
