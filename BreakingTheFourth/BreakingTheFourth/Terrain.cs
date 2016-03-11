using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//added namespaces
using Microsoft.Xna.Framework;

namespace BreakingTheFourth
{
    class Terrain
    {
        //Here's where we get to the meat of the collision detection
        //Are we gonna need Intersect methods for both the player and the ground? Seems redundant.
        //If we're gonna make the level move around the player, we'll need X and Y coordinates to move. How does that even work?
        //Do we make the ground a Rectangle? This will probably be the trickiest class.

        //fields
        Rectangle position;
        //method for collision detection for player and bullet
        /*public bool CollisionDetected(Rectangle entity)
        {
            if()
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/
    }
}
