using System;
using System.Collections.Generic;

public abstract class Beverage
{
    public abstract string GetDescription();
    public abstract decimal GetCost();
}

public abstract class BeverageDecorator : Beverage
{
    protected Beverage beverage;

    public BeverageDecorator(Beverage beverage)
    {
        this.beverage = beverage;
    }
}

public class Espresso : Beverage
{
    public override string GetDescription()
    {
        return "Espresso";
    }

    public override decimal GetCost()
    {
        return 2.0m;
    }
}

public class Cappuccino : Beverage
{
    public override string GetDescription()
    {
        return "Cappuccino";
    }

    public override decimal GetCost()
    {
        return 3.0m;
    }
}

public class Latte : Beverage
{
    public override string GetDescription()
    {
        return "Latte";
    }

    public override decimal GetCost()
    {
        return 3.5m;
    }
}

public class Milk : BeverageDecorator
{
    public Milk(Beverage beverage) : base(beverage)
    {
    }

    public override string GetDescription()
    {
        return beverage.GetDescription() + ", Milk";
    }

    public override decimal GetCost()
    {
        return beverage.GetCost() + 0.5m;
    }
}

public class Syrup : BeverageDecorator
{
    public Syrup(Beverage beverage) : base(beverage)
    {
    }

    public override string GetDescription()
    {
        return beverage.GetDescription() + ", Syrup";
    }

    public override decimal GetCost()
    {
        return beverage.GetCost() + 0.3m;
    }
}

public class WhippedCream : BeverageDecorator
{
    public WhippedCream(Beverage beverage) : base(beverage)
    {
    }

    public override string GetDescription()
    {
        return beverage.GetDescription() + ", Whipped Cream";
    }

    public override decimal GetCost()
    {
        return beverage.GetCost() + 0.7m;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Coffee Ordering System!");
        Console.WriteLine("--------------------------------------");

        // Wybór rodzaju kawy
        Console.WriteLine("Choose a coffee:");
        Console.WriteLine("1. Espresso");
        Console.WriteLine("2. Cappuccino");
        Console.WriteLine("3. Latte");
        Console.Write("Enter your choice (1-3): ");
        int coffeeChoice = int.Parse(Console.ReadLine());

        // Tworzenie wybranego napoju
        Beverage coffee;
        switch (coffeeChoice)
        {
            case 1:
                coffee = new Espresso();
                break;
            case 2:
                coffee = new Cappuccino();
                break;
            case 3:
                coffee = new Latte();
                break;
            default:
                Console.WriteLine("Invalid choice. Exiting...");
                return;
        }

        Console.WriteLine();

        // Wybór dodatków
        List<BeverageDecorator> addons = new List<BeverageDecorator>();
        Console.WriteLine("Choose addons (enter comma-separated numbers, or leave blank for no addons):");
        Console.WriteLine("1. Milk (+$0.5)");
        Console.WriteLine("2. Syrup (+$0.3)");
        Console.WriteLine("3. Whipped Cream (+$0.7)");
        Console.Write("Enter your choice(s): ");
        string[] addonChoices = Console.ReadLine().Split(',');

        foreach (string choice in addonChoices)
        {
            switch (choice.Trim())
            {
                case "1":
                    coffee = new Milk(coffee);
                    break;
                case "2":
                    coffee = new Syrup(coffee);
                    break;
                case "3":
                    coffee = new WhippedCream(coffee);
                    break;
                default:
                    Console.WriteLine("Invalid choice(s) ignored.");
                    break;
            }
        }

        // Dodawanie wybranych dodatków do napoju
        foreach (var addon in addons)
        {
            coffee = addon;
        }

        Console.WriteLine();

        // Wyświetlanie informacji o zamówieniu
        Console.WriteLine("Order: " + coffee.GetDescription());
        Console.WriteLine("Total cost: $" + coffee.GetCost());

        Console.WriteLine();
        Console.WriteLine("Thank you for using the Coffee Ordering System!");

        Console.ReadLine();
    }
}
