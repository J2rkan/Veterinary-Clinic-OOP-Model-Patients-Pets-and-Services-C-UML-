using veterinaria.models;

namespace veterinaria
{
    public class Appointment
    {
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }

        public Appointment(Patient patient, Doctor doctor, DateTime date, string reason)
        {
            Patient = patient;
            Doctor = doctor;
            Date = date;
            Reason = reason;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Cita: {Date}, Paciente: {Patient.Name}, Médico: {Doctor.Name}, Motivo: {Reason}");
        }
    }
}
namespace veterinaria
{
    public class Doctor
    {
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string Phone { get; set; }

        public Doctor(string name, string specialty, string phone)
        {
            Name = name;
            Specialty = specialty;
            Phone = phone;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Nombre: {Name}, Especialidad: {Specialty}, Teléfono: {Phone}");
        }
    }
}

