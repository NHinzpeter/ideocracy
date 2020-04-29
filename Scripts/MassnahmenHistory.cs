using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Doozy;

//Verwaltet die Chronik

public class MassnahmenHistory : MonoBehaviour
{
    public GameObject Content, Attributswerte;
    private Button HistoryButton;
    
    void Start()
    {
        HistoryButton = GetComponent<Button>();
        HistoryButton.onClick.AddListener(HistoryButtonOnClick);
    }
    
    //Methode, die beim Click auf den Chronik-Button oben links ausgeführt wird
    void HistoryButtonOnClick()
    {
        //überprüft, ob die Chronik bereits geöffnet ist. Falls ja, wird sie geschlossen, falls nein, geöffnet
        if (Content.transform.GetChild(0).GetComponent<Image>().enabled == false)
        {
            //überprüft, ob bereits Maßnahmen verabschiedet wurden und erstellt dann für jede Maßnahme und jedes Ereignis ein eigenes Element in der Chronik
            if (transform.childCount > 0)
            {
                int childNr = 0;
                foreach (Transform child in transform) //wird für jede Maßnahme und jedes Ereignis ausgeführt
                {
                    //ein neues Element wird erschaffen und mit den notwendigen Infos ausgestattet
                    if (childNr > Content.transform.childCount - 1) GameObject.Instantiate(Content.transform.GetChild(0), Content.transform);
                    Content.transform.GetChild(childNr).Find("Ressortname").GetComponent<Text>().text = child.GetComponent<Massnahme>().ressort;
                    Content.transform.GetChild(childNr).Find("Ideologie").GetComponent<Text>().text = child.GetComponent<Massnahme>().ideologie;
                    Content.transform.GetChild(childNr).Find("Beschreibung").GetComponent<Text>().text = child.GetComponent<Massnahme>().Beschreibung;

                    childNr++;
                }
            }

            //schließt, falls geöffnet das Pausenmenü oder das aktuelle Infofenster des Tutorials und öffnet dann die Chronik
            if (GameObject.Find("PauseFortsetzen").GetComponent<Image>().enabled == true)
            {
                UIVerwaltung.PausenMenuOff();
                transform.parent.Find("Image").GetComponent<Image>().color = new Color(0.16f, 0.6f, 0.97f, 1.0f);
            }
            StartCoroutine(UIVerwaltung.MassnahmenHistoryMenuOn());
            GameObject.Find("Canvas").GetComponent<Tutorial>().SchließeTutorialFenster();

        }
        else
        {
            //schließt die Chronik
            UIVerwaltung.MassnahmenHistoryMenuOff();

            //öffnet ggf das Tutorialfenster für die Ressortwahl
            if (GameObject.Find("Ressortwahl").transform.Find("Finanzen").GetComponent<Image>().enabled == true && GameObject.Find("Canvas").GetComponent<Tutorial>().tutorialPhase == Tutorial.TutorialPhase.Ressortwahl) GameObject.Find("Canvas").GetComponent<Tutorial>().ZeigeTutorialText("Phase2", GameObject.Find("Ok2").GetComponent<Button>(),true);
        }
    }

    //Methode, die beim Hovern des Chronik-Buttons oben links ausgeführt wird
    public void OnHistoryButtonEnter()
    {
        //die Farbe des Buttons wird geändert und die Animation abgespielt
        transform.parent.Find("Image").GetComponent<Image>().color = new Color(0.16f, 0.6f, 0.97f, 1.0f);
        transform.parent.Find("Image").GetComponent<Doozy.Engine.UI.UIButton>().ExecutePointerEnter();
    }

    //Methode, die nach dem Hovern des Chronik-Buttons oben links ausgeführt wird
    public void OnHistoryButtonLeave()
    {
        //die Farbe des Buttons wird in weiß oder schwarz geändert, je nachdem, ob der Hintergrund hell oder dunkel ist
        if (GameObject.Find("Curtain").GetComponent<Image>().enabled == false)
        {
            transform.parent.Find("Image").GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        }
        else
        {
            transform.parent.Find("Image").GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }

    //Methode, die beim Hovern der einzelnen Maßnahmen und Events in der Chronik ausgeführt wird
    public void MassnahmenHover(GameObject Massnahme)
    {
        //überprüft, ob bereits Maßnahmen abgeschlossen wurden
        if (transform.childCount > 0)
        {
            //ändert die Farbe des Hintergrunds
            Massnahme.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 0.4f);

            int i = 0;

            //zeigt die Veränderungen, die die Maßnahmen und Ereignisse verursacht haben, in der Attributsleiste oben rechts an
            foreach (Transform child in Attributswerte.transform)
            {
                if (transform.GetChild(Massnahme.transform.GetSiblingIndex()).GetComponent<Massnahme>().veranderungen[i] != 0)
                {
                    if (transform.GetChild(Massnahme.transform.GetSiblingIndex()).GetComponent<Massnahme>().veranderungen[i] > 0) child.transform.Find("AttChange").GetComponent<RawImage>().color = new Color(0.0f, 0.37f, 0.08f, 0.63f); else child.transform.Find("AttChange").GetComponent<RawImage>().color = new Color(0.51f, 0.13f, 0.28f, 1.0f);
                    child.transform.Find("AttChange").GetComponent<RectTransform>().localScale = new Vector3(child.transform.Find("AttChange").GetComponent<RectTransform>().localScale.x, transform.GetChild(Massnahme.transform.GetSiblingIndex()).GetComponent<Massnahme>().veranderungen[i], child.transform.Find("AttChange").GetComponent<RectTransform>().localScale.z);
                    child.transform.Find("AttChange").GetComponent<RectTransform>().localPosition = new Vector3(child.transform.Find("AttChange").GetComponent<RectTransform>().localPosition.x, child.transform.Find("AttWert").GetComponent<AttWert>().wert + (-transform.GetChild(Massnahme.transform.GetSiblingIndex()).GetComponent<Massnahme>().veranderungen[i] / 2) - 50, child.transform.Find("AttChange").GetComponent<RectTransform>().localPosition.z);
                    child.transform.Find("AttChange").GetComponent<RawImage>().enabled = true;
                }

                i++;
            }
        }
    }

    //Methode, die nach dem Hovern der einzelnen Maßnahmen und Events in der Chronik ausgeführt wird
    public void MassnahmenHoverExit(GameObject Massnahme)
    {
        //setzt die Farbe des Hintergrunds wieder zurück und blendet die Veränderungen in der Attributsleiste wieder aus
        if (transform.childCount > 0)
        {
            foreach (Transform child in Attributswerte.transform)
            {
                child.transform.Find("AttChange").GetComponent<RawImage>().enabled = false;
            }

            Massnahme.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 0.15f);
        }
    }

    
}
