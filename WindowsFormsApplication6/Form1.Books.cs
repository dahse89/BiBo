using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BiBo
{
    partial class Form1
    {
        //@todo add book to SQLLite Table
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
        }
    }
}
