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
- Simples Menü erstellt - Play Button führt zum Spiel während Quit das spiel beendet

## Aufgabe 2 - Grundmechanik
- Es gibt jeweils eine Border links und rechts am Bildschirmrand, wenn man eine Border berührt "stirbt" man und das Spiel wird beendet.

- Es wurden dummy/statische Hindernisse eingefügt, welche bei Berührung mi dem/der Spieler/in dem Drill 1 Leben abziehen. Sollte man auf 0 Leben fallen ist man tod und das Spiel wird beendet. Außerdem verändert sich das Aussehen des Drills, wenn er ein Leben verliert und das getroffene Hindernis wird gelöscht.
- Die Hindernisse wurden aktualisiert, es wurden 5 verschiedene Arten von Hindernissen hinzugefügt. Die Assets für die Hindernisse sind alle Handgezeichnet.

- Der Winkel des Bohrers wird mit 0 initialisiert und dann je nach button erhöht oder verringert. 
- Die Bewegung des Bohrers wurde angepasst. Aus der momentanen Rotation des Bohrers wird die Richtung berechnet. Anstelle, dass der Bohrer entlang des Richtungsvektors bewegt wird, wird er stattdessen nur hinsichtlich der x-Komponente bewegt. Die y-Komponente wird benutzt um alle Hindernisse nach oben zu bewegen.(so sparen wir uns eine Bewegung der Kamera und das Spiel ist skalierbarer)

- Es gibt eine "Zielline" bestehend aus einem Objekt, welches der Drill berühren kann. Sollte man dieses Berühren wird das Spiel beendet.


- Wenn das Spiel beendet wird, wird das Spiel angehalten (Drill bewegt sich nicht mehr) und ein Menü erscheint, in welchem man das Spiel neustarten, ins Hauptmenü zurück und in ein Textfeld den Highscore Namen eingeben kann. Zusätzlich kann man das Spiel beenden.

## Aufgabe 3 - Erweiterte Spielinteraktion
- Das spawnen der Hindernisse ist an den Highscore gekoppelt. Es werden Hindernisse alle x Score-Punkte an einer zufälligen Position entlang der X Achse gespawnt. Dadurch ist es egal ob man mit dem Bohrer schräg (und somit langsamer) oder gerade (und somit schneller) 'fährt'. 
- Zusätzlich werden die Hindernisse mit einer zufallsbasierten Größe versehen.
- Es gibt insgesamt 4 verschiedene Schichten. Die Schichten sind ähnlich wie die Hindernisse an den Highscore gekoppelt (1. Schicht 0%-25%, 2. Schicht 26%-50%, 3. Schicht 51%-75%, 4. Schicht 76%-100%). Beim Wechsel in die nächste Schicht verändert sich die Farbe/ das Bild des Hintergrundes und die Drehung des Bohrers wird langsamer. Der Hintergrund wird ähnlich wie die Hindernisse unterhalb des Bildschirmes gespawnt und bewegt sich dann nach oben. Hierbei werden mehrere Bilder für den Hintergrund genommen um somit den Übergang von den Schichten geschmeidiger zu machen.



## Aufgabe 4 - Meilensteine
- Die UI-Elemente zum Hinzufügen des Highscores und anzeigen des Highscorescreens sind im Hauptmenü sowie im Game Over Screen bereits vorgemerkt.
- Der Highscore wird oben rechts in der Ecke angezeigt.
- Die aktuelle Schicht wird oben in der Mitte angezeigt (z.B. "Phase 1/4") um somit der spielenden Person zu zeigen wie weit es noch bis zum Ende ist.
  
## Aufgabe 5 - Finish & Polish
- Die Hindernisse despawnen wenn in ihre y Position einen Schwellwert überschreitet.
- Ähnlich wie die Hindernisse despawnen die Hintergrundbilder für die Schichten, wenn diese oberhalb aus dem Bildschirm sind. 

## Sonstiges
- Der Bohrer hat eine Animation und einen ihm angehängten Körper, der sich mit ihm bewegt.
- Der Körper besitzt sich ändernde Sprites, die den aktuellen Zustand anzeigen
- Man kann durch drücken von ESC das Spiel pausieren (Drill bewegt sich nicht mehr). Außerdem erscheint ein Button zum Fortsetzten des Spiels (oder wieder ESC drücken) und ein Button zum Verlassen des Spiels ins Hauptmenü.
- Durch die Anzahl an Assets, die der Bohrkörper besitzt, hat der Spieler nun 4 Leben anstelle von 3.
