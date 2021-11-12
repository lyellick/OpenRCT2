using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenRCT2.Fluxbot.Enums
{
    internal enum ServerCommands : int
    {
		SEND_TOKEN = 0, /* ??? */
		MAP_DATA = 1,
		CHAT_MESSAGE = 2,

		PLAYERLIST = 5,
		HEARTBEAT = 6,
		something_join = 9, /* ??? */
		JOINED_LEFT = 12,
		GROUPS = 11,
		GET_TOKEN = 13,
		CUSTOM_OBJECT = 14,
		JOIN_GAME = 15, /* also init the map download? */
		ACTION = 16,
		SCRIPT = 20,

		GET_MAP = 21 /* ??? */
    }
}
