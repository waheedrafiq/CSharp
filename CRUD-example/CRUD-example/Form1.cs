using System;
using System.IO;
using System.Data;
using System.Windows.Forms;

using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace CRUD_example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblSaveInfo.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(txtData.Text != null)
            {
              
                TextWriter txt = new StreamWriter(path: AppDomain.CurrentDomain.BaseDirectory + @"\" + "userData.txt");
                txt.Write(txtData.Text);
                txt.Close(); // close the file stream.

                lblSaveInfo.Text = "S";
                txtData.Clear();
            }
  
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            StreamReader txt = new StreamReader(path: AppDomain.CurrentDomain.BaseDirectory + @"\" + "userData.txt");
            // read the first line
            string line = txt.ReadLine();

            // Continue to read EOF 
            while( line != null)
            {
                txtData.AppendText(line + "\r\n");
                line = txt.ReadLine();
            }
            // close the file stream 
            txt.Close();
            lblSaveInfo.BackColor = System.Drawing.Color.Azure;
            lblSaveInfo.Text = "EOF";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string temp = "";
            List<string> tempList = new List<string>();
            // StringBuilder newfile = new StringBuilder();
            using (StreamReader txt = new StreamReader(path: AppDomain.CurrentDomain.BaseDirectory + @"\" + "userData.txt"))
            {

                // read the first line
                string line = txt.ReadLine();
               
                    while (line != null)
                    {

                      
                     Debug.WriteLine("In the IF");
                     temp = line.Replace(txtFind.Text.Trim(), txtUpdate.Text.Trim());
                     line = txt.ReadLine();
                     tempList.Add(temp);
                          

                    }// end of while read to EOF..

                txt.Close(); // close the stream

                using (StreamWriter txtwrite = new StreamWriter(path: AppDomain.CurrentDomain.BaseDirectory + @"\" + "userData.txt"))
                {
                    foreach( string lines in tempList)
                    {
                        txtwrite.WriteLine(lines);
                    }
                    txtwrite.Close();

                }


                lblSaveInfo.BackColor = System.Drawing.Color.Cornsilk;
                lblSaveInfo.Text = "Updated";
                txtData.Clear();
               
            }
         
           

        }// end of update mehtod

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // C# 6.0 using Lambda expressions  

            string usersPath = Path.GetFullPath(path:AppDomain.CurrentDomain.BaseDirectory + @"\" + "userData.txt");
            string item = txtData.SelectedText.Trim();
            var lines = File.ReadAllLines(usersPath).Where(line => line.Trim() != item).ToArray();
            File.WriteAllLines(usersPath, lines);

            lblSaveInfo.BackColor = System.Drawing.Color.DarkGreen;
            lblSaveInfo.Text = "Deleted";
            txtData.Clear();

        }// end of Delete method

        private void Form1_Load(object sender, EventArgs e)
        {
            
        
        }
    }// end of class
}// end of namespace 
