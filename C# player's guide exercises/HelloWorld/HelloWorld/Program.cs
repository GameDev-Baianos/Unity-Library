
Console.Title = "Defense of Consolas";

int x, y;

Console.WriteLine("Target Row?");
x = int.Parse(Console.ReadLine());
Console.WriteLine("Target Column?");
y = int.Parse(Console.ReadLine());


Console.WriteLine("\nDeploy to:");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("(" + x + "," + (y-1) + ")" );
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("(" + (x-1) + "," + (y) + ")");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("(" + x + "," + (y+1) + ")");
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("(" + (x+1) + "," + (y) + ")");

Console.ForegroundColor = ConsoleColor.White;

Console.Beep();