using chalesh_01.core.CodeFactory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace chalesh_01.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public static List<JObject> objList = new List<JObject>();
        [HttpPost("AdminMessage")]
        
        public IActionResult AdminMessage([FromBody] JObject data)
        {

            objList.Add(data);
            //In this function, the existence of the field is checked
            if (Utils.HasProperty(data, "message"))
            {
                //In this function, the value of that field is returned
                Console.WriteLine(Utils.GetPropertyValue(data, "message"));
            }
            // If it means that all received messages have the message field
            if (objList.Count == 3)
            {
                Console.WriteLine("*****The number of queues reached 10*****");
                for (int i = 0; i < objList.Count; i++)
                {
                    Console.WriteLine(Utils.GetPropertyValue(data, "message"));
                }
                //objList.Clear();
            }
            // Or if it means that if it reaches 10 all messages will be shown
            if (objList.Count == 3)
            {
                Console.WriteLine("*****The number of queues reached 10*****");

                for (int i = 0; i < objList.Count; i++)
                {
                    Console.WriteLine(objList[i].ToString());
                }
                objList.Clear();
            }
            return Ok(data);
        }
      
    }
}
