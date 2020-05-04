# ideocracy <br>
<h2>Allgemeines</h2>
Das Spiel wurde in Unity 2019 entwickelt. Zur Implementation der Funktionen des Spiels wurden Klassen in C# programmiert. <br>
Die Programmstruktur wurde so flexibel wie möglich gehalten. Hierzu wurde ein weitreichende Objekthierarchie entwickelt, die vor allem die Ansprechbarkeit der Objekte durch Schleifen im Programmcode ermöglichen sollte. Des Weiteren wurden keine Inhalte (Maßnahmen, Events, usw) in den Code geschrieben, sondern in einzelne Objekte in Unity integriert. Entsprechend ließe sich das Programm leicht durch weitere Maßnahmen oder Ereignisse, gegebenenfalls sogar durch weitere Attribute, Ressorts oder Ideologien ergänzen.<br>
Das Spiel hat eine native Auflösung von 1920x1080px und die UI ist entsprechend darauf ausgerichtet. Davon abweichende Seitenverhältnisse oder höhere Auflösungen werden ebenfalls problemlos unterstützt, niedrigere Auflösungen können hingegen Probleme in der Darstellung (Überschneidung von UI usw) verusachen.<br><br>
<a href="https://drive.google.com/file/d/10AIamgU4ca_0ijvNDi37aPWNxRKB16da/view?usp=sharing"><b>Download <i>ideocracy</i> (Windows)</b></a><br>
<a href="https://drive.google.com/file/d/1rLlv_Xam0cR9A2hHixgLSfFUpHgnnQv0/view?usp=sharing"><b>Download <i>ideocracy</i> (Unity Projekt Ordner)</b></a><br>
<h2>Features</h2>
Eine grundsätzliche Beschreibung des Spiels und seiner Grundfunktionen können der schriftlichen Ausarbeitung entnommen werden.<br><br>
Features, die über die Grundfunktionen des Programms hinausgehen:
<ul>
<li><b>Rückmeldungen der UI-Flächen</b>: Die Buttons und Attribute reagieren mit Animationen und Tönen auf Hovern und bieten so eine interaktive Nutzererfahrung. Gehoverte Maßnahmen und Ereignisse zeigen die dadurch bewirkten Veränderungen der Attribute an. In der Ressortwahl wird auch angezeigt, wie oft die Ressorts noch wählbar sind, sollten diese nicht mehr wählbar sein, wird ein Signalton abgespielt.</li>
<li><b>Chronik</b>: Eine Chronik zeigt die bereits geschehenen Ereignisse und verabschiedeten Maßnahmen an. Diese werden innerhalb des Programms in den Chronik-"Container" verschoben. Durch Hovern können auch hier die dadurch bewirkten Veränderungen sichtbar gemacht werden.</li>
<li><b>Pause</b>: Die Spielenden können das Spiel über einen Button oder die "Escape"-Taste pausieren.</li>
<li><b>Tutorial</b>: Ein ausführliches Tutorial erklärt alle Elemente des Spiels Stück für Stück beim ersten Mal spielen. Danach kann es erneut über den Hilfe-Button aufgerufen werden.</li>
<li><b>Endscreen</b>: Nach der letzten Runde wird ein Endscreen angezeigt, der die finalen Punkte und Attributswerte anzeigt. Darüber hinaus können die Spielenden hier die Chronik betrachten und sich Graphen zu den gewählten Maßnahmen anzeigen lassen. Für den "Konfetti"-Effekt wurde ein eigens entworfenes Partikelsystem eingebaut.</li>
</ul>
<h2>Design</h2>
Das visuelle Design des Videospiels orientiert sich am frei verfügbaren und kostenlos nutzbaren <a href="https://www.material.io">Material-Design</a> von Google. So wurden die Schriftart und alle verwendeten Icons für das Menü und die Attribute von dort importiert, auch die Farbgebung wurde nach der dort veröffentlichten Richtlinie gestaltet. Für die Implementation der Animationen auf den UI-Elementen wurde das Unity-Plugin <a href="https://assetstore.unity.com/packages/tools/gui/doozyui-complete-ui-management-system-138361">DoozyUI</a> verwendet. Das Logo wurde selbst entworfen.<br>
Das auditive Design wurde vollständig selbst erarbeitet, die benötigten Sounds wurden aus der kostenlosen Datenbank <a href="https://www.freesound.org">freesound.org</a> geladen und sind aufgrund der Creative Commons License frei verwendbar. Die Sounds wurden ggf angepasst.<br>
Der Name <i>ideocracy</i> (stilisiert in Kleinschreibung) ist ein Kofferwort aus dem englischen ‚Ideology‘ und dem griechischen ‚Kratos‘ (‚Macht‘, wie in ‚Democracy‘) und soll eine ideologisch orientierte Führungsweise zum Ausdruck bringen.<br>
<h2>"Landkarte" durch die Unity-Objekthierarchie</h2>
<b>Aufbau der Objekthierarchie in Unity</b><br>
Hiearchie Ebenen sind durch "-" gekennzeichnet, ggf in eckigen Klammern vor dem Objekt, wie oft dieses jeweils vorkommt, in Runden Klammern anschließend die Erklärung.<br><br>

"Canvas" (Elternobjekt aller UI-Elemente)<br>
-"Ressortwahl" (beinhaltet die 6 Buttons der Ressortwahl)<br>
--[6x]Ressort (der Ressort-Button)<br>
---"Massnahmen" (beinhaltet die Maßnahmen nach Ideologie)<br>
----[3x]Ideologie (beinhaltet die einzelnen Maßnahmen)<br>
-----[3-9x]Maßnahme (Objekt, das die Beschreibung und alle Werte der Maßnahme beinhaltet, wird nach Auswahl in Maßnahmen-Container verschoben)<br>
---"Text" (Beschriftung des Ressortbuttons)<br>
---"Ressortrunden" (beinhaltet die blauen Kästchen, die anzeigen, wie oft das Ressort noch gewählt werden kann)<br>
-"Massnahmenwahl" (beinhaltet die 3 Buttons der Maßnahmenwahl)<br>
--[3x]Ideologie (Button für die Maßnahme der jeweiligen Ideologie)<br>
---"Text" (Beschriftung des Buttons)<br>
-"Massnahmenwahl2" (beinhaltet die Überschriften für die Maßnahmenwahl)<br>
--[4x]Überschrift (Überschriften für die drei Ideologien und das gewählte Ressort)<br>
-"Rundenanzeige" (Rundenanzeige unten rechts)<br>
-"Endscreen" (beinhaltet alle Elemente für den Endscreen)<br>
--"Endscreen Hintergrund" (grauer Hintergrund des Endscreens, aus Layout-Gründen auch Elternobjekt von Teilen der UI-Elemente)<br>
---"Sidebar" (beinhaltet die Buttons am Rand des Endscreens, mit denen zwischen den Reitern umgeschaltet wird)<br>
----[3x]Button (Buttons am Rand des Endscreens, mit denen zwischen den Reitern umgeschaltet wird)<br>
----[3x]Image (Icons auf den Buttons, wegen Animationen getrennt von den Buttons)<br>
---"Endpunkte" (zeigt den Endpunktestand an)<br>
---"IdeologienStats" (beinhaltet die Statistiken, wie oft Maßnahmen der jeweiligen Ideologien gewählt wurden)<br>
----[3x]Ideologie (für jede Ideologie ein 'Balken')<br>
-----[4x]Balken-Elemente (Text, Hintergrund, Name und Balken für die Statistik)<br>
---[4x]StatsText (Überschriften, die bei den Statistiken angezeigt werden)<br>
--"EndscreenText" (Überschrift im Endscreen)<br>
--"EndscreenButtons" (beinhaltet die eckigen Buttons im Endscreen)<br>
---[2x]EndscreenButton (Buttons für Neustart und Verlassen)<br>
-"Curtain" (grauer 'Vorhang' im Pausen- und Chronikmenü, beinhaltet alle Elemente für diese Menüs)<br>
--"Text" (Überschrift für die Chronik)<br>
--"Scroll View" (Scrollbares Fenster, das die Chronik beinhaltet)<br>
---"Viewport" (Sichtbarer Bereich des Fensters)<br>
----"Content" (beinhaltet die einzelnen Maßnahmen und Events der Chronik)<br>
-----[Anzahl dynamisch]"HistoryMassnahme" (beinhaltet eine konkrete Maßnahme oder ein Event der Chronik, wird für jede/s neue kopiert)<br>
------[3x]Text (Ressortname, Ideologie und Beschreibung der Maßnahme/des Events)<br>
--[3x]PausenmenüButton (Buttons für das Pausenmenü: Fortsetzen, Neustart, Verlassen)<br>
-"Attribute Hintergrund" (dunkelgrauer Hintergrund der Attribute-Anzeige)<br>
-"Attributswerte" (beinhaltet die zehn Attribute und ihre Werte)<br>
--[10x] Attribut (die Attribute wie Finanzen oder Innere Sicherheit)<br>
---[5x]Image (Hintergrund, blauer Balken, Balken für Veränderungen, Icon und 'Hitbox' als Referenz für Hovern)<br>
---Text (Name des Attributs, der beim Hovern angezeigt wird)<br>
-"Textlauf" (beinhaltet die Elemente für den Textlauf am unteren Rand des Bildschirms)<br>
--"Image" (Hintergrund des Textlaufs)<br>
--[Anzahl dynamisch]"TextlaufText" (Text, der das Ereignis anzeigt. Kopiert sich für durchgängigen Textlauf)<br>
--"Hitbox" (Referenz für Hovern über den Textlauf)<br>
-"Events" (beinhaltet die normalen Ereignisse)<br>
--[10x]Ereignis (beinhaltet Beschreibung und Werte des Ereignis, wird nach Auslösung in Maßnahmen-Container verschoben)<br>
-"SpecialEvents" (beinhaltet die normalen Ereignisse)<br>
--[10x]Spezialereignis (beinhaltet Beschreibung und Werte des Spezialereignis, wird nach Auslösung in Maßnahmen-Container verschoben)<br>
-"MenuUI" (beinhaltet die Buttons für das Menü oben links)<br>
--"MassnahmenHistory" (Button für die Chronik)<br>
---"Image" (Bild auf Button)<br>
---"MassnahmenContainer" (Maßnahmen-Container, in den nach und nach die ausgelösten Ereignisse und gewählten Maßnahmen verschoben werden)<br>
--[2x]MenuButton (Buttons für Pause und Tutorial)<br>
---"Image" (Bild auf Button)<br>
---"Hitbox" (Hitbox als Referenz für Hovern)<br>
-"Tutorial" (beinhaltet alle Objekte für das Tutorial)<br>
--[6x]TutorialAbschnitt (beinhaltet die UI-Elemente für jeden Abschnitt des Tutorials)<br>
---"TutorialHintergrund" (dunkelgrauer Hintergrund des Tutorial-Fensters)<br>
---"Ueberschrift" (Überschrift des Tutorial-Abschnitts)<br>
---"Inhalt" (Text, der im Tutorial-Abschnitt angezeigt wird)<br>
---[1-2x]Button (Button zur Bestätigung des Tutorial-Abschnitts)<br>
-[2x]Konfetti (Partikel-System für das Konfetti im Endscreen)<br>

<h2>Screenshots</h2>
Ressortwahl:<br>
<img src="./Screenshots/ideocracy screenshot 1.PNG"><br>
Maßnahmenwahl:<br>
<img src="./Screenshots/ideocracy screenshot 2.PNG"><br>
Maßnahmenwahl (mit Ereignis):<br>
<img src="./Screenshots/ideocracy screenshot 3.PNG"><br>
Pausenmenü:<br>
<img src="./Screenshots/ideocracy screenshot 4.PNG"><br>
Chronik:<br>
<img src="./Screenshots/ideocracy screenshot 5.PNG"><br>
Tutorial:<br>
<img src="./Screenshots/ideocracy screenshot 6.PNG"><br>
Endscreen Punkteübersicht:<br>
<img src="./Screenshots/ideocracy screenshot 7.PNG"><br>
Endscreen Chronik:<br>
<img src="./Screenshots/ideocracy screenshot 8.PNG"><br>
Endscreen grafische Zusammenfassung:<br>
<img src="./Screenshots/ideocracy screenshot 9.PNG"><br>

<h2>Einzelnachweise Icons/Sounds</h2>
<b>Icons:</b><br>
https://fonts.gstatic.com/s/i/materialicons/accessible/v4/white-48dp.zip<br>
https://fonts.gstatic.com/s/i/materialicons/child_friendly/v4/white-48dp.zip<br>
https://fonts.gstatic.com/s/i/materialicons/eco/v4/white-48dp.zip<br>
https://fonts.gstatic.com/s/i/materialicons/euro_symbol/v4/white-48dp.zip<br>
https://fonts.gstatic.com/s/i/materialicons/help/v4/white-48dp.zip<br>
https://fonts.gstatic.com/s/i/materialicons/history/v4/white-48dp.zip<br>
https://fonts.gstatic.com/s/i/materialicons/insert_chart/v4/white-48dp.zip<br>
https://fonts.gstatic.com/s/i/materialicons/lock/v4/white-48dp.zip<br>
https://fonts.gstatic.com/s/i/materialicons/network_check/v4/white-48dp.zip<br>
https://fonts.gstatic.com/s/i/materialicons/pause_circle_filled/v5/white-48dp.zip<br>
https://fonts.gstatic.com/s/i/materialicons/policy/v4/white-48dp.zip<br>
https://fonts.gstatic.com/s/i/materialicons/school/v4/white-48dp.zip<br>
https://fonts.gstatic.com/s/i/materialicons/show_chart/v4/white-48dp.zip<br>
https://fonts.gstatic.com/s/i/materialicons/stars/v4/white-48dp.zip<br>
https://fonts.gstatic.com/s/i/materialicons/work/v4/white-48dp.zip<br><br>
<b>Sounds:</b><br>
https://freesound.org/people/broumbroum/sounds/50561/<br>
https://freesound.org/people/bigjoedrummer/sounds/77305/<br>
https://freesound.org/people/deleted_user_3544904/sounds/212682/<br>
https://freesound.org/people/deadsillyrabbit/sounds/251390/<br>
https://freesound.org/people/morrisjm/sounds/268756/ (bearbeitet)<br>
https://freesound.org/people/DesignDean/sounds/397317/ (bearbeitet)<br>
https://freesound.org/people/LorenzoTheGreat/sounds/417794/<br>
