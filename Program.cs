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

for (int i = 0; i < 100; i++)
{
    Console.WriteLine($"--------------------------------- Round {i+1:000} ------------------------------------");

    Fish a = fishList[Random.Shared.Next(fishList.Count)];
    Fish b = fishList[Random.Shared.Next(fishList.Count)];

    if (a.Top > b.Top) (a, b) = (b, a);

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(a);
    Console.WriteLine(b);
    Console.ForegroundColor = ConsoleColor.White;

    if ((a.Predator != b.Predator || a.Predator == true && b.Predator == true) && a.Bottom >= b.Top && (Random.Shared.Next(100) < 30))
    {
        if (a.Predator)
        {
            if (a.Weight <= 39.9)
            {
                a.Weight += .1F;
                fishList.Remove(b);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\tNyertes: {a}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        else
        {
            if (b.Weight <= 39.9)
            {
                b.Weight += .1F;
                fishList.Remove(a);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\tNyertes: {b}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}

Console.WriteLine($"fishlist count: {fishList.Count()}");