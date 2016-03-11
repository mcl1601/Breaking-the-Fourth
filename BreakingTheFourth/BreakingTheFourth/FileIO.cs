using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BreakingTheFourth
{
    class FileIO
    {
        // fields
        int playerSpeed;
        int bulletSpeed;
        int gravity;
        
        // reading in the file
        public FileIO()
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

        // properties
    }
}
