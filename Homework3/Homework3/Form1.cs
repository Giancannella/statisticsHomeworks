using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;

namespace Homework3
{
    public partial class Form1 : Form
    {
        private string fileName = "";
        List<List<string>> tables = new List<List<string>>();
        List<string> headers = new List<string>();


        public Form1()
        {
            InitializeComponent();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
            this.fileName = this.openFileDialog1.FileName;

            if (!(this.fileName == ""))
            {
                using (TextFieldParser parser = new TextFieldParser(@fileName))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(";");
                    int i = 0;


                    string[] header = parser.ReadFields();
                    if (header != null)
                    {
                        foreach (string field in header)
                        {


                            this.headers.Add(field);

                            this.richTextBox1.AppendText(" | " + field + "    ");
                            this.listBox1.Items.Add(field);
                        }
                        this.richTextBox1.AppendText("\n");
                    }

                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        if (fields != null)
                        {
                            foreach (string field in fields)
                            {
                                this.tables.Add(new List<string>());
                                this.tables[i].Add(field);
                                i++;
                                this.richTextBox1.AppendText(" | " + field + "        ");
                            }
                        }
                        this.richTextBox1.AppendText("\n");
                        i = 0;
                    }
                }
                this.listBox1.Visible = true;
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            int i = this.listBox1.SelectedIndex;
            List<string> elem_list = this.tables.ElementAt(i);

            this.richTextBox2.Text = "";

            foreach (string field in elem_list)
            {
                this.richTextBox2.AppendText(field + " \n"  );

            }



        }

       

       
    }
}