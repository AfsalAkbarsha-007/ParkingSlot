using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System;
using System.Collections.Generic;
using TouchLessVehicleDetails.Models;
using TouchLessVehicleDetails.ILogic;

namespace TouchLessVehicleDetails.Logic
{
    public class FrameParkingActivityDetails:IParkingActivity
    {
        public List<ParkingInputModel> _inputdata{get;set;}
        public List<ParkingInputModel> GetInput()
        {
            return  _inputdata;
        }
        public void SetInput()
        {
            _inputdata= dummyInput();
        }
        private List<ParkingInputModel> dummyInput()
         {
            List<ParkingInputModel> parkingDetails = new List<ParkingInputModel>
            {
                   new ParkingInputModel{SessionId = 123, 
                   PlatNumber="ABC1234", 
                   PlatNumberImageUrl=new Uri("/poll/data/date0/img.png").AbsolutePath,
                   IsEntrance=true,
                   TimeStamp="5901291",
                   AgentMACID="00-14-22-01-23-41"
                   },

                   new ParkingInputModel{SessionId = 123, 
                   PlatNumber="ABC1234", 
                   PlatNumberImageUrl=new Uri("/poll/data/date0/img.png").AbsolutePath,
                   IsEntrance=false,
                   TimeStamp="6091300",
                   AgentMACID="00-14-22-01-23-48"
                   },

                   new ParkingInputModel{SessionId = 143, 
                   PlatNumber="ABC1234", 
                   PlatNumberImageUrl=new Uri("/poll/data/date1/img.png").AbsolutePath,
                   IsEntrance=true,
                   TimeStamp="6201291",
                   AgentMACID="00-14-22-01-23-42"
                   }

            };

          return parkingDetails;

      }
        public List<ActivityModel> GetParkingActivityDetails(List<ParkingInputModel> _inputdata)
       {
        
        var ListOfActivityModel = 
            from idata in _inputdata
            select new ActivityModel
            {
                Entrance = idata.IsEntrance ? new ActivityDetails(idata):null,
                Exit = !idata.IsEntrance ? new ActivityDetails(idata):null,
            };

           var newListOfActivityModel = ListOfActivityModel.ToList();

            return newListOfActivityModel;
       }
       
       public void AddInputDetails(string PlatNumber,bool IsEntrance,string TimeStamp,string AgentMACID)
       {

          var value =new ParkingInputModel{
              SessionId=143,
              PlatNumberImageUrl="/poll/data/date0/img2.png",
              IsEntrance=IsEntrance,
              PlatNumber=PlatNumber,
              TimeStamp=TimeStamp,
              AgentMACID=AgentMACID
          };

            _inputdata.Add(value);

       }
    }


}