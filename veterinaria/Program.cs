using veterinaria;
using veterinaria.models;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
		// Create Patient
		Patient patient = new Patient("John Doe", 35, "123 Main St", "555-1234");

		// Create Pets
		Pet pet1 = new Pet("Buddy", "Dog", "Labrador", 5);
		Pet pet2 = new Pet("Whiskers", "Cat", "Siamese", 3);

		// Associate pets with patient
		patient.AddPet(pet1);
		patient.AddPet(pet2);

		// Show patient info
		patient.ShowInfo();

		// Show all pets of the patient
		patient.ShowAllPets();

		List<Patient> pacientes = new List<Patient>();
		List<Doctor> doctores = new List<Doctor>();
		List<Appointment> citas = new List<Appointment>();

		bool running = true;
		while (running)
		{
			Console.WriteLine("\n--- Menú Principal ---");
			Console.WriteLine("1. Registrar paciente");
			Console.WriteLine("2. Registrar mascota");
			Console.WriteLine("3. Registrar médico");
			Console.WriteLine("4. Agregar cita");
			Console.WriteLine("5. Eliminar cita");
			Console.WriteLine("6. Modificar cita");
			Console.WriteLine("7. Finalizar programa");
			Console.Write("Seleccione una opción: ");

			string? opcion = Console.ReadLine();
			switch (opcion)
			{
				case "1":
					Console.Write("Nombre: ");
					string nombre = Console.ReadLine() ?? "";
					Console.Write("Edad: ");
					int edad = int.TryParse(Console.ReadLine(), out int e) ? e : 0;
					Console.Write("Dirección: ");
					string direccion = Console.ReadLine() ?? "";
					Console.Write("Teléfono: ");
					string telefono = Console.ReadLine() ?? "";

					Patient nuevoPaciente = new Patient(nombre, edad, direccion, telefono);
					pacientes.Add(nuevoPaciente);
					Console.WriteLine($"Paciente registrado exitosamente. ID: {nuevoPaciente.Id}");
					break;
				case "2":
					if (pacientes.Count == 0)
					{
						Console.WriteLine("No hay pacientes registrados. Registre un paciente primero.");
						break;
					}
					Console.WriteLine("Pacientes registrados:");
					foreach (var p in pacientes)
						Console.WriteLine($"Nombre: {p.Name} | ID: {p.Id}");
					Console.Write("Ingrese el GUID del paciente: ");
					string guidInput = Console.ReadLine() ?? "";
					if (!Guid.TryParse(guidInput, out Guid pacienteId))
					{
						Console.WriteLine("GUID inválido.");
						break;
					}
					Patient pacienteSeleccionado = pacientes.FirstOrDefault(p => p.Id == pacienteId);
					if (pacienteSeleccionado == null)
					{
						Console.WriteLine("Paciente no encontrado.");
						break;
					}
					Console.Write("Nombre mascota: ");
					string nombreMascota = Console.ReadLine() ?? "";
					Console.Write("Especie: ");
					string especie = Console.ReadLine() ?? "";
					Console.Write("Raza: ");
					string raza = Console.ReadLine() ?? "";
					Console.Write("Edad: ");
					int edadMascota = int.TryParse(Console.ReadLine(), out int em) ? em : 0;
					Pet nuevaMascota = new Pet(nombreMascota, especie, raza, edadMascota);
					pacienteSeleccionado.AddPet(nuevaMascota);
					Console.WriteLine("Mascota registrada exitosamente.");
					break;
				case "3":
					Console.Write("Nombre médico: ");
					string nombreMedico = Console.ReadLine() ?? "";
					Console.Write("Especialidad: ");
					string especialidad = Console.ReadLine() ?? "";
					Console.Write("Teléfono: ");
					string telMedico = Console.ReadLine() ?? "";
					Doctor nuevoDoctor = new Doctor(nombreMedico, especialidad, telMedico);
					doctores.Add(nuevoDoctor);
					Console.WriteLine("Médico registrado exitosamente.");
					break;
				case "4":
					if (pacientes.Count == 0 || doctores.Count == 0)
					{
						Console.WriteLine("Debe haber al menos un paciente y un médico registrado.");
						break;
					}
					Console.WriteLine("Pacientes registrados:");
					foreach (var p in pacientes)
						Console.WriteLine($"Nombre: {p.Name} | ID: {p.Id}");
					Console.Write("Ingrese el GUID del paciente: ");
					string guidPaciente = Console.ReadLine() ?? "";
					if (!Guid.TryParse(guidPaciente, out Guid pacienteIdCita))
					{
						Console.WriteLine("GUID inválido.");
						break;
					}
					Patient pacienteCita = pacientes.FirstOrDefault(p => p.Id == pacienteIdCita);
					if (pacienteCita == null)
					{
						Console.WriteLine("Paciente no encontrado.");
						break;
					}
					Console.WriteLine("Médicos registrados:");
					foreach (var d in doctores)
						Console.WriteLine($"Nombre: {d.Name} | ID: {d.GetHashCode()}");
					Console.Write("Ingrese el índice del médico: ");
					int idxDocCita = int.TryParse(Console.ReadLine(), out int idxDC) ? idxDC - 1 : -1;
					if (idxDocCita < 0 || idxDocCita >= doctores.Count)
					{
						Console.WriteLine("Índice inválido.");
						break;
					}
					Console.Write("Fecha y hora (yyyy-MM-dd HH:mm): ");
					DateTime fechaCita = DateTime.TryParse(Console.ReadLine(), out DateTime fc) ? fc : DateTime.Now;
					Console.Write("Motivo: ");
					string motivo = Console.ReadLine() ?? "";
					Appointment nuevaCita = new Appointment(pacienteCita, doctores[idxDocCita], fechaCita, motivo);
					citas.Add(nuevaCita);
					Console.WriteLine("Cita agregada exitosamente.");
					break;
				case "5":
					if (citas.Count == 0)
					{
						Console.WriteLine("No hay citas registradas.");
						break;
					}
					Console.WriteLine("Seleccione la cita a eliminar por índice:");
					for (int i = 0; i < citas.Count; i++)
					{
						Console.WriteLine($"{i + 1}. {citas[i].Date} - {citas[i].Patient.Name} con {citas[i].Doctor.Name}");
					}
					int idxCitaDel = int.TryParse(Console.ReadLine(), out int idxCD) ? idxCD - 1 : -1;
					if (idxCitaDel < 0 || idxCitaDel >= citas.Count)
					{
						Console.WriteLine("Índice inválido.");
						break;
					}
					citas.RemoveAt(idxCitaDel);
					Console.WriteLine("Cita eliminada exitosamente.");
					break;
				case "6":
					if (citas.Count == 0)
					{
						Console.WriteLine("No hay citas registradas.");
						break;
					}
					Console.WriteLine("Seleccione la cita a modificar por índice:");
					for (int i = 0; i < citas.Count; i++)
					{
						Console.WriteLine($"{i + 1}. {citas[i].Date} - {citas[i].Patient.Name} con {citas[i].Doctor.Name}");
					}
					int idxCitaMod = int.TryParse(Console.ReadLine(), out int idxCM) ? idxCM - 1 : -1;
					if (idxCitaMod < 0 || idxCitaMod >= citas.Count)
					{
						Console.WriteLine("Índice inválido.");
						break;
					}
					Console.Write("Nueva fecha y hora (yyyy-MM-dd HH:mm): ");
					DateTime nuevaFecha = DateTime.TryParse(Console.ReadLine(), out DateTime nf) ? nf : citas[idxCitaMod].Date;
					Console.Write("Nuevo motivo: ");
					string nuevoMotivo = Console.ReadLine() ?? citas[idxCitaMod].Reason;
					citas[idxCitaMod].Date = nuevaFecha;
					citas[idxCitaMod].Reason = nuevoMotivo;
					Console.WriteLine("Cita modificada exitosamente.");
					break;
				case "7":
					Console.WriteLine("Finalizando programa...");
					running = false;
					break;
				default:
					Console.WriteLine("Opción no válida. Intente de nuevo.");
					break;
			}
		}
	}
}
