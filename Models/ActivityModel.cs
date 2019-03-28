using System.Reflection.Metadata;
using System.Collections.Generic;
using System;

namespace TouchLessVehicleDetails.Models
{
     public class ActivityModel
     {
        public ActivityDetails Entrance { get; set; }

        public ActivityDetails Exit { get; set; }
     }
     
    public class ActivityDetails 
    {
        public int SessionID { get; set; }
        public string INAgentMACID { get; set; }
        public string OUTAgentMACID { get; set; }
        public PlateNumberDetails PlateNumber { get ;  set; }

        public ActivityDetails(ParkingInputModel idata)
        {
           SessionID=idata.SessionId;
           INAgentMACID= idata.IsEntrance ? idata.AgentMACID : null;
           OUTAgentMACID=!idata.IsEntrance ? idata.AgentMACID:null;
           PlateNumber=new PlateNumberDetails(idata);
        }
    }
    public class PlateNumberDetails
    {
       public String ImageUrl{get;set;}
        public string number{get;set;}
        public string Timestamp{get;set;}

       public PlateNumberDetails(ParkingInputModel idata)
        {
            ImageUrl=idata.PlatNumberImageUrl;
            number=idata.PlatNumber;
            Timestamp=idata.TimeStamp;
        }

    }


    public class ParkingInputModel
    {
       public  int SessionId{ get;  set;}
       public  string PlatNumber { get; set; }
       public  String PlatNumberImageUrl { get; set; }
       public bool IsEntrance{get;set;}
       public  string TimeStamp { get; set; }
       public string AgentMACID{get;set;}
    }

}