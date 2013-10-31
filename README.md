BiBo
====
Wir sollten vielleicht auch mal drüber nachdenken, ob wir nicht die Konstruktoren generell ohne Parameter erstellen.
Konstruktoren mit Parametern sind generell ja nix schlechtes. Aber sie werden in aktuellen Frameworks nicht mehr verwendet,
da immer der Zwang besteht diese auch so zu Benutzen, wie der Entwickler es vorgesehen hat.
Sollten wir eventuell nochmal drüber nachdenken.

PS: Oder wir machen es so, wie bei dem Customer Obj. das wir den Konstruktor so überladen, dass auch eine Erzeugung ohne
Parameter möglich ist.

Marcus:
Die Readme zur unterhaltung nutzen, auch nicht schlecht ^^
Von mir aus gerne einfach noch nen Default Konstruktor setzen. Aber bei Klassen, die Variablen haben die nur einmal gesetzt 
werden, und keine setter haben, klappt das nicht, da diese ja später nicht mehr neu gesetzt werden können.
