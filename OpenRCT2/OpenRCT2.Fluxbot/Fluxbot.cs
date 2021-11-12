using OpenRCT2.Fluxbot.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OpenRCT2.Fluxbot
{
    public class Fluxbot : IDisposable
    {
        private bool _disposed;

        private readonly string _ip;
        private readonly int _port;
        private readonly string _version;
        private readonly string _username;
        private readonly string _password;
        private readonly Socket _socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private bool _authenticated { get; set; }

        private int _buffer { get; set; }
        private int _bytes { get; set; }
        private int _type { get; set; }
        private int _data { get; set; }
        private int _body { get; set; }

        private int _inputBuffer { get; set; }
        private int _inputBytes { get; set; }
        private int _inputData { get; set; }
        private int _inputBody { get; set; }
        private int _inputID { get; set; }

        public bool IsConnectedToServer { get { return _socket.Connected; } }
        public bool IsAuthenticatedToServer { get { return _authenticated; } }

        public Fluxbot(string ip, int port, string version, string username, string password = "")
        {
            _ip = ip;
            _port = port;
            _version = version;
            _username = username;
            _password = password;

            _buffer = _inputBuffer = _bytes = _inputBytes = 65535;
            _type = _inputID = 65535 + 2;
            _data = _inputData = 65535 + 6;
            _body = _inputBody = 65535 + 6 + 20;

            ConnectToServer();
            LoginToServer();
        }

        private void ConnectToServer() => _socket.Connect(_ip, _port);

        private void LoginToServer()
        {
            _authenticated = false;

            Send(4, ServerCommands.GET_TOKEN);

            do
            {
                if (Recieve() != 0)
                    break;
            }
            while (_inputID != (int)ServerCommands.GET_TOKEN);

            SignToken();

        }

        private int Send(int header, ServerCommands action)
        {
            byte[] buffer = new byte[_buffer];
            _bytes = header;
            _type = (int)action;

            return _socket.Send(buffer, header + 2, SocketFlags.None);
        }

        private int Recieve()
        {
            int offset = 0, recived = 0;

            for (_inputBytes = 0; offset < 2 || offset - 2 < _inputBytes; offset += recived)
            {
                byte[] buffer = new byte[_inputBuffer + offset];

                recived = _socket.Receive(buffer, (2 + _inputBytes) - offset, SocketFlags.None);

                if (recived < 1)
                    return 0;
            }

            return offset;
        }

        private int SignToken()
        {
            return 0;
        }



        #region IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
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
