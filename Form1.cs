using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helloworld
{
    public partial class Form1 : Form
    {

        private int counter = 0;
        private readonly string path = @"c:/temp/save.txt"; 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if( !File.Exists(path))
            {
                Directory.CreateDirectory(@"c:/temp");
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("0"); // If the file doesn't exist, write the starting value to a new file
                }
            }

            string s;

            using (StreamReader sr = File.OpenText(path))
            {
                s = sr.ReadLine(); // Read the first line of the file
            }

            try
            {
                counter = Int32.Parse(s); // Attempt to read the line, and restore the current counter.
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            label1.Text = counter.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = (++counter).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            counter = 0;
            label1.Text = counter.ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // File is guranteed to exist
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.Write(counter.ToString()); // If the file doesn't exist, write the starting value to a new file
            }
        }
    }
}
