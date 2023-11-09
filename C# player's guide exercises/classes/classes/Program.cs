
Console.Write("Arrowhead type (steel, wood, obsidian): ");
string inputArrow = Console.ReadLine();
Console.Write("Fletching type (plastic, turkey , goose ): ");
string inputFlecthing = Console.ReadLine();
Console.Write("Arrow length (between 60 and 100): ");
float inputLenght = float.Parse(Console.ReadLine());

Arrow current = new Arrow(inputArrow, inputFlecthing, inputLenght);
Console.WriteLine(current.GetCost());

class Arrow
{
    enum _arrowHead
    {
        steel,
        wood,
        obsidian
    }

    enum _fletching
    {
        plastic, 
        turkey,
        goose
    }

    float _lenght = 0.05f;
    float _value = 0;

    public Arrow(string arrowHead, string fletching, float lenght)
    {
        if(arrowHead == _arrowHead.steel.ToString())
            _value += 10;
        if(arrowHead == _arrowHead.wood.ToString())
            _value += 5;
        if (arrowHead == _arrowHead.obsidian.ToString())
            _value += 3;

        if(fletching == _fletching.plastic.ToString())
            _value += 10;
        if(fletching == _fletching.turkey.ToString())
            _value += 5;
        if (fletching == _fletching.plastic.ToString())
            _value += 3;

        _lenght *= lenght;
    }

    public float GetCost()
    {
        return _value + _lenght;
    }
}
