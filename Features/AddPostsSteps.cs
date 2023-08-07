using System;
using TechTalk.SpecFlow;
using Newtonsoft.Json.Linq;
using RestSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace RestSharpSpeckflow.Features
{

    [Binding]
    public class AddPostSteps
    {

        
        public RestClient client = new RestClient("http://localhost:3004/");
        public RestRequest restRequest = new RestRequest();
        public JObject obs = new JObject();
        public string author = "Ruby";
       


        [Given(@"I perform a post request")]
        public void GivenIPerformAPostRequest()
        {
            restRequest = new RestRequest("posts/", Method.Post);
            
        }

        [Given(@"I input unique id title author")]
        public void GivenIInputUniqueIdTitleAuthor()
        {

            restRequest.AddBody(new Model.Posts() { id = "6", title = "Witchcraft", author = author });
            
        }

        [When(@"I send add post request")]
        public void WhenISendAddPostRequest()
        {
            
                var response = client.Post(restRequest);
                obs = JObject.Parse(response.Content);
         
        }

        [Then(@"valid post is created")]
        public void ThenValidPostIsCreated()
        {

            Assert.AreEqual(author, obs["author"].ToString(), "Post was not added correctly.");
            Console.WriteLine("The following post has been added: " + obs);

           
        }

       
    }

}

