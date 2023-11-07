(foods Food, ingredients Ingredient, seasonings Seasoning) recipe = (foods.soup, ingredients.mushrooms, seasonings.spicy);
string aux;

Console.WriteLine("What do u wanna eat?");
Console.WriteLine("1 - " + foods.soup +
                  "\n2 - " + foods.stew + 
                  "\n3 - " + foods.gumbo);
aux = Console.ReadLine();
if(aux == "1")
    recipe.Food = foods.soup;
if (aux == "2")
    recipe.Food = foods.stew;
if (aux == "3")
    recipe.Food = foods.gumbo;

Console.WriteLine("Choose your ingredients:");
Console.WriteLine("1 - " + ingredients.mushrooms +
                  "\n2 - " + ingredients.chicken +
                  "\n3 - " + ingredients.carrots +
                  "\n4 - " + ingredients.potatoes);
aux = Console.ReadLine();
if (aux == "1")
    recipe.Ingredient = ingredients.mushrooms;
if (aux == "2")
    recipe.Ingredient = ingredients.chicken;
if (aux == "3")
    recipe.Ingredient = ingredients.carrots;
if (aux == "4")
    recipe.Ingredient = ingredients.potatoes;

Console.WriteLine("What seasoning?");
Console.WriteLine("1 - " + seasonings.spicy +
                  "\n2 - " + seasonings.salty +
                  "\n3 - " + seasonings.sweet);
aux = Console.ReadLine();

if (aux == "1")
    recipe.Seasoning = seasonings.spicy;
if (aux == "2")
    recipe.Seasoning = seasonings.salty;
if (aux == "3")
    recipe.Seasoning = seasonings.sweet;

Console.WriteLine($"{recipe.Seasoning} {recipe.Ingredient} {recipe.Food}");

enum foods{soup,stew,gumbo}

enum ingredients {mushrooms,chicken,carrots,potatoes}

enum seasonings {spicy,salty,sweet}
