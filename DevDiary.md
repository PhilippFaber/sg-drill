# Dev Diary

Philipp Faber
Timo Holst
Lauren Pflüger
Anna Ring
Jessica Spuling

## Aufgabe 1 - Setup
- Unity eingerichtet 
- Projekt erstellt und ein GitHub-Repository eingerichtet.
- Bohrmechanik implementiert: Ein Dreieck bewegt sich vor einem einfarbigen Hintergrund stetig senkrecht nach unten.
- Simples Menü erstellt - Play Button führt zum Spiel

## Aufgabe 2 - Grundmechanik
- Es gibt jeweils eine Border links und rechts am Bildschirmrand, wenn man eine Border berührt "stirbt" man und das Spiel wird beendet.

- Es wurden dummy/statische Hindernisse eingefügt, welche bei Berührung mi dem/der Spieler/in dem Drill 1 Leben abziehen. Sollte man auf 0 Leben fallen ist man tod und das Spiel wird beendet. Außerdem verändert sich das Aussehen des Drills, wenn er ein Leben verliert und das getroffene Hindernis wird gelöscht.
- Die Hindernisse wurden aktualisiert, es wurden 5 verschiedene Arten von Hindernissen hinzugefügt. Die Assets für die Hindernisse sind alle Handgezeichnet.

- Der Winkel des Bohrers wird mit 0 initialisiert und dann je nach button erhöht oder verringert. 
- Die Bewegung des Bohrers wurde angepasst. Aus der momentanen Rotation des Bohrers wird die Richtung berechnet. Anstelle, dass der Bohrer entlang des Richtungsvektors bewegt wird, wird er stattdessen nur hinsichtlich der x-Komponente bewegt. Die y-Komponente wird benutzt um alle Hindernisse nach oben zu bewegen.(so sparen wir uns eine Bewegung der Kamera und das Spiel ist skalierbarer)

- Es gibt eine "Zielline" bestehend aus einem Objekt, welches der Drill berühren kann. Sollte man dieses Berühren wird das Spiel beendet.
- Man kann durch drücken von ESC das Spiel pausieren (Drill bewegt sich nicht mehr). Außerdem erscheint ein Button zum Fortsetzten des Spiels (oder wieder ESC drücken) und ein Button zum Verlassen des Spiels ins Hauptmenü.

- Wenn das Spiel beendet wird, wird das Spiel angehalten (Drill bewegt sich nicht mehr) und ein Menü erscheint, in welchem man das Spiel neustarten, ins Hauptmenü zurück und in ein Textfeld den Highscore Namen eingeben kann.

## Aufgabe 3 - Erweiterte Spielinteraktion
- Die Hindernisse werden mit einem Timer auf einer zufälligen Position entlang der X Achse gespawnt

## Aufgabe 4 - Meilensteine


## Aufgabe 5 - Finish & Polish
- Die Hindernisse Despawnen wenn in ihre y Position einen Schwellwert überschreitet.

## Sonstiges
- Der Bohrer hat eine Animation und einen ihm angehängten Körper, der sich mit ihm bewegt.
- Der Körper besitzt sich ändernde Sprites, die den aktuellen Zustand anzeigen
- Durch die Anzahl an Assets, die der Bohrkörper besitzt, hat der Spieler nun 4 Leben anstelle von 3.
