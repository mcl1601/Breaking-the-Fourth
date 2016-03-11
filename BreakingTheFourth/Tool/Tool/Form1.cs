using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Tool
{
    public partial class Form1 : Form
    {
        // fields
        int playerSpeed;
        int bulletSpeed;
        int gravity;


        public Form1()
        {
            InitializeComponent();
        }

        private void PlayerBox_TextChanged(object sender, EventArgs e)
        {
            string input = PlayerBox.Text;
            playerSpeed = int.Parse(input);
        }

        private void BulletBox_TextChanged(object sender, EventArgs e)
        {
            string input = BulletBox.Text;
            bulletSpeed = int.Parse(input);
        }

        private void GravityBox_TextChanged(object sender, EventArgs e)
        {
            string input = GravityBox.Text;
            gravity = int.Parse(input);
        }

        // properties
        public int PlayerSpeed { get { return playerSpeed; } }
        public int BulletSpeed { get { return bulletSpeed; } }
        public int Gravity { get { return gravity; } }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            // make the stream
            FileStream outStream = File.OpenWrite("Values.data");

            // open the file
            BinaryWriter output = new BinaryWriter(outStream);

            // write out the values
            output.Write(playerSpeed);
            output.Write(bulletSpeed);
            output.Write(gravity);

            // close the file
            output.Close();
        }
    }
}
