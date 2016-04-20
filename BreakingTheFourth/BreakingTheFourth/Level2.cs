using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BreakingTheFourth
{
    class Level2
    {
        //Contributors:
        //Kat Weis - Implemented the num of bullets

        
        // list to hold the terrain pieces
        List<Terrain> pieces = new List<Terrain>();

        // Next Screen method
        public List<Terrain> NextScreen(int screen, Bullet bullet)
        {
            bullet.Bullets = 500;
            // switch to determine which screen to draw
            switch (screen)
            {
                case 1:
                    // clear the list
                    pieces.Clear();
                    // add new terrain pieces
                    pieces.Add(new Terrain(0, 0, 25, 300)); // left wall
                    pieces.Add(new Terrain(0, 450, 200, 40)); //left floor
                    pieces.Add(new Terrain(0, 0, 800, 40)); //ceiling
                    pieces.Add(new SpecialTerrain(200, 470, 40, 40, 200, 490)); //moving platform
                    pieces.Add(new Terrain(250, 210, 50, 400)); //upper left floor
                    pieces.Add(new Terrain(370, 0, 40, 300)); // first pillar
                    pieces.Add(new Terrain(300, 400, 100, 40)); //first platform
                    pieces.Add(new Terrain(500, 200, 40, 240)); //second pillar
                    pieces.Add(new Terrain(600, 350, 75, 40)); //second platform
                    pieces.Add(new Terrain(620, 0, 40, 200)); //third pillar
                    pieces.Add(new Terrain(725, 210, 100, 400));// upper right floor
                    break;
                case 2:
                    break;
                case 3:
                    // clear the list
                    pieces.Clear();
                    // add new pieces
                    pieces.Add(new Terrain(0, 0, 25, 300)); // left wall 
                    pieces.Add(new Terrain(750, 0, 50, 110)); // right wall(upper)
                    pieces.Add(new Terrain(750, 200, 50, 250)); // right wall (lower)
                    pieces.Add(new Terrain(710, 200, 40, 50)); //right wall platform
                    pieces.Add(new Terrain(0, 450, 800, 40)); // floor
                    pieces.Add(new Terrain(125, 0, 20, 380)); // first obstacle (top)
                    pieces.Add(new Terrain(125, 425, 20, 25)); // first obstacle (bottom)
                    pieces.Add(new Terrain(350, 0, 50, 260)); // second obstacle (top)
                    pieces.Add(new Terrain(350, 350, 50, 100)); //second obstacle (bottom)
                    pieces.Add(new DeathObject(400, 400, 350, 50)); //spikes
                    break;
                case 4:
                    // clear the list
                    pieces.Clear();
                    // add new pieces
                    pieces.Add(new Terrain(0, 450, 150, 40)); // left floor
                    pieces.Add(new Terrain(0, 0, 25, 300)); // left wall
                    pieces.Add(new SpecialTerrain(200, 440, 60, 60, 200, 440)); //moving platform
                    pieces.Add(new Terrain(275, 0, 40, 200)); //first obstacle (top)
                    pieces.Add(new Terrain(275, 260, 40, 60)); //first obstacle (middle)
                    pieces.Add(new Terrain(275, 380, 40, 100)); //first obstacle (bottom)
                    pieces.Add(new Terrain(470, 200, 20, 60)); //top floating platform (vertical)
                    pieces.Add(new Terrain(370, 260, 120, 20)); //top floating platform (horizontal)
                    pieces.Add(new Terrain(400, 320, 20, 60)); //bottom floating platform
                    pieces.Add(new Terrain(500, 0, 800, 40)); //ceiling
                    pieces.Add(new Terrain(500, 120, 40, 300)); // giant floating wall in the middle, ya can't miss it
                    pieces.Add(new Terrain(500, 450, 350, 40)); //right floor
                    pieces.Add(new Terrain(700, 200, 60, 30)); //top spike platform
                    pieces.Add(new Terrain(540, 250, 80, 30)); //bottom spike platform
                    pieces.Add(new Terrain(760, 0, 50, 230)); //right wall (top)
                    pieces.Add(new Terrain(760, 380, 50, 400)); //right wall (bottom)
                    pieces.Add(new Terrain(720, 380, 40, 20)); //bottom right wall cliff
                    pieces.Add(new DeathObject(700, 170, 60, 30)); //top spikes
                    pieces.Add(new DeathObject(540, 220, 80, 30)); //middle spikes
                    pieces.Add(new DeathObject(500, 420, 260, 30)); //bottom spikes
                    break;
                case 5:
                    //clear the list
                    pieces.Clear();
                    //add new pieces
                    pieces.Add(new Terrain(0, 450, 225, 40)); // left floor
                    pieces.Add(new Terrain(0, 0, 25, 300)); // left wall
                    pieces.Add(new Terrain(775, 0, 25, 500)); // right wall
                    pieces.Add(new Terrain(225, 150, 50, 500)); //big wall
                    pieces.Add(new Terrain(0, 0, 800, 40)); //ceiling
                    pieces.Add(new SpecialTerrain(325, 90, 20, 20, 40, 120)); //tiny moving platform
                    pieces.Add(new SpecialTerrain(450, 90, 50, 50, 40, 90)); //bigger moving platform
                    pieces.Add(new Terrain(400, 140, 500, 30)); //platform that connects to bigger moving platform
                    pieces.Add(new DeathObject(500, 110, 250, 30)); //YOU SHALL NOT PASS
                    pieces.Add(new Terrain(500, 450, 275, 40)); //right floor
                    pieces.Add(new DeathObject(600, 420, 100, 30)); //spikes on right floor
                    pieces.Add(new Terrain(400, 170, 40, 130)); //wall thing
                    pieces.Add(new LevelGoal(710, 360, 50, 50)); //Goal
                    break;


            }
            return pieces;
        }
    }
}
