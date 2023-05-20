using System;
using System.Collections.Generic;

public enum PotionType
{
    ELIXIROFSORCERY,
    CORUPTION,
    HEALING,
    MANA,
    ELIXIROFWRAITH,
    ELIXIROFIRON
}

public interface IItemShopFactory
{
    ITopShelf CreateTopShelf();
    IBottomShelf CreateBottomShelf();
}

public interface ITopShelf
{
    List<Potion> GetPotions();
}

public interface IBottomShelf
{
    List<Potion> GetPotions();
}

public class ItemShop : IItemShopFactory
{
    public ITopShelf CreateTopShelf()
    {
        return new TopShelf();
    }

    public IBottomShelf CreateBottomShelf()
    {
        return new BottomShelf();
    }
}

public class TopShelf : ITopShelf
{
    public List<Potion> GetPotions()
    {
        List<Potion> topShelfPotions = new List<Potion>();
        topShelfPotions.Add(new ElixirOfSorcery());
        topShelfPotions.Add(new Corruption());
        topShelfPotions.Add(new ElixirOfWraith());
        return topShelfPotions;
    }
}

public class BottomShelf : IBottomShelf
{
    public List<Potion> GetPotions()
    {
        List<Potion> bottomShelfPotions = new List<Potion>();
        bottomShelfPotions.Add(new HealingPotion());
        bottomShelfPotions.Add(new ManaPotion());
        bottomShelfPotions.Add(new ElixirOfIron());
        return bottomShelfPotions;
    }
}

public interface Potion
{
    void Drink();
}

public class ElixirOfSorcery : Potion
{
    public void Drink()
    {
        Console.WriteLine("Drinking Elixir of Sorcery.");
    }
}

public class Corruption : Potion
{
    public void Drink()
    {
        Console.WriteLine("Drinking Corruption.");
    }
}

public class HealingPotion : Potion
{
    public void Drink()
    {
        Console.WriteLine("Drinking Healing Potion.");
    }
}

public class ManaPotion : Potion
{
    public void Drink()
    {
        Console.WriteLine("Drinking Mana Potion.");
    }
}

public class ElixirOfWraith : Potion
{
    public void Drink()
    {
        Console.WriteLine("Drinking Elixir of Wraith.");
    }
}

public class ElixirOfIron : Potion
{
    public void Drink()
    {
        Console.WriteLine("Drinking Elixir of Iron.");
    }
}

public class App
{
    public App()
    {
        // App constructor implementation
    }

    public static void Main(string[] args)
    {
        IItemShopFactory shopFactory = new ItemShop();
        ITopShelf topShelf = shopFactory.CreateTopShelf();
        IBottomShelf bottomShelf = shopFactory.CreateBottomShelf();

        List<Potion> topShelfPotions = topShelf.GetPotions();
        Console.WriteLine("Top Shelf Potions:");
        foreach (Potion potion in topShelfPotions)
        {
            potion.Drink();
        }

        Console.WriteLine();

        List<Potion> bottomShelfPotions = bottomShelf.GetPotions();
        Console.WriteLine("Bottom Shelf Potions:");
        foreach (Potion potion in bottomShelfPotions)
        {
            potion.Drink();
        }
    }
}
