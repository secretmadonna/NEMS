using SecretMadonna.NEMS.Infrastructure.Common;
using SecretMadonna.NEMS.UI.WebApi.Models;
using System;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.WebSockets;

namespace SecretMadonna.NEMS.UI.WebApi.Controllers
{
    public class WebSocketController : BaseApiController
    {
        [HttpGet]
        public IHttpActionResult Connect()
        {
            if (HttpContext.Current.IsWebSocketRequest)
            {
                HttpContext.Current.AcceptWebSocketRequest(UserFunc);
            }
            return StatusCode(HttpStatusCode.SwitchingProtocols);
        }
        private async Task UserFunc(AspNetWebSocketContext aspNetWebSocketContext)
        {
            var webSocket = aspNetWebSocketContext.WebSocket;
            while (true)
            {
                var buffer = new ArraySegment<byte>(new byte[64]);
                var webSocketReceiveResult = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
                if (webSocket.State == WebSocketState.Open)
                {
                    var receiveMessage = Encoding.UTF8.GetString(buffer.Array, 0, webSocketReceiveResult.Count);
                    var sendMessage = "You send :" + receiveMessage + ". at" + DateTime.Now.ToLongTimeString();
                    buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(sendMessage));
                    await webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
