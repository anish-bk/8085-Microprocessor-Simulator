using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MicroSim.ViewModels;

namespace MicroSim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoAppController : ControllerBase
    {
        private IConfiguration _configuration;
        public TodoAppController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetNotes")]
        public JsonResult GetNotes()
        {
            string s1 = "AB";
            HexCodes hexCodes = new HexCodes();
            hexCodes.takeOpCodes(s1);
            hexCodes.showCodes();
            Decode dc = new Decode(hexCodes.codeHistory);
            dc.operation();
            var responseData = new
            {
                A = dc.registers["A"],
                B = dc.registers["B"],
                C = dc.registers["C"],
                D = dc.registers["D"],
                E = dc.registers["E"],
                H = dc.registers["H"],
                L = dc.registers["L"],
                S = dc.flags["S"],
                Z = dc.flags["Z"],
                AC = dc.flags["AC"],
                P = dc.flags["P"],
                CY = dc.flags["CY"],
                SP = Convert.ToString(dc.stackPointer)
            };

            // Return a JSON response
            return new JsonResult(responseData);
        }
        [HttpPost]
        [Route("AddNotes")]
        public JsonResult AddNotes([FromBody] NameViewModel nameModel)
        {
            var model = nameModel;
            var s1 = model.Name[1];
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(nameModel);
            JObject jsonData = JObject.Parse(jsonString);
            Console.WriteLine(jsonData);
            string value1 = jsonData["Name"]?.ToString();
            HexCodes hexCodes = new HexCodes();
            hexCodes.takeOpCodes(value1);
            hexCodes.showCodes();
            Decode dc = new Decode(hexCodes.codeHistory);
            dc.operation();
            var responseData = new
            {
                A = dc.registers["A"],
                B = dc.registers["B"],
                C = dc.registers["C"],
                D = dc.registers["D"],
                E = dc.registers["E"],
                H = dc.registers["H"],
                L = dc.registers["L"],
                S = dc.flags["S"],
                Z = dc.flags["Z"],
                AC = dc.flags["AC"],
                P = dc.flags["P"],
                CY = dc.flags["CY"],
                SP = Convert.ToString(dc.stackPointer),
                d = value1.Substring(0, 2)
            };

            return new JsonResult(responseData);
       
        }

    }
}
