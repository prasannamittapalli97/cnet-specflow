using NUnit.Framework;
using QualiframeNunit.DTO;
using QualiframeNunit.ReusableFunctions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace QualiframeNunit.stepdefs
{
    [Binding]
    class RestSharpSteps
    {

        private string payload = "";
        private string endpoint = "";
        private CreateUserDTO content;
        private ListOfUsersDTO getResponse;
        private IRestResponse deleteResponse;


        [Given(@"I have endpoint (.*) with create user payload")]
        public void GivenIHaveEndpointWithCreateUserPayload(string reqEndPoint)
        {
            endpoint = reqEndPoint;
            payload = @"{
                                    ""name"": ""nametest"",
                                    ""job"": ""jobtest""
                                }";
        }

        [When(@"I create user")]
        public void WhenICreateUser()
        {
            RestHelper<CreateUserDTO> restApi = new RestHelper<CreateUserDTO>();
            var restUrl = restApi.SetUrl(endpoint);
            var restRequest = restApi.CreatePostRequest(payload);
            var response = restApi.GetResponse(restUrl, restRequest);
            content = restApi.GetContent<CreateUserDTO>(response);
        }

        [Then(@"verify the user is created successfully")]
        public void ThenVerifyTheUserIsCreatedSuccessfully()
        {
            Console.WriteLine("Content:" + content.Job + "  ::: " + content.Name);
            Assert.AreEqual(content.Name, "nametest", "Name is coming wrong frm api");
            Assert.AreEqual(content.Job, "jobtest", "Job is coming wrong from api");
        }

        [Given(@"I have an endpoint (.*)")]
        public void GivenIHaveAnEndpointUsersPage(string reqEndPoint)
        {
            endpoint = reqEndPoint;
        }

        [When(@"I call get users")]
        public void WhenICallGetUsers()
        {
            RestHelper<CreateUserDTO> restApi = new RestHelper<CreateUserDTO>();
            var restUrl = restApi.SetUrl(endpoint);
            var restRequest = restApi.CreateGetRequest();
            var response = restApi.GetResponse(restUrl, restRequest);
            getResponse = restApi.GetContent<ListOfUsersDTO>(response);
        }

        [Then(@"verify the user data returned successfully")]
        public void ThenVerifyTheUserDataReturnedSuccessfully()
        {
            Console.WriteLine("Get Response:" + getResponse.Page + "  ::: " + getResponse.Data.Count);
            List<Data> dataList = getResponse.Data;
            Assert.AreEqual(2, getResponse.Page, "Page Number should be 2");
            Assert.IsNotNull(dataList.First().Email, "Email should not be null");
            Assert.IsNotNull(dataList.First().first_name, "First Name should not be null");
        }

        [When(@"I call delete users")]
        public void WhenICallDeleteUsers()
        {
            RestHelper<CreateUserDTO> restApi = new RestHelper<CreateUserDTO>();
            var restUrl = restApi.SetUrl(endpoint);
            var restRequest = restApi.CreateDeleteRequest();
            deleteResponse = restApi.GetResponse(restUrl, restRequest);
        }

        [Then(@"verify the user has been deleted successfully")]
        public void ThenVerifyTheUserHasBeenDeletedSuccessfully()
        {
            Assert.AreEqual(HttpStatusCode.NoContent, deleteResponse.StatusCode, "Delete API Status code is coming wrong");
        }

        [Given(@"I have endpoint (.*) with update user payload")]
        public void GivenIHaveEndpointUsersWithUpdateUserPayload(string reqEndPoint)
        {
            endpoint = reqEndPoint;
            payload = @"{
                                    ""name"": ""updatenametest"",
                                    ""job"": ""updatejobtest""
                                }";
        }

        [When(@"I call put users")]
        public void WhenICallPutUsers()
        {
            RestHelper<CreateUserDTO> restApi = new RestHelper<CreateUserDTO>();
            var restUrl = restApi.SetUrl(endpoint);
            var restRequest = restApi.CreatePutRequest(payload);
            var response = restApi.GetResponse(restUrl, restRequest);
            content = restApi.GetContent<CreateUserDTO>(response);
        }

        [Then(@"verify the user has been updated successfully")]
        public void ThenVerifyTheUserHasBeenUpdatedSuccessfully()
        {
            Console.WriteLine("Content:" + content.Job + "  ::: " + content.Name);
            Assert.AreEqual(content.Name, "updatenametest", "Name is coming wrong frm api");
            Assert.AreEqual(content.Job, "updatejobtest", "Job is coming wrong from api");
        }



    }
}
