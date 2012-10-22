using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SignalR.Hosting.Self;
using SignalR.Client.Hubs;
using Microsoft.CSharp;
namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext) 
        {
            var url = "http://localhost:8081/";
            var server = new Server(url);

            server.ConnectionManager.GetHubContext<WebApplication.ChatHub_4>();

            server.MapHubs();

            server.Start();
        }

        [TestMethod]
        public void TestSendMessage()
        {
            
            var are = new System.Threading.AutoResetEvent(false);

            var connection = new SignalR.Client.Hubs.HubConnection("http://localhost:8081/");

            var chatHub = connection.CreateProxy("chatHub_4");

            connection.Start().ContinueWith(action =>
            {
                if (action.IsFaulted)
                {
                    Assert.Fail(string.Format("Error starting connection: {0}.", action.Exception.ToString()));
                }
                else
                    Console.WriteLine("Connection started.");
            }).Wait();

            bool addMessageExecuted = false;
            
            chatHub.On<WebApplication.ChatHub_4.MessageData>("AddMessage", (data) => {

                 
                Assert.AreEqual("test name", data.UserName);
                Assert.AreEqual("hallo test world!", data.Message);

                addMessageExecuted = true; 
                are.Set(); 
            
            });
            
            chatHub.Invoke("SendMessage", new { UserName = "test name", Message = "hallo test world!" }).ContinueWith(task =>
            {
                if (task.IsFaulted)
                    Assert.Fail(string.Format("'SendMessage' invoke failed: {0}.", task.Exception.ToString()));
                else
                    Console.WriteLine("'SendMessage' invoke completed.");

            }).Wait();

            are.WaitOne(TimeSpan.FromSeconds(5));

            Assert.IsTrue(addMessageExecuted);
        }

        
    }
}
