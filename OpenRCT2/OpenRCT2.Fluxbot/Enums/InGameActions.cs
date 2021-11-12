using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenRCT2.Fluxbot.Enums
{
    internal enum InGameActions : int
    {
		PLACE_TRACK = 0x03,
		DELETE_RIDE = 0x07,
		RENAME_RIDE = 0x0A,
		SET_RIDE_PROPERTY = 0x0B,
		PLACE_SMALL_SCENERY = 0x0F,
		PLACE_PATH = 0x11,
		TERRAFORM_PAINT = 0x14,
		RENAME_GUEST = 0x16,

		WATER_UP = 0x1B,
		WATER_DOWN = 0x1C,

		TERRAFORM_UP = 0x18,
		TERRAFORM_DOWN = 0x19,

		FIRE_STAFF = 0x20,
		SET_STAFF_TASK = 0x21,
		RENAME_PARK = 0x22,
		PLACE_WALL = 0x2A,

		PLACE_LARGE_SCENERY = 0x2C,

		SET_LOAN = 0x2E,

		CREATE_RIDE = 0x30,

		SCENERY_PAINT = 0x35,

		CLEAR_LANDSCAPE = 0x3A,

		SET_PLAYER_GROUP = 0x3F,

		KICK_PLAYER = 0x41,
		SET_CHEAT = 0x42,

		TILE_INSPECTOR = 0x46,
		SET_LANDSCAPE_CHANGES_INTEREST = 0x47,

		HIGHLIGHT_GUEST = 0x4E
	}
}
