using EmViCi.Data;
using EmViCi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace EmViCi.Controllers
{
    [Route("[controller]")]
    public class DoggoController : Controller
    {
        private DataDogs _data;
        private IListOfDogs _listOfDogs;
        public DoggoController(IListOfDogs listOfDogs)
        {
            _data = DataDogs.GetInstance();
            _listOfDogs = listOfDogs;
        }
        [HttpGet]
        [Route("GetTheDogs")]
        public ActionResult GetDogs()
        {
            return Ok(_listOfDogs.GetRandomListOfDogs());
        }

        [HttpGet]
        [Route("GetDog/{id}")]
        public ActionResult GetDog(int id)
        {

            return Ok(_data.takeDog(id));
        }
       
    }
}
