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
        Form2 secondForm;

        public Form1()
        {
            InitializeComponent();
        }

        private void PlayerBox_TextChanged(object sender, EventArgs e)
        {
            string input = PlayerBox.Text;
            if(int.TryParse(input, out playerSpeed))
            {
                playerSuccess.Text = "Valid";
            }
            else { playerSuccess.Text = "Invalid Data"; }
        }

        private void BulletBox_TextChanged(object sender, EventArgs e)
        {
            string input = BulletBox.Text;
            if(int.TryParse(input, out bulletSpeed))
            {
                bulletSuccess.Text = "Valid";
            }
            else { bulletSuccess.Text = "Invalid Data"; }
        }

        private void GravityBox_TextChanged(object sender, EventArgs e)
        {
            string input = GravityBox.Text;
            if(int.TryParse(input, out gravity))
            {
                gravitySuccess.Text = "Valid";
                if(int.Parse(input) <= 4)
                {
                    gravitySuccess.Text = "Invalid Data";
                }
            }
            else { gravitySuccess.Text = "Invalid Data"; }
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

            // display a window signifying completion
            if(secondForm == null)
            {
                secondForm = new Form2();
            }

            // show the form
            secondForm.Show();
        }
    }
}
