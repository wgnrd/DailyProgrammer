﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrollMaze
{
    static class Draw
    {
        // TODO write in static extra-class
        public static bool mazeExited = false;
        /// <summary>
        /// Draws the maze with the player on it
        /// </summary>
        /// <param name="Maze"> Get the maze </param>
        /// <param name="plyr"> Get the player</param>
        public static void DrawMaze(Maze mz, Player plyr)
        {
            int count = 0;
            char [] chars = Maze.field[plyr.locationY].ToCharArray();
            chars[plyr.locationX] = plyr.direction;
            
            foreach (String line in Maze.field)
            { 
                if (count == plyr.locationY)
                {
                    Console.WriteLine(new string(chars));
                }
                else
                {
                    Console.WriteLine(line);
                }

                count++;
            }
        }

        /// <summary>
        /// Draws Maze with player and 1 Troll on it
        /// </summary>
        /// <param name="mz"></param>
        /// <param name="plyr"></param>
        /// <param name="trl"></param>
        public static void DrawMaze(Maze mz, Player plyr, Troll trl)
        {
            int count = 0;
            char[] chars = Maze.field[plyr.locationY].ToCharArray();
            chars[plyr.locationX] = plyr.direction;


            char[] trlchars = Maze.field[trl.coordY].ToCharArray();
            trlchars[trl.coordX] = '@';

            if (plyr.locationY == trl.coordY)
            {
                chars[trl.coordX] = '@';
                chars[plyr.locationX] = plyr.direction;
            }

            foreach (String line in Maze.field)
            {
                if (count == plyr.locationY)
                {
                    Console.WriteLine(new string(chars));
                }
                else if (count == trl.coordY)
                {
                    Console.WriteLine(new string(trlchars));
                }
                else
                {
                    Console.WriteLine(line);
                }

                count++;
            }
        }



        /// <summary>
        /// Draws Maze with player and a list of Trolls on it
        /// </summary>
        /// <param name="mz"></param>
        /// <param name="plyr"></param>
        /// <param name="trls"></param>
        public static void DrawMaze(Maze mz, Player plyr, List<Troll> trls)
        {
            List<String> tempmz = new List<string>();
            char[] chars = null;

            tempmz.AddRange(Maze.field);

           // var mytrls = trls.OrderBy(t => t.coordY);

            chars = tempmz[plyr.locationY].ToCharArray();
            chars[plyr.locationX] = plyr.direction;
            tempmz[plyr.locationY] = new string(chars);

            foreach (Troll trl in trls)
            {
                chars = tempmz[trl.coordY].ToCharArray();
                chars[trl.coordX] = trl.representation;
                tempmz[trl.coordY] = new string(chars);
            }

            foreach (String line in tempmz)
            {
                Console.WriteLine(line);
            }
        }
    }
}

