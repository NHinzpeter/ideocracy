using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

//Zentrales Skript, das grundsätzliche Elemente des Spiels sowie die Events und Teile des Tutorials steuert

public class GameController : MonoBehaviour
{
    public GameObject Attributswerte, Events, SpecialEvents, TextlaufObject;
    public int MaxRunden, CurrentRunden, GesamtPunkte;
    int[] EventVeraenderungen = new int[10];
    private bool CoroutineRunning;
    public int EventsOnStack = 0;
    private bool[] SpecialEventTriggered;
    public bool TextlaufStop = false;
    
    void Start()
    {
        CurrentRunden = 0;
        CoroutineRunning = false;
        SpecialEventTriggered = new bool[10];
        
        //initiiert die Rundenanzeige unten rechts
        GameObject.Find("Rundenanzeige").GetComponent<Text>().text = (CurrentRunden + 1 + "/" + MaxRunden);

        //Setzt zu Beginn des Spiels zufällig alle Attribute auf einen Wert von 30
        foreach (Transform child in Attributswerte.transform)
            child.Find("AttWert").GetComponent<AttWert>().wert = 30;

        int Punkte = 200;

        //erhöht nun die Attributswerte zufällig in Schritten von 10 Punkten bis zu einem maximalen Wert von 70, so, dass das arithmetische Mittel aller Attributswerte immer 50 ergibt
        while (Punkte > 0)
        {
            int childNum = Random.Range(0, Attributswerte.transform.childCount);
            if (Attributswerte.transform.GetChild(childNum).Find("AttWert").GetComponent<AttWert>().wert < 70)
            {
                Attributswerte.transform.GetChild(childNum).Find("AttWert").GetComponent<AttWert>().wert += 10;
                Punkte -= 10;
            }
        }
        //alle Attributswerte befinden sich nun zwischen 30 und 70
               
        //Startet beim ersten Start des Spiels das Tutorial und erstellt eine Datei auf dem PC der Spielenden, sodass das Tutorial tatsächlich nur beim ersten Start angezeigt wird
        if (!File.Exists(Application.persistentDataPath + "/tutorial.sav"))
        {
            GetComponent<Tutorial>().StarteTutorial();
            
            StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/tutorial.sav", true);
            writer.WriteLine("Tutorial played");
            writer.Close();
        }
    }

    //Update wird jeden Frame ausgeführt
    void Update()
    {
        //Startet das nächste Event, falls das vorherige Event bereits abgehandelt ist, ein Event auf dem Stapel liegt und das Textlauf-Objekt noch nicht sichtbar im Bildschirmbereich ist
        if (CoroutineRunning == false && EventsOnStack > 0 && TextlaufObject.transform.localPosition.x > (GameObject.Find("Canvas").GetComponent<RectTransform>().rect.size.x / 2 + TextlaufObject.GetComponent<RectTransform>().rect.size.x / 2))
        {
            StartCoroutine(eventImpact());
        }

        //Pausiert das Spiel, wenn die Escape-Taste gedrückt wird
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject.Find("PausenMenu").transform.Find("Hitbox").GetComponent<PausenMenu>().PausenButtonOnClick();
            if (GameObject.Find("Curtain").GetComponent<Image>().enabled == true)
                GameObject.Find("PausenMenu").transform.Find("Image").GetComponent<Image>().color = new Color(1, 1, 1);
            else GameObject.Find("PausenMenu").transform.Find("Image").GetComponent<Image>().color = new Color(0, 0, 0);
        }
    }

    //Überprüft vor jeder Runde, ob ein neues Ereignis eingeleitet wird oder ob das Spiel vorbei ist
    public void naechsteRunde()
    {
        CurrentRunden++;

        //Falls die maximale Anzahl an Runden gespielt wurde, wird der Endscreen angezeigt
        if (MaxRunden == CurrentRunden)
        {
            //Zeigt den Endscreen an, sofern sich kein Ereignis mehr auf dem Stapel befindet. Falls doch, wird der Wartebildschirm angezeigt.
            if (EventsOnStack == 0)
            {
                UIVerwaltung.Endscreen();
                GetComponent<Tutorial>().SchließeTutorialFenster();
                StartCoroutine(GameObject.Find("Endscreen").GetComponent<Endscreen>().ZeigeEndpunkte());
                GameObject.Find("Endscreen").GetComponent<Endscreen>().BerechneStats();
                TextlaufStop = true;
            }
            else UIVerwaltung.EndscreenWait();
            
        }

        else
        {
            //ggf wird ein neues Ereignis auf den Stapel gelegt
            if (Random.Range(0, 3) == 2)
            {
                EventsOnStack++;
            }

            //aktualisiert die Rundenanzeige und öffnet die Ressortwahl
            GameObject.Find("Rundenanzeige").GetComponent<Text>().text = (CurrentRunden + 1 + "/" + MaxRunden);
            UIVerwaltung.RessortwahlOn();
        }
    }

    //handelt die Ereignisse ab
    IEnumerator eventImpact()
    {
        GameObject Event=null;              
        CoroutineRunning = true;
        
        //überprüft, ob ein negatives Spezialereignis ausgelöst wird
        for (int i=0; i<5; i++)
        {
            //Wenn die Bedingung für ein Spezialevent erfüllt ist, wird dieses ausgewählt und geklont. Der Klon dient als Platzhalter, da das ausgelöste Ereignis später in die Chronik verschoben wird.
            if (Attributswerte.transform.GetChild(i).transform.Find("AttWert").GetComponent<AttWert>().wert <= 20 && SpecialEventTriggered[i]==false)
            {
                Event = SpecialEvents.transform.GetChild(i).gameObject;
                GameObject Clone = GameObject.Instantiate(Event, Event.transform.parent);
                Clone.transform.SetSiblingIndex(i);
                SpecialEventTriggered[i] = true;
                break;
            }
        }

        //sofern kein negatives Spezialevent ausgewählt wurde, wird überprüft, ob eine Bedingung für ein positives Spezialereignis erfüllt ist
        if (Event == null)
        {
            for (int i = 0; i < 5; i++)
            {
                //Wenn die Bedingung für ein Spezialevent erfüllt ist, wird dieses ausgewählt und geklont. Der Klon dient als Platzhalter, da das ausgelöste Ereignis später in die Chronik verschoben wird.
                if (Attributswerte.transform.GetChild(i).transform.Find("AttWert").GetComponent<AttWert>().wert >= 90 && SpecialEventTriggered[i+5] == false)
                {
                    Event = SpecialEvents.transform.GetChild(i+5).gameObject;
                    GameObject Clone = GameObject.Instantiate(Event, Event.transform.parent);
                    Clone.transform.SetSiblingIndex(i+5);
                    SpecialEventTriggered[i+5] = true;
                    break;
                }
            }
        }

        //Sofern auch kein positives Spezialevent ausgewählt wurde, wird ein normales Ereignis ausgelöst
        if (Event == null)
        { 
            //überprüft, ob noch Ereignisse verfügbar sind (maximal sind nur 10 normale Ereignisse pro Spiel möglich)
            if (Events.transform.childCount == 0)
            {
                EventsOnStack = 0;
                yield break;
            }
            
            //ein zufälliges Ereignis wird ausgelöst
            Event = Events.transform.GetChild(Random.Range(0, Events.transform.childCount)).gameObject;
        }

        //Der Textlauf wird gestartet und fängt an zu blinken
        StartCoroutine(TextlaufObject.GetComponent<Textlauf>().StarteTextLauf(Event.GetComponent<Massnahme>().Beschreibung));
        StartCoroutine(TextlaufObject.GetComponent<Textlauf>().Blinken());

        //Die Werte des Ereignisses werden übertragen
        for (int i = 0; i < 10; i++)
            EventVeraenderungen[i] = Event.GetComponent<Massnahme>().veranderungen[i];
        
        //Das Ereignis wird in die Chronik verschoben
        Event.transform.SetParent(GameObject.Find("MassnahmenContainer").transform);

        //ggf wird der Tutorial-Abschnitt zu den Ereignissen angezeigt
        if (GetComponent<Tutorial>().tutorialPhase == Tutorial.TutorialPhase.Events)
            GetComponent<Tutorial>().ZeigeTutorialText("Phase4", GameObject.Find("Ok4").GetComponent<Button>(), true);

        yield return new WaitForSeconds(1);

        //nach einer Sekunde werden die Veränderungen des Ereignisses in der Attributsleiste angezeigt
        zeigeEventVeraenderungen();

        yield return new WaitForSeconds(2.5f);

        //nach weiteren zweieinhalb Sekunden werden die Veränderungen des Events dann tatsächlich ausgeführt
        int j = 0;
        foreach (Transform child in Attributswerte.transform)
        {
            child.transform.Find("AttChange").GetComponent<RawImage>().enabled = false;
            child.transform.Find("AttWert").GetComponent<AttWert>().wert += EventVeraenderungen[j];
            j++;
        }
        
        CoroutineRunning = false;
        EventsOnStack--;
        
        //Sollten sich keine Ereignisse mehr auf dem Stapel befinden und das Spiel bereits zu Ende sein, wird der Endscreen angezeigt
        if (EventsOnStack == 0 && CurrentRunden == MaxRunden)
        {
            UIVerwaltung.Endscreen();
            GetComponent<Tutorial>().SchließeTutorialFenster();
            StartCoroutine(GameObject.Find("Endscreen").GetComponent<Endscreen>().ZeigeEndpunkte());
            GameObject.Find("Endscreen").GetComponent<Endscreen>().BerechneStats();
            TextlaufStop = true;

        }

        yield break;
    }

    //zeigt die Veränderungen durch die Ereignisse an
    public void zeigeEventVeraenderungen(){

        int i = 0;
        foreach (Transform child in Attributswerte.transform)   //für jedes Attribut
        {
            if (EventVeraenderungen[i] != 0)
            {
                //setzt die Farbe der Veränderung rot oder grün
                if (EventVeraenderungen[i] > 0)
                    child.transform.Find("AttChange").GetComponent<RawImage>().color = new Color(0.0f, 0.37f, 0.08f, 0.63f);
                else child.transform.Find("AttChange").GetComponent<RawImage>().color = new Color(0.51f, 0.13f, 0.28f, 1.0f);

                //setzt die Größe des Veränderungen-Balkens
                child.transform.Find("AttChange").GetComponent<RectTransform>().localScale = new Vector3(child.transform.Find("AttChange").GetComponent<RectTransform>().localScale.x, EventVeraenderungen[i], child.transform.Find("AttChange").GetComponent<RectTransform>().localScale.z);

                //positioniert den Balken entweder unterhalb oder oberhalb des aktuellen Wertes, je nachdem, ob die Änderungen bereits eingetreten sind oder nicht
                if (CoroutineRunning == true)
                {                    
                    child.transform.Find("AttChange").GetComponent<RectTransform>().localPosition = new Vector3(child.transform.Find("AttChange").GetComponent<RectTransform>().localPosition.x, child.transform.Find("AttWert").GetComponent<AttWert>().wert + (EventVeraenderungen[i] / 2) - 50, child.transform.Find("AttChange").GetComponent<RectTransform>().localPosition.z);                    
                }
                else
                {
                    child.transform.Find("AttChange").GetComponent<RectTransform>().localPosition = new Vector3(child.transform.Find("AttChange").GetComponent<RectTransform>().localPosition.x, child.transform.Find("AttWert").GetComponent<AttWert>().wert + (-EventVeraenderungen[i] / 2) - 50, child.transform.Find("AttChange").GetComponent<RectTransform>().localPosition.z);                    
                }

                child.transform.Find("AttChange").GetComponent<RawImage>().enabled = true;
            }

            i++;
        }

    }

    
}
