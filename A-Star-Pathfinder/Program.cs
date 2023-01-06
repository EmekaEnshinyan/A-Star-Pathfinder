using A_Star_Pathfinder;

List<string> Map = new List<string>
{
    "A   ",
    "-||-",
    "   B"
};

var startPosition = new Tile(); 
//here, Map is a grid made up of a list of strings
startPosition.Y = Map.FindIndex(x => x.Contains("A"));
 
startPosition.X = Map[startPosition.Y].IndexOf("A");

var endPosition = new Tile();
endPosition.X = Map.FindIndex((x) => x.Contains("B"));
