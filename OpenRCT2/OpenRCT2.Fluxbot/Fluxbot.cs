using Newtonsoft.Json;
using OpenRCT2.Fluxbot.Enums;
using OpenRCT2.Fluxbot.Models;
using OpenRCT2.Fluxbot.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OpenRCT2.Fluxbot
{
    public class Fluxbot : IDisposable
    {
        private bool _disposed;

        private readonly string _ip;
        private readonly int _port;
        private readonly Socket _socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private readonly string _version;
        private readonly string _username;
        private readonly string _password;

        public bool IsConnectedToServer { get { return _socket.Connected; } }
        public bool IsAuthenticatedToServer { get { return false; } }

        public Fluxbot(string ip, int port, string version, string username, string password = "")
        {
            _ip = ip;
            _port = port;
            _version = version;
            _username = username;
            _password = password;

            _socket.Connect(_ip, _port);

            // Handshake
            byte[] buffer = new byte[0xffff];
            byte[] recieve = new byte[0xffff];
            _socket.Send(buffer, 6, SocketFlags.None);
            int recived = 0;
            do
            {
                recived = _socket.Receive(recieve, 6, SocketFlags.None);
                string response = Encoding.ASCII.GetString(recieve, 0, 6);
            } while (recived > 0);

            //RSA rsa = RSA.Create();

            //File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), $"{_username.ToLower()}-priv.txt"), rsa.ExportPrivateKey());
            //File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), $"{_username.ToLower()}-pub.txt"), rsa.ExportPublicKey());

            string signin = $"{_version}0{_username}0{(!string.IsNullOrEmpty(_password) ? _password : "")}0{{pub}}0";
        }

        public static async Task<ServerList> GetServerListAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("https://servers.openrct2.io/");
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ServerList>(json);
            }
        }

        #region IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _socket.Shutdown(SocketShutdown.Both);
                    _socket.Close();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
