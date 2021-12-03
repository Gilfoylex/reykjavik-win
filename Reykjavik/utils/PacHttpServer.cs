using Reykjavik.view_models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XrayServer;

namespace Reykjavik.utils
{
    public class PacHttpServer
    {
        // 用一个常驻的单线程调度xray进程
        private Scheduler _scheduler = new(1, ThreadPriority.Normal);
        private HttpListener _listener = new ();
        public async void Start(int port)
        {
            await Task.Factory.StartNew(() =>
            {
                try
                {
                    _listener.Prefixes.Add($"http://127.0.0.1:{port}/");
                    _listener.Start();
                    while (_listener.IsListening)
                    {
                        var ctx = _listener.BeginGetContext(new AsyncCallback(ListenerCallBack), _listener);
                        ctx.AsyncWaitHandle.WaitOne();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                } 
            }, CancellationToken.None, TaskCreationOptions.None, _scheduler);
        }

        private void ListenerCallBack(IAsyncResult ar)
        {
            try
            {
                if (ar.AsyncState is not HttpListener listener)
                    return;

                if (!listener.IsListening)
                    return;

                var ctx = listener.EndGetContext(ar);
                var response = ctx.Response;
                var request = ctx.Request;
                if (request.RawUrl != null && string.Compare(request.RawUrl, $"/{models.DefaultXRayConfig.PacProxyFileName}") == 0)
                {
                    string responseString = MainViewModel.Instance.PacContent;
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                    // Get a response stream and write the response to it.
                    response.ContentLength64 = buffer.Length;
                    response.ContentType = "text/plain";
                    System.IO.Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            
        }

        
        public void Stop()
        {
            if (_listener.IsListening)
                _listener.Stop();
        }
    }
}
