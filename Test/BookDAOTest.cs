using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiBo.DAO;
using System;
using BiBo.SQL;
using System.Collections.Generic;

namespace BiBo.Test
{
    [TestClass()]
    public class BookDAOTest
    {
        [TestMethod()]
        public void AddBookTest()
        {
            GUIApi gui = new GUIApi(true);
            BiBo.Library lib = new BiBo.Library();
            BookDAO dao = new BookDAO(gui, lib);

            ulong bookId = 100;                           // ID
            string author = "Mueller";       			//Autor des Buch
            string titel = "Das Buch";                  //Titel
            string subjectArea = "Drama";  			    //Fachrichtung

            Book boo = new Book(bookId, author, titel, subjectArea);

            BookSQL bookSql = SqlConnector<Book>.GetBookSqlInstance();
            ExemplarSQL exemplarSql = SqlConnector<Exemplar>.GetExemplarSqlInstance();

            dao.getAllBooks();

            int countOfExamples = 1;
            dao.AddBook(boo, countOfExamples);

            Exemplar ex = new Exemplar(boo);
            for (int i = 0; i < countOfExamples; i++)
            {

                ulong id = exemplarSql.AddEntryReturnId(ex);
                ex.ExemplarId = id;
                boo.Exemplare.Add(ex);

                Assert.IsTrue(ex.BookId == exemplarSql.AddEntryReturnId(ex));
                Assert.IsTrue(ex.ExemplarId == id);
            }

            boo.BookId = bookSql.AddEntryReturnId(boo);

            Assert.IsTrue(boo.BookId == bookSql.AddEntryReturnId(boo));
            
            Assert.IsNotNull(lib.BookList);
            lib.BookList.Add(boo);

            Assert.IsTrue(lib.BookList.Contains(boo));
            

            gui.AddBook(boo);



        }
    }
}
