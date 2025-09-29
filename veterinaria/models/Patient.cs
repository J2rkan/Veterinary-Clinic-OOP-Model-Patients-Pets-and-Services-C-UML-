using System;
using System.Collections.Generic;
namespace veterinaria.models;
public class Patient
{
	public string Name { get; set; }
	public int Age { get; set; }
	public string Address { get; set; }
	public string Phone { get; set; }
	public List<Pet> Pets { get; set; }

	public Patient(string name, int age, string address, string phone)
	{
		Name = name;
		Age = age;
		Address = address;
		Phone = phone;
		Pets = new List<Pet>();
	}

	public void AddPet(Pet pet)
	{
		Pets.Add(pet);
	}

	public void ShowInfo()
	{
		Console.WriteLine($"Patient: {Name}, Age: {Age}, Address: {Address}, Phone: {Phone}");
	}

	public void ShowAllPets()
	{
		Console.WriteLine($"Pets of {Name}:");
		foreach (var pet in Pets)
		{
			pet.ShowInfo();
		}
	}
}

