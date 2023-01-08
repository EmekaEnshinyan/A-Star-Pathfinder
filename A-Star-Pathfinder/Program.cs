/*
  !WARNING! might be ad hoc solution for a single string array
  !WARNING! possible conflation with Map object
 - .Add()
 - List<>()
 - .Where()
 - Map. vs Map[]
 - public Tile ParentNode { get; set; } must contain a non-null value when existing constructor
 - .First()
 - .Any()
 - .OrderBy()
 */

using A_Star_Pathfinder;
class Program{

static void Main(String[] args){

      
List<string> Map = new List<string>
{
    "A   ",
    "-| | ",
    "   B"
};

var startPosition = new Tile(); 
//here, Map is a grid made up of a list of strings
startPosition.y = Map.FindIndex(x => x.Contains("A"));
 
startPosition.x = Map[startPosition.y].IndexOf("A");

var endPosition = new Tile();
endPosition.x = Map.FindIndex((x) => x.Contains("B"));
//make list of visitaed and active tiles. activetiles populate on start block
var activeTiles = new List<Tile>();
activeTiles.Add(startPosition);
var visitedTiles = new List<Tile>();

        while(activeTiles.Any()){
            var checkTile = activeTiles.OrderBy(x => x.CostDistance).First();
            if (checkTile.x == endPosition.x && checkTile.y == endPosition.y){
                Console.WriteLine("A* Pathefinder Run Complete");
                return;
            }

            visitedTiles.Add(checkTile);
            activeTiles.Remove(checkTile);
            var openTiles = GetOpenTiles(Map, checkTile, endPosition);

            foreach(var openTile in openTiles){
                if(visitedTiles.Any(x => x.x == openTile.x && x.y == openTile.y)){
                    var existingTile = activeTiles.First(x => x.x == openTile.x && x.y == openTile.y);
                    if (existingTile.CostDistance > checkTile.CostDistance){
                        activeTiles.Remove(existingTile);
                        activeTiles.Add(openTile);
                    }
                }else{
                    activeTiles.Add(openTile);
                }
            }
            if(checkTile.x == endPosition.x && checkTile.y == endPosition.y){
                var tile = checkTile;
	Console.WriteLine("Retracing steps backwards...");
	while(true)
	{
		Console.WriteLine($"{tile.x} : {tile.y}");
		if(Map[tile.y][tile.x] == ' ')
		{
			var newMapRow = Map[tile.y].ToCharArray();
			newMapRow[tile.x] = '*';
			Map[tile.y] = new string(newMapRow);
		}
		tile = tile.ParentNode;
		if(tile == null)
		{
			Console.WriteLine("Map looks like :");
			Map.ForEach(x => Console.WriteLine(x));
			Console.WriteLine("Done!");
			return;
		}
	}
            }
}

Console.WriteLine("No Valid Path");
 
}

public static List<Tile> GetOpenTiles(List<String> Map, Tile currentTile, Tile targetTile){

    var possibleTiles = new List<Tile>(){
		new Tile { x = currentTile.x, y = currentTile.y + 1, ParentNode = currentTile, Cost = currentTile.Cost + 1},
        new Tile { x = currentTile.x, y = currentTile.y - 1, ParentNode = currentTile, Cost = currentTile.Cost + 1 },
		new Tile { x = currentTile.x - 1, y = currentTile.y, ParentNode = currentTile, Cost = currentTile.Cost + 1 },
		new Tile { x = currentTile.x + 1, y = currentTile.y, ParentNode = currentTile, Cost = currentTile.Cost + 1 },
    };

    possibleTiles.ForEach(tile => tile.SetDistance(targetTile.x, targetTile.y));

    var maxX = Map.First().Length - 1;
	var maxY = Map.Count - 1;

        return possibleTiles.Where(tile => tile.x >= 0 && tile.x <= maxX)
            .Where(tile => tile.y >= 0 && tile.y <= maxY)
            .Where(tile => Map[tile.y][tile.x] == ' ' || Map[tile.x][tile.y] == 'B')
            .ToList();

    
    
    }
}

    
