using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientAPI.Services;
namespace PatientAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PatientController : ControllerBase
    {
        
        private readonly IPatientService _patientService ;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [HttpGet]
        public IActionResult GetAllPatients()
        {
            return _patientService.GetAllPatients();
        }
        
        [HttpGet("{id}")]
        public IActionResult GetPatient(int id) {
            return _patientService.GetPatientById(id);
        }
        [HttpPost]
        public IActionResult AddPatient([FromBody]Patient patient)
        {
            return _patientService.AddPatient(patient);
        }
        [HttpPut("{id}")]
        public IActionResult EditPatient([FromRoute]int id, [FromBody]Patient Newpatient) { 
              
           return _patientService.EditPatient(id, Newpatient);

        }
    }
}
