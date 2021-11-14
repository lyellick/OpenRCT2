using OpenRCT2.Fluxbot;
using OpenRCT2.Fluxbot.Enums;
using System.Net.Sockets;
using System.Text;

string[] argument = args;

string ip = "127.0.0.1";
int port = 11753;
string password = "fluxbot";
string botname = "Fluxbot";
string version = "0.3.5-0";

using (Fluxbot fluxbot = new Fluxbot(ip, port, version, botname, password))
{
    while (fluxbot.IsConnectedToServer && fluxbot.IsAuthenticatedToServer)
    {
        
    }
}

Console.WriteLine("");