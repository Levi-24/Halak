namespace HalakPalinka;

internal class Fish
{
    private int top;
    private int depth;
    private string species;
    private double weight;
    private bool weightIsSet = false;

    public string Species 
    {
        get => species;
        set
        {
            if (value is null)
                throw new Exception("You didnt specify a species.");
            if(value.Length < 3 || value.Length > 30)throw new Exception(
                "Species must be between 3 and 30 characters long.");
            species = value;
        } 
    }
    public bool Predator { get; }
    public double Weight 
    { 
        get => weight; 
        set
        {
            if (value < .5 || value > 50)
                throw new Exception("Weight can only be between 5 and 40.");
            if (weightIsSet && (value < weight * .9 || value > weight * 1.1)) throw new Exception(
                "Weight can only be changed by 10%.");
            weight = value;
            weightIsSet = true;
        }
    }
    public int Top
    {
        get => depth; set
        {
            if (value < 0 || value > 400)
            {
                throw new Exception($"Top must be between 0 and 400 cm. And your input is:{value}");
            }
            depth = value;
        }
    }
    public int Depth
    {
        get => depth; set
        {
            if (value < 10 || value > 400)
            {
                throw new Exception($"Depth must be between 10 and 400 cm. And your input is:{value}");
            }
            depth = value;
        }
    }
    public int Bottom => Top + Depth;

    public override string ToString() =>
        $"{Species} ({Weight:0.00} kg) - Top: {Top} cm, Bottom: {Bottom} cm, {(Predator ? "Carnivore" : "Herbivore")}";

    public Fish(string species, bool predator, double weight, int top, int depth)
    {
        Species = species;
        Predator = predator;
        Weight = weight;
        Top = top;
        Depth = depth;
    }
}
