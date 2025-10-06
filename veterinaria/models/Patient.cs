using System;
using System.Collections.Generic;
namespace veterinaria.models;
public class Patient
{
	public Guid Id { get; private set; } // Identificador único
	public string Name { get; set; }
	public int Age { get; set; }
	public string Address { get; set; }
	public string Phone { get; set; }
	private List<Pet> Pets { get; set; } = new List<Pet>();

	public Patient(string name, int age, string address, string phone)
	{
		Id = Guid.NewGuid(); // Asigna un GUID único al paciente
		Name = name;
		Age = age;
		Address = address;
		Phone = phone;
	}

	public void AddPet(Pet pet)
	{
		Pets.Add(pet);
	}

	public void ShowInfo()
	{
		Console.WriteLine($"ID: {Id}\nNombre: {Name}, Edad: {Age}, Dirección: {Address}, Teléfono: {Phone}");
	}

	public void ShowAllPets()
	{
		Console.WriteLine("Mascotas:");
		foreach (var pet in Pets)
		{
			pet.ShowInfo();
		}
	}
}
