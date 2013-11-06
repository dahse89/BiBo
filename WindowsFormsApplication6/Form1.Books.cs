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

            foreach (Book book in SqlBook.GetAllEntrys())
            {
                addBookToTable(book);
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

        //add books to datagridview
        private void addBookToTable(Book book)
        {
            this.booksTableDataSet.Rows.Add(
                false,
                book.BookId,
                book.Author,
                book.Titel,
                book.SubjectArea
             );
        }

        //add book to SQLLite Table
        private void addBooksActionButton_Click(object sender, EventArgs e)
        {
            //author
            String author = this.textBoxBookAddauthor.Text;
            String title = this.textBoxBookAddTitel.Text;
            String genre = this.textBoxBookAddsubjectArea.Text;

            //all textboxes to white
            textBoxBookAddauthor.BackColor = Color.White;
            textBoxBookAddTitel.BackColor = Color.White;
            textBoxBookAddsubjectArea.BackColor = Color.White;

            if (Validation.isEmpty(author))
            {
                textBoxBookAddauthor.BackColor = Color.Red;
                return;
            }

            if (Validation.isEmpty(title))
            {
                textBoxBookAddTitel.BackColor = Color.Red;
                return;
            }

            if (Validation.isEmpty(genre))
            {
                textBoxBookAddsubjectArea.BackColor = Color.Red;
                return;
            }

            //save book in SQLLite table
            addBookToTableAndDb(author, title, genre);
            clearBookAddForm();

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
                tmp = SqlBook.GetEntryById(id);

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
        
        //summary of add book functions
        private void addBookToTableAndDb(String author,String title, String genre){

                Book dummy = new Book(0,author,title,genre);
                ulong bookID = SqlBook.AddEntryReturnId(dummy);

            addBookToTable(new Book(
                bookID,
                author,
                title,
                genre
                ));
        }

        private void deleteSelectedBooks()
        {
            //init a list for collecting id that should be deleted
            List<ulong> potentialDeletedIds = new List<ulong>();

            //placeholder of id
            ulong id;

            //run  through all rows
            for (int i = 0; i < booksTableDataSet.Rows.Count; i++)
            {
                //get DataGridViewCheckBoxCell Object from checkbox colum
                DataGridViewCheckBoxCell chkchecking = booksTableDataSet.Rows[i].Cells[0] as DataGridViewCheckBoxCell;

                //get value of checkbox
                if ((bool)chkchecking.Value == true) //if checkbox id checked
                {
                    //get customer id from row and add to list of ids
                    id = (ulong)Convert.ToInt64(booksTableDataSet.Rows[i].Cells[1].Value.ToString());
                    potentialDeletedIds.Add(id);
                }
            }

            //delete all books whose id is in the list
            SqlBook.DeleteEntryByIdList(potentialDeletedIds);

            //remove book from table
            foreach (ulong x in potentialDeletedIds)
            {
                foreach (DataGridViewRow row in booksTableDataSet.Rows)
                {
                    if (x == (ulong)Convert.ToInt64(row.Cells[1].Value.ToString()))
                    {
                        booksTableDataSet.Rows.RemoveAt(row.Index);
                        break;
                    }
                }
            }
        }
    }
}
