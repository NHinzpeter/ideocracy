using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Skript befindet sich auf jedem Maßnahmen-Objekt. Dort können in Unity einfach die Werte der Maßnahme eingetragen werden.

public class Massnahme : MonoBehaviour
{
    [TextArea(3, 10)] public string Beschreibung;
    public int[] veranderungen;
    public int finanzen, innereSicherheit, wirtschaft, arbeit, soziales, familie, digitaleInfrastruktur, umwelt, bildung, privatsphaere;
    public string ressort, ideologie;
    
    void Start()
    {
        //schreibt die in Unity eingetragenen Werte in ein Array (leichter in Schleifen zu verarbeiten)
        veranderungen = new int[10];
        veranderungen[0] = finanzen;
        veranderungen[1] = innereSicherheit;
        veranderungen[2] = wirtschaft;
        veranderungen[3] = arbeit;
        veranderungen[4] = soziales;
        veranderungen[5] = familie;
        veranderungen[6] = digitaleInfrastruktur;
        veranderungen[7] = umwelt;
        veranderungen[8] = bildung;
        veranderungen[9] = privatsphaere;

        //schreibt Ideologie und Ressort automatisch in das Objekt, Ereignisse haben als Ideologie "Ereignis" oder "Spezialereignis" und kein Ressort
        ideologie = transform.parent.name;
        if (ideologie == "Events")
        {
            ressort = "Ereignis";
            ideologie = "";
        }
        else if (ideologie == "SpecialEvents")
        {
            ressort = "Spezialereignis";
            ideologie = "";
        }
        else
        {
            ressort = transform.parent.parent.parent.name;
        }
    }
    
}
