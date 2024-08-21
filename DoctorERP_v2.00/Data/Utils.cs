using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls;

namespace HotelApp.Data
{
    public static class Utils
    {
        public static Color MainThemeColor;
        public static string MainFont = "Roboto";
        public static string MainFontMedium = "Roboto Medium";

        public static int? GetHouseKeeperIdByName(string name, BindingList<HouseKeeper> houseKeepers)
        {
            int? id = null;
            foreach (HouseKeeper hk in houseKeepers)
            {
                if (hk.Name == name)
                {
                    return hk.Id;
                }
            }
            return id;
        }

        public static string GetHouseKeepingStatus(HouseKeepingStatus houseKeepingStatus)
        {
            switch (houseKeepingStatus)
            {
                case HouseKeepingStatus.Clean:
                    return "Clean";
                case HouseKeepingStatus.NotClean:
                    return "Not clean";
                case HouseKeepingStatus.InProgress:
                    return "In progress";
                default:
                    return "N/A";
            }
        }

        public static string GetRoomType(ByanType ByanType)
        {
            switch (ByanType)
            {
                case ByanType.Cars:
                    return "Single";
                case ByanType.Driver:
                    return "Double";
                case ByanType.Company:
                    return "Triple";//"Family (3)";
                //case ByanType.Family:
                //    return "Family"; //"Family (4)";
                default:
                    return "N/A";
            }
        }
        internal static System.Drawing.Image GetRoomIconByHouseKeepingStatus(HouseKeepingStatus houseKeepingStatus)
        {
            switch (houseKeepingStatus)
            {
                case HouseKeepingStatus.Clean:
                    return DoctorERP_v2_00.Properties.Resources.GlyphCheck_small;
                case HouseKeepingStatus.NotClean:
                    return DoctorERP_v2_00.Properties.Resources.GlyphClose;
                case HouseKeepingStatus.InProgress:
                    return DoctorERP_v2_00.Properties.Resources.clock_small;
                default:
                    return null;
            }
        }

        internal static Room GetRoomById(int roomId, BindingList<Room> rooms)
        {
            Room r = null;
            foreach (Room room in rooms)
            {
                if (room.Id == roomId)
                {
                    return room;
                }
            }
            return r;
        }

        internal static string GetRoomStatus(RoomStatus roomStatus)
        {
            switch (roomStatus)
            {
                case RoomStatus.Reserved:
                    return "Reserved";
                case RoomStatus.Occupied:
                    return "Occupied";
                case RoomStatus.Available:
                    return "Available";
                case RoomStatus.CheckedOut:
                    return "Checked-Out";
                default:
                    return "N/A";
            }
        }

        //internal static System.Drawing.Image GetRoomImageByRoomType(ByanType ByanType)
        //{
        //    switch (ByanType)
        //    {
        //        case ByanType.Cars:
        //            return DoctorERP_v2_00.Properties.Resources.single;
        //        case ByanType.Driver:
        //            return DoctorERP_v2_00.Properties.Resources._double;
        //        case ByanType.Company:
        //            return DoctorERP_v2_00.Properties.Resources.tripple;
        //        default:
        //            return null;
        //    }
        //}

        //public static string GetBookingTypeByStatus(BookingStatus bk)
        //{
        //    switch (bk)
        //    {
        //        case BookingStatus.Reservation:
        //            return "Reservation";
        //        case BookingStatus.Actual:
        //            return "Actual";
        //        case BookingStatus.Cancelled:
        //            return "Cancelled";
        //        case BookingStatus.CheckedOut:
        //            return "Checked out";
        //        case BookingStatus.NoShow:
        //            return "No-show";
        //        default:
        //            return "N/A";
        //    }
        //}

        //public static Guest GetGuestById(BindingList<Guest> guests, string id)
        //{
        //    Guest g = null;
        //    foreach (Guest guest in guests)
        //    {
        //        if (guest.Id == id)
        //        {
        //            return guest;
        //        }
        //    }
        //    return g;
        //}

        internal static Image GetAvailableImageByTheme()
        {
            switch (ThemeResolutionService.ApplicationThemeName)
            {
                case "Material":
                    return DoctorERP_v2_00.Properties.Resources.free_room;
                case "MaterialPink":
                    return DoctorERP_v2_00.Properties.Resources.free_room_pink;
                case "MaterialTeal":
                    return DoctorERP_v2_00.Properties.Resources.free_room_teal;
                case "MaterialBlueGrey":
                    return DoctorERP_v2_00.Properties.Resources.free_room_bluegrey;
                default:
                    return DoctorERP_v2_00.Properties.Resources.free_room;
            }
        }
    }
}