using Microsoft.AspNetCore.Mvc;

namespace PatientAPI.Services
{
    public interface IPatientService
    {
        IActionResult GetAllPatients();
        IActionResult GetPatientById(int id);
        IActionResult AddPatient(Patient patient);
        IActionResult EditPatient(int id,Patient patient);
        IActionResult DeletePatient(int id);

    }
}
