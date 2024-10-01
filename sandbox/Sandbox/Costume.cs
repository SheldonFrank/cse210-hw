class Costume
{
    //attributes (member variables)
    public string headWear;
    public string gloves;
    public string shoes;
    public string upperGarment;
    public string lowerGarment;
    public string accessory;

    //behaviors (member functions, or *methods*)

    public void ShowWardrobe()
    {
        string result = "";
        result += "Head gear: " + headWear;
        result += "Hand gear: " + gloves;
        result += "Foot gear: " + shoes;
        result += "Torso Covering: " + upperGarment;
        result += "Leg covering: " + lowerGarment;
        result += "Accessory: " + accessory;

        Console.WriteLine(result + "\n");

    }
}