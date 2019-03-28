using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using TouchLessVehicleDetails.Logic;
using TouchLessVehicleDetails.Models;
using TouchLessVehicleDetails.ILogic;
using System;

namespace TouchLessVehicleDetails.Controllers
{
    [Route("get/ParkedVehicle")]
    [ApiController]
    public class GetParkedVehicleInfomrationController
    {
         private readonly IParkingActivity _iParkingActivity;

        public GetParkedVehicleInfomrationController(IParkingActivity iParkingActivity)
        {
            _iParkingActivity = iParkingActivity ?? throw new Exception("iparking object is null");
        }

        [Route("ActivityLog")]
        [Route("ActivityLog/{PlatNumber}/{IsEntrance}/{TimeStamp}/{AgentMACID}")]
        [HttpGet()]
        public  ActionResult<List<ActivityModel>> GetActivityLog(string PlatNumber=null,bool IsEntrance=false,string TimeStamp=null,string AgentMACID=null)
        {
            _iParkingActivity.SetInput();
            if(PlatNumber != null)
            _iParkingActivity.AddInputDetails(PlatNumber,IsEntrance,TimeStamp,AgentMACID);
            var value =_iParkingActivity.GetParkingActivityDetails(_iParkingActivity.GetInput());
            return value;
        }
        
    }

    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}