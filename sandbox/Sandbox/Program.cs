using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Sandbox World!");

        Costume nurse = new();

        nurse.headWear = "face mask";
        nurse.gloves = "latex gloves";
        nurse.shoes = "orthopedic sneakers";
        nurse.upperGarment = "scrubs";
        nurse.lowerGarment = "scrubs";
        nurse.accessory = "stethoscope";

        Costume detective = new();

        detective.headWear = "fedora";
        detective.gloves = "leather";
        detective.shoes = "loafers";
        detective.upperGarment = "trenchcoat";
        detective.lowerGarment = "slacks";
        detective.accessory = "magnifying glass";

        
        Costume rancher = new();

        rancher.headWear = "cowboy hat";
        rancher.gloves = "work";
        rancher.shoes = "boots";
        rancher.upperGarment = "flannel shirt";
        rancher.lowerGarment = "jeans";
        rancher.accessory = "lasso";

        Console.WriteLine();
        nurse.ShowWardrobe();
        Console.WriteLine();
        detective.ShowWardrobe();
        rancher.ShowWardrobe();

    }
}