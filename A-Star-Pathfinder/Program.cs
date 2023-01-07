/*

 - .Add()
 - List<>()
 - .Where()
 - map. vs map[]
 
 */

using A_Star_Pathfinder;
class Program{

static void Main(String[] args){
List<string> Map = new List<string>
{
    "A   ",
    "-||-",
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
}

private static List<Tile> GetOpenTiles(List<String> map, Tile currentTile, Tile targetTile){

    var possibleTiles = new List<Tile>(){
		new Tile { x = currentTile.x, y = currentTile.y + 1, ParentNode = currentTile, Cost = currentTile.Cost + 1},
        new Tile { x = currentTile.x, y = currentTile.y - 1, ParentNode = currentTile, Cost = currentTile.Cost + 1 },
		new Tile { x = currentTile.x - 1, y = currentTile.y, ParentNode = currentTile, Cost = currentTile.Cost + 1 },
		new Tile { x = currentTile.x + 1, y = currentTile.y, ParentNode = currentTile, Cost = currentTile.Cost + 1 },
    };

    possibleTiles.ForEach(tile => tile.SetDistance(targetTile.x, targetTile.y));

    var maxX = map.First().Length - 1;
	var maxY = map.Count - 1;

        return possibleTiles.Where(tile => tile.x >= 0 && tile.x <= maxX)
            .Where(tile => tile.y >= 0 && tile.y <= maxY)
            .Where(tile => map[tile.y][tile.x] == ' ' || map[tile.x][tile.y] == 'B')
            .ToList();
    
    }
}
    
