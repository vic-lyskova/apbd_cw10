using Cw10.Context;
using Cw10.DTOs;
using Cw10.Models;
using Microsoft.EntityFrameworkCore;

namespace Cw10.Repositories;

public class PatientsRepository : IPatientsRepository
{
    private readonly ApbdContext _context;

    public PatientsRepository(ApbdContext context)
    {
        _context = context;
    }

    public async Task<bool> DoesPatientExist(int idPatient)
    {
        return await _context.Patients
            .AnyAsync(e => e.IdPatient == idPatient);
    }

    public async Task<ICollection<Patient>> GetPatients(int idPatient)
    {
        return await _context.Patients
            .Include(e => e.Prescriptions)
            .ThenInclude(e => e.PrescriptionMedicaments)
            .ThenInclude(e => e.Medicament)
            .Where(e => e.IdPatient == idPatient)
            .ToListAsync();
        /*return await _context.Prescriptions
            .Include(pr => pr.Patient)
            .Include(pr => pr.Doctor)
            .Include(pr => pr.PrescriptionMedicaments)
            .ThenInclude(pm => pm.Medicament)
            .ToListAsync();*/
    }
}