using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Animal
{
    public abstract class Animal
{
    public string Name { get; set; }
    public abstract string Type { get; }
    public abstract double CalculateFoodQuantity();
}

public class Carnivore : Animal
{
    public override string Type => "Хищник";
    public override double CalculateFoodQuantity()
    {
        // Расчет количества пищи для хищника
        return 2.0;
    }
}

public class Omnivore : Animal
{
    public override string Type => "Всеядное животное";
    public override double CalculateFoodQuantity()
    {
        // Расчет количества пищи для всеядного животного
        return 1.5;
    }
}

public class Herbivore : Animal
{
    public override string Type => "Травоядное животное";
    public override double CalculateFoodQuantity()
    {
        // Расчет количества пищи для травоядного животного
        return 1.0;
    }
}
}
