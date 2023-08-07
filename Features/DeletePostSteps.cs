using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow;

namespace RestSharpSpeckflow.Features
{
    [Binding]
    public class DeletePostSteps
    {

        public RestClient client = new RestClient("http://localhost:3004/");
        public RestRequest restRequest = new RestRequest();
        public JObject obs = new JObject();
        public JArray ary = new JArray();
        public int postId = 6;

        [Given(@"I perform a delete request")]
        public void GivenIPerformADeleteRequest()
        {
            restRequest = new RestRequest("posts/{postid}", Method.Delete);
        }
        
        [Given(@"I input target post id")]
        public void GivenIInputTargetPostId()
        {
            restRequest.AddUrlSegment("postid", postId);
        }
        
        [When(@"I send a delete request")]
        public void WhenISendADeleteRequest()
        {
            var response = client.Execute(restRequest);
        }
        
        [Then(@"the post is removed from list")]
        public void ThenThePostIsRemovedFromList()
        {
            
            restRequest = new RestRequest("posts/"+postId, Method.Get);
            var response = client.Execute(restRequest);
            
            System.Console.WriteLine("Request status code: " + (int)response.StatusCode);
            Assert.AreEqual((int)response.StatusCode,404 , "Post has not been removed");
        }
    }
}
