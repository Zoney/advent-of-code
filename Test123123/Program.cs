// See https://aka.ms/new-console-template for more information

using Test123123;

var c = new MyBaseClass();
c.Number = null;
if (c.Number != null)
    Console.WriteLine("Weird.");

Console.WriteLine($"I'm {c.Number}");