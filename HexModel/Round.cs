using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HexModel
{
    public class Round
    {
        public Map map;
        public List<Player> players;
        public int daysPassed;

        public Round(string filename, string[] playerNames)
        {
            map = new Map(filename);
            players = playerNames.Select(name => new Player(name)).ToList();
            daysPassed = 0;
        }

        public void UpdateTick(List<Point> playerPositions)
        {
            if (playerPositions.Count != players.Count)
                throw new ArgumentException("wrong number of player positions!");
            for (int i = 0; i < players.Count; i++)
            {
                var currentTile = map[playerPositions[i].X, playerPositions[i].Y];
                if (currentTile.tileObject == null)
                    continue;
                else
                    currentTile.tileObject.InteractWithPlayer(players[i]);
                    //InteractWithObject(players[i], currentTile.tileObject);
            }
        }

        private void InteractWithObject(Player currentPlayer, TileObject obj)
        {
            switch (obj.GetType().Name)
            {
                case "Mine":
                    {
                        var m = (Mine)obj;
                        m.Owner = currentPlayer;
                        break;
                    }
                case "ResourcePile":
                    {
                        var rp = (ResourcePile)obj;
                        currentPlayer.GainResources(rp.resource, rp.quantity);
                        obj = null;
                        break;
                    }
                default:
                    break;
            }
        }

        public void DailyTick()
        {
            for (int x = 0; x < map.Height; x++)
                for (int y = 0; y < map.Width; y++)
                    if (map[x, y].tileObject is Mine)
                    {
                        var m = map[x, y].tileObject as Mine;
                        m.Owner.GainResources(m.Resource, m.Yield);
                    }



            daysPassed++;
            if (daysPassed % 7 == 0)
                WeeklyTick();
        }
        public void WeeklyTick()
        {
            for (int x = 0; x < map.Height; x++)
                for (int y = 0; y < map.Width; y++)
                    if (map[x, y].tileObject is Dwelling)
                    {
                        var d = map[x, y].tileObject as Dwelling;
                        d.AddWeeklyGrowth();
                    }
        }
    }
}
