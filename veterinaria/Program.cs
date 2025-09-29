using System;
using System.Collections.Generic;
using veterinaria.models;

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
	}
}

