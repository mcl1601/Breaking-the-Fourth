using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BreakingTheFourth
{
    // Contributors 
    // Matt Lienhard - did the whole thing since I was in charge of the tool
    class FileIO
    {
        // fields
        int playerSpeed;
        int bulletSpeed;
        int gravity;
        
        // Generic Constructor
        public FileIO() { }
        // reading in the tool file
        public FileIO(int a)
        {
            // make the stream
            Stream inStream = File.OpenRead("../../../../Tool/Tool/bin/Debug/Values.data");

            // read the file
            BinaryReader input = new BinaryReader(inStream); 
            

            // assign the values when reading
            playerSpeed = input.ReadInt32();
            bulletSpeed = input.ReadInt32();
            gravity = input.ReadInt32();

            // close the file
            input.Close();
        }

        // reading in the saved game file
        public int ReadLevel()
        {
            if (File.Exists("GameFile.data"))
            {
                // make the stream
                Stream inStream = File.OpenRead("GameFile.data");

                // read the file
                BinaryReader input = new BinaryReader(inStream);

                // assign values
                int levelCount = input.ReadInt32();

                // close the file
                input.Close();

                return levelCount;
            }
            else // file doesn't exist
            {
                return 0;
            }
        }

        // writing the level number to a save file
        public void SaveGame(int levelNum)
        {
            // make the stream
            FileStream outStream = File.OpenWrite("GameFile.data");

            // open the file
            BinaryWriter output = new BinaryWriter(outStream);

            // write out the value
            output.Write(levelNum);

            // close the file
            output.Close();
        }

        // properties
        public int PlayerSpeed { get { return playerSpeed; } }
        public int BulletSpeed { get { return bulletSpeed; } }
        public int Gravity { get { return gravity; } }
    }
}
