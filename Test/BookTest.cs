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
            string author = "Mueller";       			//Autor des Buch
            string titel = "Das Buch";                  //Titel
            string subjectArea = "Drama";  			    //Fachrichtung

            string authorPrefix = author[0].ToString();
            string subjectAreaPrefix = subjectArea.Substring(0, 3);

            string signatur = "[" + authorPrefix + subjectAreaPrefix + "]";


            ulong bookId = 1;
            Book boo = new Book(bookId, author, titel, subjectArea);

            Assert.IsTrue(boo.BookId == bookId);
            Assert.IsTrue(boo.Author == author);
            Assert.IsTrue(boo.Titel == titel);
            Assert.IsTrue(boo.SubjectArea == subjectArea);


            Assert.AreEqual(boo.CreateSignatur(), signatur);

        }

    }
}
