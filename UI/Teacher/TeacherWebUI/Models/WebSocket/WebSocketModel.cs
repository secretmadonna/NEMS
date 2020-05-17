using System.Collections.Generic;
using System.Net.WebSockets;

namespace SecretMadonna.NEMS.UI.TeacherWebUI.Models
{
    public class WebSocketModel
    {
        public string SecWebSocketKey { get; set; }
        public List<string> SecWebSocketProtocols { get; set; }
        public string SecWebSocketVersion { get; set; }
        public WebSocket WebSocket { get; set; }
        public string UserName { get; set; }
    }
}