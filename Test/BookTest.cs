using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiBo.Persons;
using BiBo;
using System;

namespace Test
{
    [TestClass()]
    public class BookTest
    {
        [TestMethod()]
        public void CreateSignaturTest()
        {
            ulong bookId = 1;                           // ID
            string author = "Mueller";       			//Autor des Buch
            string titel = "Das Buch";                  //Titel
            string subjectArea = "Drama";  			    //Fachrichtung

            Book boo = new Book(bookId, author, titel, subjectArea);

            Assert.IsTrue(boo.BookId == bookId);
            Assert.IsTrue(boo.Author == author);
            Assert.IsTrue(boo.Titel == titel);
            Assert.IsTrue(boo.SubjectArea == subjectArea);

            string authorPrefix = author[0].ToString();
            string subjectAreaPrefix = subjectArea.Substring(0, 3);
            string signatur = "[" + authorPrefix + subjectAreaPrefix + "]";

            Assert.AreEqual(boo.CreateSignatur(), signatur);

        }

        [TestMethod()]
        public void ToStringTest()
        {
            ulong bookId = 1;                           // ID
            string author = "Mueller";       			//Autor des Buch
            string titel = "Das Buch";                  //Titel
            string subjectArea = "Drama";  			    //Fachrichtung

            Book boo = new Book(bookId, author, titel, subjectArea);

            Assert.IsTrue(boo.BookId == bookId);
            Assert.IsTrue(boo.Author == author);
            Assert.IsTrue(boo.Titel == titel);
            Assert.IsTrue(boo.SubjectArea == subjectArea);

            string sString = author + " " + titel + " " + subjectArea;

            Assert.AreEqual(boo.ToString(), sString);
        }


    }
}
