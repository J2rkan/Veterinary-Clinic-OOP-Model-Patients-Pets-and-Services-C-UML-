namespace veterinaria.models;

public class Pet
{
    public string Name { get; set; }
    public string Species { get; set; }
    public string Breed { get; set; }
    public int Age { get; set; }

    public Pet(string name, string species, string breed, int age)
    {
        Name = name;
        Species = species;
        Breed = breed;
        Age = age;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Pet: {Name}, Species: {Species}, Breed: {Breed}, Age: {Age}");
    }
}
