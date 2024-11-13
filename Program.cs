using HalakPalinka;

List<Fish> fishList = new();
string[] herbFishSpecies = ["Catfish", "Salmon", "Tuna", "Cod", "Shark", "Eel", "Herring", "Trout", "Bass", "Pufferfish"];
string[] predFishSpecies = ["Bream", "Carp", "Clownfish"];

for (int i = 0; i < 100; i++)
{
    bool predator = Random.Shared.Next(100) < 10;

    fishList.Add(new Fish(
        species: predator ? predFishSpecies[Random.Shared.Next(predFishSpecies.Length)] : herbFishSpecies[Random.Shared.Next(herbFishSpecies.Length)],
        predator: predator,
        weight: Random.Shared.Next(5, 401) / 10f,
        top: Random.Shared.Next(401),
        depth: Random.Shared.Next(10, 401)));

    Console.ForegroundColor = fishList.Last().Predator ? ConsoleColor.Red : ConsoleColor.Green;
    Console.WriteLine(fishList.Last());
}

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine();
Console.WriteLine("Carnivore fish count:");
Console.WriteLine("\t" + fishList.Count(x => x.Predator));

Console.WriteLine("Herbivore fish count:");
Console.WriteLine("\t" + fishList.Count(x => !x.Predator));

Console.WriteLine("Largest fish:");
Console.WriteLine("\t" + fishList.Max(x => x.Weight));

Console.WriteLine("Fish count on 1.1m:");
Console.WriteLine("\t" + fishList.Count(x => x.Top < 110 && x.Bottom >= 110));