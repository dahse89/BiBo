using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiBo.Persons;
using BiBo;
using System;

namespace Test
{
    [TestClass()]
    public class BookStatesTest
    {
        [TestMethod()]
        public void BookStateTest()
        {
            ulong bookId = 1;                           // ID
            string author = "Mueller";       			//Autor des Buch
            string titel = "Das Buch";                  //Titel
            string subjectArea = "Drama";  			    //Fachrichtung

            Book buch = new Book(bookId, author, titel, subjectArea);
            Exemplar ex = new Exemplar(buch);

            ex.State = Converter.ToBookState("only_visible");
            Assert.IsTrue(ex.State == BookStates.ONLY_VISIBLE);

            ex.State = Converter.ToBookState("damaged");
            Assert.IsTrue(ex.State == BookStates.DAMAGED);

            ex.State = Converter.ToBookState("missing");
            Assert.IsTrue(ex.State == BookStates.MISSING);

            ex.State = Converter.ToBookState("ok");
            Assert.IsTrue(ex.State == BookStates.OK);

         
        }
    }
}
