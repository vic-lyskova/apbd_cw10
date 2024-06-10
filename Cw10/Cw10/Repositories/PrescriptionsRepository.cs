using Cw10.Context;
using Cw10.DTOs;
using Cw10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cw10.Repositories;

public class PrescriptionsRepository : IPrescriptionsRepository
{
    private readonly ApbdContext _context;

    public PrescriptionsRepository(ApbdContext context)
    {
        _context = context;
    }

    public async Task<bool> DoesPatientExist(AddPatientDTO addPatientDto)
    {
        var result = await _context.Patients
            .AnyAsync(e => (e.IdPatient == addPatientDto.IdPatient)
                           && e.FirstName.Equals(addPatientDto.FirstName)
                           && e.LastName.Equals(addPatientDto.LastName)
                           && e.Birthdate.Equals(addPatientDto.Birthdate));

        return result;
    }

    public async Task AddPatient(AddPatientDTO addPatientDto)
    {
        await _context.Patients.AddAsync(new Patient()
        {
            IdPatient = addPatientDto.IdPatient,
            FirstName = addPatientDto.FirstName,
            LastName = addPatientDto.LastName,
            Birthdate = addPatientDto.Birthdate
        });
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DoesMedicamentExist(AddMedicamentToPrescriptionDTO addMedicamentToPrescriptionDto)
    {
        var result = await _context.Medicaments
            .AnyAsync(e => e.IdMedicament == addMedicamentToPrescriptionDto.IdMedicament);

        return result;
    }

    public async Task AddPrescription(AddPrescriptionDTO addPrescriptionDto)
    {
        throw new NotImplementedException();
        // var medicaments = new HashSet<PrescriptionMedicament>();
        // foreach(var medicament in addPrescriptionDto.Medicaments)
        // {
        //     medicaments.Add(await GetMedicament(medicament.IdMedicament));
        // }
        //
        // await _context.Prescriptions.AddAsync(new Prescription()
        // {
        //     IdPatient = addPrescriptionDto.Patient.IdPatient,
        //     Date = addPrescriptionDto.Date,
        //     DueDate = addPrescriptionDto.DueDate, 
        //     PrescriptionMedicaments = medicaments
        // })
    }

    public async Task<Medicament> GetMedicament(int id)
    {
        return await _context.Medicaments.FirstAsync(e => e.IdMedicament == id);
    }
}