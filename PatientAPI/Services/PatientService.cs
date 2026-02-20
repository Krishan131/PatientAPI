using Microsoft.AspNetCore.Mvc;

namespace PatientAPI.Services
{
    public class PatientService : IPatientService
    {
        List<Patient> patients = new List<Patient>
        {
            new Patient { Id = 1, Name = "John Doe", Age = 24 , Type = "General" },
            new Patient { Id = 2, Name = "Jane Smith", Age = 27, Type = "Orthopedic" },
            new Patient { Id = 3, Name = "Alice Johnson", Age = 28, Type = "Endocrinology" }
        };
        public IActionResult GetAllPatients()
        {
            return new OkObjectResult(patients);
        }
       public IActionResult GetPatientById(int id)
        {
            var patient = patients.FirstOrDefault(s => s.Id == id);
            if (patient == null)
                return new NotFoundObjectResult("Patient not found");

            return new OkObjectResult(patient);
        }
        public IActionResult AddPatient(Patient patient)
        {
              patients.Add(patient);
              return new OkObjectResult($"Add patient with name {patient.Name}");

        }
        public IActionResult EditPatient(int id, Patient newPatient)
        {
            var patient = patients.FirstOrDefault(s => s.Id == id);
            if (patient == null)
                return new NotFoundObjectResult("Patient not found");

            patient.Name = newPatient.Name;
            patient.Age = newPatient.Age;
            patient.Type = newPatient.Type;
            return new OkObjectResult($"Edit patient with id {id} and name {patient.Name}");
        }
        public IActionResult DeletePatient(int id)
        {
            var patient = patients.FirstOrDefault(s => s.Id == id);
            if (patient == null)
                return new NotFoundObjectResult("Patient not found");
            patients.Remove(patient);
            return new OkObjectResult($"Delete patient with id {id}");
        }
    }
}
