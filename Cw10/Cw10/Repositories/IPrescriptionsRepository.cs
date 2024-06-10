using Cw10.DTOs;
using Cw10.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw10.Repositories;

public interface IPrescriptionsRepository
{
    Task<bool> DoesPatientExist(AddPatientDTO addPatientDto);
    Task AddPatient(AddPatientDTO addPatientDto);
    Task<bool> DoesMedicamentExist(AddMedicamentToPrescriptionDTO addMedicamentToPrescriptionDto);
    Task AddPrescription(AddPrescriptionDTO addPrescriptionDto);
    Task<Medicament> GetMedicament(int id);
}