# ideocracy <br>
<h2>Allgemeines</h2>
Das Spiel wurde in Unity 2019 entwickelt. Zur Implementation der Funktionen des Spiels wurden Klassen in C# programmiert. <br>
Die Programmstruktur wurde so flexibel wie möglich gehalten. Hierzu wurde ein weitreichende Objekthierarchie entwickelt, die vor allem die Ansprechbarkeit der Objekte durch Schleifen im Programmcode ermöglichen sollte. Des Weiteren wurden keine Inhalte (Maßnahmen, Events, usw) in den Code geschrieben, sondern in einzelne Objekte in Unity integriert. Entsprechend ließe sich das Programm leicht durch weitere Maßnahmen oder Ereignisse, gegebenenfalls sogar durch weitere Attribute, Ressorts oder Ideologien ergänzen.<br>
Das Spiel hat eine native Auflösung von 1920x1080px und die UI ist entsprechend darauf ausgerichtet. Davon abweichende Seitenverhältnisse oder höhere Auflösungen werden ebenfalls problemlos unterstützt, niedrigere Auflösungen können hingegen Probleme verusachen.
<h2>Features</h2>
Eine grundsätzliche Beschreibung des Spiels und seiner Grundfunktionen können der schriftlichen Ausarbeitung entnommen werden.<br>
Features, die über die Grundfunktionen des Programms hinausgehen:
<ul>
<li><b>Rückmeldungen der UI-Flächen</b>: Die Buttons und Attribute reagieren mir Animationen und Tönen auf Hovern und bieten so eine interaktive Nutzererfahrung. Gehoverte Maßnahmen und Ereignisse zeigen die dadurch bewirkten Veränderungen der Attribute an. In der Ressortwahl wird auch angezeigt, wie oft die Ressorts nach wählbar sind, sollten diese nicht mehr wählbar sein, wird ein Signalton abgespielt.</li>
<li><b>Chronik</b>: Eine Chronik zeigt die bereits geschehenen Ereignisse und verabschiedeten Maßnahmen an. Diese werden innerhalb des Programms in den Chronik-"Container" verschoben. Durch Hovern können auch hier die dadurch bewirkten Veränderungen sichtbar gemacht werden.</li>
<li><b>Pause</b>: Die Spielenden können das Spiel über einen Button pausieren</li>
<li><b>Tutorial</b>: Ein ausführliches Tutorial erklärt alle Elemente des Spiels Stück für Stück beim ersten Mal spielen. Danach kann es erneut über den Hilfe-Button aufgerufen werden.</li>
<li><b>Endscreen</b>: Nach der letzten Runde wird ein Endscreen angezeigt, der die finalen Punkte und Attributswerte anzeigt. Darüber hinaus können die Spielenden hier die Chronik betrachten und sie Graphen zu den gewählten Maßnahmen anzeigen lassen. Für den "Konfetti"-Effekt wurde ein eigens entworfenes Partikelsystem eingebaut.</li>
</ul>
<h2>Design</h2>
Das visuelle Design des Videospiels orientiert sich am frei verfügbaren und kostenlos nutzbaren <a href="https://www.material.io">Material-Design</a> von Google. So wurden die Schriftart und alle verwendeten Icons für das Menü und die Attribute von dort importiert, auch die Farbgebung wurde nach der dort veröffentlichten Richtlinie gestaltet. Für die Implementation der Animationen auf den UI-Elementen wurde das Unity-Plugin <a href="https://assetstore.unity.com/packages/tools/gui/doozyui-complete-ui-management-system-138361">DoozyUI</a> verwendet. Das Logo wurde selbst entworfen.<br>
Das auditive Design wurde vollständig selbst erarbeitet, die benötigten Sounds wurden aus der kostenlosen Datenbank <a href="https://www.freesound.org">freesound.org</a> geladen und sind aufgrund der Creative Commons License frei verwendbar. Die Sounds wurden ggf angepasst.<br>
Der Name <i>ideocracy</i> (stilisiert in Kleinschreibung) ist ein Kofferwort aus dem englischen ‚Ideology‘ und dem griechischen ‚Kratos‘ (‚Macht‘, wie in ‚Democracy‘) und soll eine ideologisch orientierte Führungsweise zum Ausdruck bringen.<br>

Einzelnachweise Icons/Sounds?
