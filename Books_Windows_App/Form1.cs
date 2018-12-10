using Books_Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Books_Windows_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Books_Lib.BooksEntities dbC = new Books_Lib.BooksEntities();
            dbC.Titles.Load();



            var authorsAndTitles = from book in dbC.Titles
                                   orderby book.Title1
                                   select new { book.Title1, book.Authors };

            outputTextBox.AppendText("\r\n\r\n\t Authors \t\t\t Titles:");
            foreach (var item in authorsAndTitles)
            {
                var authorss = item.Authors;
                foreach(var item1 in authorss)
                {
                    outputTextBox.AppendText(string.Format("\r\n\t{0,-10} {1,-10} {2}", item1.LastName, item1.FirstName, item.Title1));
                }

               
            }






            var authorsAndTitles1 = from book in dbC.Titles
                                   orderby book.Title1
                                   select new { book.Title1, book.Authors };

            textBox1.AppendText("\r\n\r\n\t Authors \t\t\t Titles:");
            foreach (var item in authorsAndTitles1)
            {
                var authorss = from author in item.Authors
                               orderby author.LastName,author.FirstName
                               select author;
                foreach (var item1 in authorss)
                {
                    textBox1.AppendText(string.Format("\r\n\t{0,-10} {1,-10} {2}", item1.LastName, item1.FirstName, item.Title1));
                }


            }





            
          


        }
    }
}