using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace RestSharpSpeckflow
{

    [TestClass]
    public class UnitTest1
    {

        [ClassInitialize]
        public static void BeforeAnyTests(TestContext context)
        {
            
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.StandardInput.WriteLine("cd jsonServer");
            process.StandardInput.WriteLine("json-server .\\db.json --port 3004");
            

        }

        [TestMethod]
        public void GetMethod()
        {
            //Store client url
            var client = new RestClient("http://localhost:3004/");
            
            //Create request
            var request = new RestRequest("posts/{postid}", Method.Get);
            request.AddUrlSegment("postid",6);

            //Execute and store request response
            var response =  client.GetAsync(request);
            
            //Deseriailze response json objects
            JObject obs = JObject.Parse(response.Result.Content);

            Assert.AreEqual("Ruby", obs["author"].ToString(), "Author is not correct");

            System.Console.WriteLine(obs.ToString());
            
        }

        [TestMethod]
        public void PostMethod()
        {
            //Store client url
            var client = new RestClient("http://localhost:3004/");

            //Create request
            var request = new RestRequest("posts/", Method.Post);
            request.AddBody(new Model.Posts() { id = "1",title = "Pistols",author = "John Wayne"});
           

            
            var response = client.PostAsync(request);

            JObject obs = JObject.Parse(response.Result.Content);

            Assert.AreEqual("John Wayne", obs["author"].ToString(), "Post was added correctly.");

            System.Console.WriteLine(response.ToString());

        }

        [ClassCleanup]
        public static void AfterAllTests()
        {
            Process process = new Process();
            process.Close();
        }
    }
}
