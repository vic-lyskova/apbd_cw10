﻿namespace Cw10.Models;

public class Patient
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime birthdate { get; set; }
    public ICollection<Prescription> Prescriptions { get; set; }
}