using System;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace RestSharpSpeckflow.Features
{
    [Binding]
    public sealed class Hooks
    {
        

        [BeforeScenario]
        public void BeforeScenario()
        {
            /*string strCmdText;
           strCmdText = @"/k json-server .\db.json --port 3004";
           Process.Start("cmd.exe", strCmdText);*/

            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/c json-server .\\db.json --port 3004";
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;

            process.OutputDataReceived += (s, e) => Console.WriteLine(e.Data);
            process.ErrorDataReceived += (s, e) => Console.WriteLine(e.Data);
            process.Start();

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            
            string strCmdText;
            strCmdText = @"/c taskkill /IM node.exe /F";
            Process.Start("cmd.exe", strCmdText);  
            
        }
    }
}
