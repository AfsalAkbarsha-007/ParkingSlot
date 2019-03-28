using TouchLessVehicleDetails.Models;
using System.Collections.Generic;

namespace TouchLessVehicleDetails.ILogic
{
    public interface IParkingActivity
    {
        List<ParkingInputModel> _inputdata{get;set;}
        List<ParkingInputModel> GetInput();
        void SetInput();
        List<ActivityModel> GetParkingActivityDetails(List<ParkingInputModel> _inputdata);

        void AddInputDetails(string PlatNumber,bool IsEntrance,string TimeStamp,string AgentMACID);

    }
}