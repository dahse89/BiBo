BiBo
====
Wir sollten vielleicht auch mal darüber nachdenken, ob wir nicht die Konstruktoren generell ohne Parameter erstellen.
Konstruktoren mit Parametern sind generell ja nix schlechtes. Aber sie werden in aktuellen Frameworks nicht mehr verwendet,
da immer der Zwang besteht diese auch so zu Benutzen, wie der Entwickler es vorgesehen hat.
Sollten wir eventuell nochmal drüber nachdenken.

PS: Oder wir machen es so, wie bei dem Customer Obj. das wir den Konstruktor so überladen, dass auch eine Erzeugung ohne
Parameter möglich ist.

Marcus:
Die Readme zur unterhaltung nutzen, auch nicht schlecht ^^
Von mir aus gerne einfach noch nen Default Konstruktor setzen. Aber bei Klassen, die Variablen haben die nur einmal gesetzt 
werden, und keine setter haben, klappt das nicht, da diese ja später nicht mehr neu gesetzt werden können.

Vico:
Also ich finde es ne gute Idee, da diese Datei ja immer zu sehen ist :D
Öhm, naja, das ist in der Tat so!
Aber ich würde der Einfachkeit-halber noch einen Default Konstruktor definieren, welcher ohne Parameter aufgerufen werden kann!

Philipp: Hab mal das Aufgaben_Blatt.jpg mit reingepackt. Ich versteh was Ihr meint mit den Konstruktoren und dann müsste z.B.
Customer auch einen Setter für die ID haben, was ich allerdings sehr begrüßen würde, siehe Form1.Customer.pushUserToGUITableAndDB() -> dummy

TODOs
=====

info
----
Bis jetzt habe ich alles so gemacht wie Vico es ursprünglich vorgeschlagen hatte. Ich habe alle Änderungen direkt in der DB gemacht und im GUI, dann gibt es zwar keine, wie ursprünglich von mir vorgeschlagen, Object-Ebene die immer im RAM liegt, aber das ist ok. Bei den Classen Methoden sollten wir das also bei behalten.

create ChargeAccountDAO
-----------------------
--> Marcus: integriert, jedoch noch nicht implementiert, mach ich dieses WE
Ich würde es gut finden wenn wir auch einen SQLLite Table für das Begührenknto hätten.
Dann könnten wir die History des Kontos abbilden. Ich würde folgende Felder vorschlagen:
 
 * customer_id
 * changed_at (Zeitpunkt der Änderung)
 * change_value (Wert der Änderung +5,23 oder -8.00)
 * current_value (Wert incl. aller Änderungen bevor z.B 10.59)

zum abfragen des aktuellen Standes müsste man nur den Eintrag mit dem neusten changed_at Datum betrachten

Methods for Customer[DAO] Object
---------------------------

Erstmal hätte ich hier eine Grundlegende Frage:

Wollen wir die DB Abfragen und die Objekte vermischen oder nicht. Was ich meine ist folgnedes:

Kann das Object auf die DB zugreifen oder geift immer das DB Object auf die Objecte zu. z.B:
```cs
    /*
     * delete a customer
     */
     
     //Customer can access DB
     Customer x = new Customer(/*what ever here*/);
     x.deleteFromDB();
     
     //DB Obeject can access Customer
     CustomerDAO y =  SqlConnector<Customer>.GetCustomerSqlInstance();
     y.DeleteEntry(x);
```

Bisher haben wir ja die zweite Variante eingeschlagen. Was meint Ihr zu der Anderen?

Wie auch immer wir das machen es müssen noch folgende Funktionalitäten fürs Customer Object abegedeckt werden:
--> Marcus: integriert, jedoch noch nicht implementiert, mach ich dieses WE
* bool borrowBook(ulong bookId)
* bool noBooksBorrowed()
* bool hasOwe()
* void mergeBlanaceWith(int +/-value) 
* create IDCard
* extend IDCard
* orderBookInAdvance(ulong bookId)

Methods for Book[DAO] Object 
============================
--> Marcus: integriert, jedoch noch nicht implementiert, mach ich dieses WE
* int getNumberOfExemplars()
* int getNumberOfAvailableExemplars();
* int getDateOfEarliestAvailable();
* bool borrowExemplar(DateTime dateBookWillBeBack, String signatur)
* delteAllExemplars()
* void addExemplar(Exemplar x)
* removeExemplar(String signatur)

Methods for Exemplar[DAO] Obejct
============
--> Marcus: integriert, jedoch noch nicht implementiert, mach ich dieses WE
* void extendLoanPeriodTo(DateTime dateBookWillBeBack)
* void reduceLoanPeriodTo(DateTime dateBookWillBeBack)
* bool borrow(DateTime dateBookWillBeBack,String cardId)

create Class Library
====================
--> Marcus: ist als Klasse schon lange vorhanden, benötigt nur noch eine sinnvolle Implementierung
diese klasse stellt die ganze Bibliothek dar
hier können dann die öffnungeszeiten gestezt werden und z.B Mahnungen gerneriert werden usw.




*Das sind natürlich alles nur Vorschläge also lasst mich wissen was keinen Sinn macht*

PS: macht echt Spass mit euch zu arbeiten =)


Marcus:

irgendwie kommt mir deine letzte aussage ironisch vor ... wenn ich mir die Commit-historie ansehe, sehe ich nur noch
deine commits. mach mal ruhig junge, sonst sind wir in nem monat fertig und haben nichts mehr zu tun ^^

Also im bezug auf die Frage, ob das Customer direkten zugriff auf die DB haben sollte, bin ich entschieden dagegen.
genau für solch sachen sind ja solch DAO´s (Data Access Objects) da, um das eigentliche Objekt und seine Eigenschaften zu kapseln,
und eine Eigenständige Klasse zu haben, die die Aufgaben für das schreiben und lesen übernehmen.
OOD mäßig ist das denke ich, so wie wir das haben völlig ok. Aber ich kann mich da gerne nochmal schlau machen.
Ansonsten würde ich mich das wochenende und am Montag (ich muss zwar arbeiten gehen, aber nur so lange wie wir unterricht
haben und kann schulzeug erledigen) hinsetzen und alle Methoden, die du in den DAO´s braucht implementieren.
Yevgen habe ich damit beauftragt, mal ordentliche Tests zu schreiben, da dürften wir auch bald eine 
Rückmeldung bekommen.
    
