using SecretMadonna.NEMS.UI.TeacherWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.WebSockets;

namespace SecretMadonna.NEMS.UI.TeacherWebUI.Controllers
{
    public class WebSocketController : BaseController
    {
        private List<WebSocketModel> webSockets = new List<WebSocketModel>();

        [HttpGet]
        public ActionResult Connect()
        {
            if (HttpContext.IsWebSocketRequest)
            {
                HttpContext.AcceptWebSocketRequest(UserFunc);
            }
            return new HttpStatusCodeResult(HttpStatusCode.SwitchingProtocols);
        }
        private async Task UserFunc(AspNetWebSocketContext aspNetWebSocketContext)
        {
            var model = new WebSocketModel()
            {
                SecWebSocketKey = aspNetWebSocketContext.SecWebSocketKey,
                SecWebSocketProtocols = aspNetWebSocketContext.SecWebSocketProtocols?.ToList(),
                SecWebSocketVersion = aspNetWebSocketContext.SecWebSocketVersion,
                WebSocket = aspNetWebSocketContext.WebSocket,
                UserName = aspNetWebSocketContext.User.Identity.Name
            };
            webSockets.Add(model);
            while (true)
            {
                var buffer = new ArraySegment<byte>(new byte[64]);
                var webSocketReceiveResult = await model.WebSocket.ReceiveAsync(buffer, CancellationToken.None);
                if (model.WebSocket.State == WebSocketState.Open)
                {
                    var receiveMessage = Encoding.UTF8.GetString(buffer.Array, 0, webSocketReceiveResult.Count);
                    var sendMessage = "You send :" + receiveMessage + ". at" + DateTime.Now.ToLongTimeString();
                    buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(sendMessage));
                    await model.WebSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                }
                else
                {
                    break;
                }
            }
        }
    }
}