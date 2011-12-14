using System;
using System.IO;
using System.Net;   
using System.Text;
using System.Threading;
using NUnit.Framework;

//http://msdn.microsoft.com/en-us/library/system.net.httpwebrequest.begingetresponse.aspx

namespace CSharpClassLibrary
{
    [TestFixture]
    public class Async
    {
        [Test]
        public void DownloadsHttp()
        {
            var request = HttpWebRequest.Create("http://www.google.com");
            var buffer = new byte[32000];
            request.BeginGetResponse(result =>
                                         {
                                             Console.Out.WriteLine("GetResponse..callback{0}", Thread.CurrentContext.ContextID);
                                             var response = request.EndGetResponse(result);
                                             var stream = response.GetResponseStream();
                                             stream.BeginRead(buffer , 0,buffer.Length , asyncResult =>
                                                                                             {
                                                                                                 stream.EndRead(
                                                                                                     asyncResult);
                                                                                                 Console.Out.WriteLine("GetRead..callback{0}", Thread.CurrentContext.ContextID);
                                                                                             }, null);
                                             Console.Out.WriteLine("Fired GetRead..{0}", Thread.CurrentContext.ContextID);
                                         }, null);
            Console.Out.WriteLine("Fired GetResponse..{0}", Thread.CurrentContext.ContextID);
            
            Thread.Sleep(3000);
            Console.Out.WriteLine("main thread............{0}", Thread.CurrentContext.ContextID);
            Console.Out.WriteLine("buffer = {0}", Encoding.ASCII.GetString(buffer));            
        }
    }
}