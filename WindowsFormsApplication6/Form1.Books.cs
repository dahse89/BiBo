using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BiBo
{
    partial class Form1
    {

        //fill GUI with content
        private void publishBookContent()
        {
            //create data table for datagridview

            //set number of culoms
            this.booksTableDataSet.ColumnCount = 4;

            //set colum names
            this.booksTableDataSet.Columns[0].Name = "ID";
            this.booksTableDataSet.Columns[1].Name = "Author";
            this.booksTableDataSet.Columns[2].Name = "Title";
            this.booksTableDataSet.Columns[3].Name = "Genre";

            //insert a special colum for checkboxes
            this.booksTableDataSet.Columns.Insert(0, new DataGridViewCheckBoxColumn());

            foreach (Book book in lib.getBookDAO().getAllBooks())
            {
              lib.getGuiApi().AddBook(book);
            }

            //make table readonly
            setBooksTableReadOnly();
           
        }

        //clear book add form
        private void clearBookAddForm()
        {
            this.textBoxBookAddauthor.Text = "";
            this.textBoxBookAddsubjectArea.Text = "";
            this.textBoxBookAddTitel.Text = "";
        }

        //set all cells in datagridview readonly. except the checkbox cells
        private void setBooksTableReadOnly()
        {
            //run through all rows
            for (int i = 0; i < this.booksTableDataSet.Rows.Count; i++)
            {
                //run through all cells of row
                for (int j = 0; j < this.booksTableDataSet.Rows[i].Cells.Count; j++)
                {
                    if (j != 0) // if not is checkbox cell
                    {
                        //set cell readonly
                        this.booksTableDataSet.Rows[i].Cells[j].ReadOnly = true;
                    }
                }
            }
        }
       

        private void searchBookTable(String str)
        {

            Book tmp;
            ulong id;
            string sid;

            //run througth rows
            for (int i = 0; i < booksTableDataSet.Rows.Count; i++)
            {
                //get customer id as string
                sid = booksTableDataSet.Rows[i].Cells[1].Value.ToString();

                //convert id string to ulong
                id = (ulong)Convert.ToInt64(sid);

                //get customer form SQLLite table
                tmp = sqlBook.GetEntryById(id);

                //check if search input is in toString value of customer
                if (!tmp.ToString().ToUpper().Contains(str.ToUpper()))
                {
                    //hide row
                    booksTableDataSet.Rows[i].Visible = false;
                }
                else
                {
                    //show row
                    booksTableDataSet.Rows[i].Visible = true;
                }
            }
        }
        
    }
}
