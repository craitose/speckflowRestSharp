using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow;

namespace RestSharpSpeckflow.Features

{
    [Binding]
    public class GetPostsSteps
    {

        

        public RestClient client = new RestClient("http://localhost:3004/");
        public RestRequest restRequest = new RestRequest();
        public JArray ary = new JArray();
        public string author = "John Wayne";

        [Given(@"I perform a get request")]
        public void GivenIPerformAGetRequest()
        {
            restRequest = new RestRequest("posts/", Method.Get);
        }
        
        [When(@"I send a get request")]
        public void WhenISendAGetRequest()
        {
            var response = client.Get(restRequest);
            ary = JArray.Parse(response.Content);
        }
        
        [Then(@"the first post is valid")]
        public void ThenTheFirstPostIsValid()
        {
            string first = ary[0]["author"].ToString();
            Assert.AreEqual(author, first, "First post author is unexpected.");
            System.Console.WriteLine("The first author is "+first);
        }
    }
}
