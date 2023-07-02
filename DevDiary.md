# Dev Diary

Philipp Faber
Timo Holst
Lauren Pflüger
Anna Ring
Jessica Spuling

## Aufgabe 1 - Setup
- Unity eingerichtet 
- Projekt erstellt und ein GitHub-Repository eingerichtet.
- Der Bohrer soll sich immer an der gleichen y position befinden.
- Bohrmechanik implementiert: Ein Dreieck bewegt sich vor einem einfarbigen Hintergrund stetig senkrecht nach unten.
- Simples Menü erstellt - Play Button führt zum Spiel während Quit das spiel beendet

## Aufgabe 2 - Grundmechanik
- Es gibt jeweils eine Border links und rechts am Bildschirmrand, wenn der Bohrer eine Border berührt "stirbt" dieser und das Spiel wird beendet.

- Es wurden dummy/statische Hindernisse eingefügt, welche bei Berührung mit dem Bohrer diesem 1 Leben abzieht. Sollte man auf 0 Leben fallen ist man tod und das Spiel wird beendet. Außerdem verändert sich das Aussehen des Drills, wenn er ein Leben verliert und das getroffene Hindernis wird gelöscht.
- Die Hindernisse wurden aktualisiert, es wurden 5 verschiedene Arten von Hindernissen hinzugefügt. Die Assets für die Hindernisse sind alle Handgezeichnet.
- Das Aussehen des Bohrers wurde aktualisiert(siehe Sonstiges).

- Die Bewegung des Bohrers wurde aktualisiert:
  - Der Winkel des Bohrers wird mit 0 initialisiert und dann je nach button erhöht oder verringert. 
  - Der Winkel kann einen Grenzwert(-70, 70) nicht unter oder überschreiten. So wird sichergestellt, dass der Bohrer sich nicht nach oben bewegen kann.
  - Aus der momentanen Rotation des Bohrers wird die Richtung berechnet. Anstelle, dass der Bohrer entlang des Richtungsvektors bewegt wird, wird er stattdessen nur hinsichtlich der x-Komponente bewegt. Die y-Komponente wird benutzt um alle Hindernisse nach oben zu bewegen.(so sparen wir uns eine Bewegung der Kamera und das Spiel ist skalierbarer, da der y-Wert des Bohrers nicht beliebig groß werden kann)

- Es gibt eine "Zielline" bestehend aus einem Objekt, welches der Drill berühren kann. Sollte man dieses Berühren wird das Spiel beendet.


- Wenn das Spiel beendet wird, wird das Spiel angehalten (Drill/Hindernisse bewegen sich nicht mehr) und ein Menü erscheint, in welchem man das Spiel neustarten, ins Hauptmenü zurück und in ein Textfeld den Highscore Namen eingeben kann. Zusätzlich kann man das Spiel beenden und es wird als Text angezeigt, ob man gewonnen hat oder bis zu welcher Phase man es geschaft hat.

## Aufgabe 3 - Erweiterte Spielinteraktion

- Der aktuelle Highscore wird oben rechts in der Ecke angezeigt. Dieser hängt mit der bisher erreichten Tiefe zusammen. Wenn der Spieler sich also viel Vertikal (und damit wenig Horizontal) bewegt, steigt der Score schneller.
- Das spawnen der Hindernisse ist an den Highscore gekoppelt. Alle x Score-Punkte wird ein Unity-Event ausgelöst, wodurch der Hindernis-Spawner aufgerufen wird und dieser Hindernisse an einer zufälligen Position entlang der X Achse spawnt. Dadurch ist es egal ob man mit dem Bohrer schräg (und somit langsamer) oder gerade (und somit schneller) 'fährt'. 
- Zusätzlich werden die Hindernisse mit einer zufallsbasierten Größe versehen.
- Es gibt insgesamt 4 verschiedene Schichten. Die Schichten sind ähnlich wie die Hindernisse an den Highscore gekoppelt (1. Schicht 0%-25%, 2. Schicht 26%-50%, 3. Schicht 51%-75%, 4. Schicht 76%-100%). Beim Wechsel in die nächste Schicht wird ein Unity-Event ausgelöst (PhaseOneFinished, PhaseTwoFinished, PhaseThreeFinished), wodurch im Hintergrund-Spawner die neuen Hintergrundbilder verändert werden. Außerdem wird die Drehgeschwindigkeit des Bohrers mit jeder abgeschlossenen Schicht langsamer. Der Hintergrund wird ähnlich wie die Hindernisse, durch ein Unity-Event, unterhalb des Bildschirmes gespawnt und bewegt sich dann nach oben. Hierbei werden mehrere Bilder für den Hintergrund genommen um somit den Übergang von den Schichten geschmeidiger zu machen.



## Aufgabe 4 - Meilensteine
- Die UI-Elemente zum Hinzufügen des Highscores und anzeigen des Highscorescreens sind im Hauptmenü sowie im Game Over Screen bereits vorgemerkt.
- Die aktuelle Schicht wird oben in der Mitte angezeigt (z.B. "Phase 1/4") um somit der spielenden Person zu zeigen wie weit es noch bis zum Ende ist. Der Text wird auch durch das Unity-Event wie in Aufgabe 3 beschrieben (PhaseOneFinished, PhaseTwoFinished, PhaseThreeFinished) gesetzt.
- beim Wechsel von einer Schicht in die nächste (siehe Aufgabe 3) wird das Spiel angehalten und Zark Muckerberg erscheint mit einem Text und der Text wird vorgelesen. Sobald der Text zuende gelesen wurde wird das Spiel fortgesetzt. Zark Muckerberg erscheint 3 mal (Schicht 1 abgeschlossen, Schicht 2 abgeschlossen, Schicht 3 abgeschlossen).
  
## Aufgabe 5 - Finish & Polish

- Beim Game Over Menü wurde ein Textfeld hinzugefügt. Sobald ein Name für den Highscore eingegeben wurde, wird dieser gespeichert. Zum Speichern werden die Unity User Preferences benutzt.
- Ein Hindernis wird gelöscht, wenn seine y Position einen Schwellwert überschreitet (außerhalb des oberen Bildschirmes).
- Ähnlich wie die Hindernisse wird ein Hintergrundbild für die Schichten gelöscht, wenn es oberhalb aus dem Bildschirm ist. 

## Sonstiges
- Der Bohrer hat eine Animation und einen ihm angehängten Körper, der sich mit ihm bewegt.
- Der Körper besitzt sich ändernde Sprites, die den aktuellen Zustand anzeigen
- Man kann durch drücken von ESC das Spiel pausieren (Drill bewegt sich nicht mehr). Außerdem erscheint ein Button zum Fortsetzten des Spiels (oder wieder ESC drücken) und ein Button zum Verlassen des Spiels ins Hauptmenü.
- Durch die Anzahl an Assets, die der Bohrkörper besitzt, hat der Spieler nun 4 Leben anstelle von 3.
