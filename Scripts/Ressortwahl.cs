using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Verwaltet die Ressortwahl, Skript befindet sich auf jedem der 6 Buttons der Ressortwahl

public class Ressortwahl : MonoBehaviour
{
    Button RessortButton;
    public int MaxAnzahl;
    int CurrentAnzahl = 0;
    public GameObject Massnahmenwahl;
    
    void Start()
    {
        RessortButton = GetComponent<Button>();
        RessortButton.onClick.AddListener(RessortButtonOnClick);

        foreach (Transform child in transform.Find("RessortRunden").transform)
        {
            child.GetComponent<Image>().enabled = false;
        }
    }
    
    //OnClick Event der Buttons der Ressortwahl
    void RessortButtonOnClick()
    {
        //überprüft, ob noch Maßnahmen in dem jeweiligen Ressort verabschiedet werden können
        if (CurrentAnzahl < MaxAnzahl)
        {
            //deaktiviert die Ressortwahl und aktiviert die Maßnahmenwahl, schließt ggf das aktuelle Infofenster des Tutorials
            UIVerwaltung.RessortwahlOff();
            UIVerwaltung.MassnahmenwahlOn();
            GameObject.Find("Canvas").GetComponent<Tutorial>().SchließeTutorialFenster();

            //ggf wird der nächste Teil des Tutorials angezeigt
            if (GameObject.Find("Canvas").GetComponent<Tutorial>().tutorialPhase == Tutorial.TutorialPhase.Massnahmenwahl)
            {
                GameObject.Find("Canvas").GetComponent<Tutorial>().ZeigeTutorialText("Phase2", GameObject.Find("Ok2").GetComponent<Button>(), false);
                GameObject.Find("Canvas").GetComponent<Tutorial>().ZeigeTutorialText("Phase3", GameObject.Find("Ok3").GetComponent<Button>(), true);
                GameObject.Find("Canvas").GetComponent<Tutorial>().tutorialPhase = Tutorial.TutorialPhase.Massnahmenwahl;
            }

            //wählt zufällig eine Maßnahme für jede Ideologie aus dem Ressort aus
            foreach (Transform child in transform.Find("Massnahmen").transform)     //für jede Ideologie
            {
                int Massnahmennr = Random.Range(0, child.childCount);
                Massnahmenwahl.transform.Find(child.name).transform.Find("Text").GetComponent<Text>().text = child.GetChild(Massnahmennr).GetComponent<Massnahme>().Beschreibung;

                //löscht die vorherige Maßnahme aus der Maßnahmenwahl
                if (Massnahmenwahl.transform.Find(child.name).transform.childCount > 1)
                    for (int i = 1; i < Massnahmenwahl.transform.Find(child.name).transform.childCount; i++)
                        Destroy(Massnahmenwahl.transform.Find(child.name).transform.GetChild(i).gameObject);

                //verschiebt die neue Maßnahme zum zugehörigen Button der Maßnahmenwahl
                child.GetChild(Massnahmennr).transform.SetParent(Massnahmenwahl.transform.Find(child.name));
            }
            CurrentAnzahl++;

            //färbt ein zusätzliches Kästchen im Ressortbutton blau ein um zu signalisieren, wie viele Maßnahmen im Ressort bereits ausgewählt wurden
            transform.Find("RessortRunden").transform.GetChild(CurrentAnzahl - 1).GetComponent<Image>().color = new Color(0.53f, 0.76f, 0.99f);

            //Verändert die Überschrift der Maßnahmenwahl zum aktuellen Ressort
            GameObject.Find("Ressortname").GetComponent<Text>().text = transform.Find("Text").GetComponent<Text>().text;

            //deaktiviert die blauen Kästchen des Buttons
            foreach (Transform child in transform.Find("RessortRunden").transform)
            {
                child.GetComponent<Image>().enabled = false;
            }
        }
        else GetComponent<AudioSource>().Play();

    }

    //verändert beim Hovern die Farbe des Buttons und blendet die blauen Kästchen ein
    public void OnMouseEnter()
    {
        UIVerwaltung.OnButtonHover(this.GetComponent<Image>());

        foreach (Transform child in transform.Find("RessortRunden").transform)
        {
            child.GetComponent<Image>().enabled = true;
        }
    }

    //verändert nach dem Hovern die Farbe des Buttons und blendet die blauen Kästchen aus
    public void OnMouseExit()
    {
        UIVerwaltung.OnButtonLeave(this.GetComponent<Image>());
        GetComponent<Doozy.Engine.UI.UIButton>().ExecutePointerExit();

        foreach (Transform child in transform.Find("RessortRunden").transform)
        {
            child.GetComponent<Image>().enabled = false;
        }
    }
}
