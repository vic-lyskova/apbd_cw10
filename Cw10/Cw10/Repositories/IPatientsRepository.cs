using Cw10.DTOs;
using Cw10.Models;

namespace Cw10.Repositories;

public interface IPatientsRepository
{
    Task<bool> DoesPatientExist(int idPatient);
    Task<ICollection<Patient>> GetPatients(int idPatient);
}