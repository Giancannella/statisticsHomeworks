using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;

namespace Csv_parse
{
    public partial class Form1 : Form
    {
        List<string> sex = new List<string>();
        List<int> weight = new List<int> ();
        List<int> height = new List<int>();
        List<string> hair_color = new List<string>();
        List<string> eyes_color = new List<string>();
        List<int> age = new List<int>();



        public Form1()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            this.listBox1.Visible = true;
            using (TextFieldParser parser = new TextFieldParser("C:\\Users\\locan\\Desktop\\Cybersecurity\\Statistics/Statistics_students_dataset_22_23-Foglio1.csv"))
            {
                
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");

                parser.ReadFields();
                while (!parser.EndOfData)
                {

                    string[] fields = parser.ReadFields();
                    
                    for (int i = 0; i< fields.Length ;i++)
                    {
                        if (i==0)
                        {
                            this.sex.Add(fields[i].ToLower());
                        }else
                        if (i == 1){
                            this.weight.Add(Int32.Parse(fields[i]));
                        }else
                        if (i == 2)
                        {
                            this.height.Add(Int32.Parse(fields[i]));
                        }else
                        if (i == 3)
                        {
                            this.hair_color.Add(fields[i].ToLower());
                        }else
                        if (i == 4)
                        {
                            this.eyes_color.Add(fields[i].ToLower());
                        }else
                        if (i == 5)
                        {
                            this.age.Add(Int32.Parse(fields[i]));
                        }


                        this.richTextBox1.AppendText(fields[i] + ", ");
                    }
                    this.richTextBox1.AppendText("\n");
                    this.richTextBox1.ScrollToCaret();
                }

                

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                this.richTextBox2.Clear();
                List<int> sexcounted = new List<int>();
                List<string> temp = new List<string>();

                for(int i = 0; i < sex.Count; i++)
                {
                    
                    if(temp.Count ==0) 
                    {
                        temp.Add(sex[i]);
                        sexcounted.Add(1);
                    }
                    else
                    {
                        for(int j = 0; j < temp.Count; j++)
                        {
                            if(sex[i].Equals(temp[j]))
                            {
                                sexcounted[j]++;
                            }
                            else
                            {
                                temp.Add(sex[i]);
                                sexcounted.Add(1);
                            }
                        }
                    }
                    
                    
                }

                for (int i = 0; i < 2; i++)
                {
                    String field = temp[i];
                    int numero = sexcounted[i];
                    this.richTextBox2.AppendText(field + ": " + numero.ToString() + "\n");
                }
                
            }
            
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}