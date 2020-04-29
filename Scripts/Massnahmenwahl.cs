using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Skript, das sich auf jedem der drei Buttons in der Maßnahmenwahl befindet

public class Massnahmenwahl : MonoBehaviour
{
    Button MassnahmenButton;
    public GameObject Attributswerte;

    void Start()
    {
        MassnahmenButton = GetComponent<Button>();
        MassnahmenButton.onClick.AddListener(MassnahmenButtonOnClick);
    }

    //OnClick-Event, wenn eine Maßnahme ausgewählt wurde
    void MassnahmenButtonOnClick()
    {
        int i = 0;

        //Die Veränderungen der Maßnahme (welche bei der Ressortwahl als Kind festgelegt wurde) werden auf die Attribute angewandt
        foreach (Transform child in Attributswerte.transform)
        {
            child.transform.Find("AttWert").GetComponent<AttWert>().wert += transform.GetChild(1).GetComponent<Massnahme>().veranderungen[i];
            i++;
        }

        //die Maßnahme wird nun in die Chronik verschoben
        transform.GetChild(1).SetParent(GameObject.Find("MassnahmenContainer").transform);

        //die Maßnahmenwahl und ggf das aktuelle Tutorialfenster werden geschlossen
        UIVerwaltung.MassnahmenwahlOff();
        GameObject.Find("Canvas").GetComponent<Tutorial>().SchließeTutorialFenster();

        //ggf wird das nächste Tutorialfenster angezeigt
        if (GameObject.Find("Canvas").GetComponent<Tutorial>().tutorialPhase == Tutorial.TutorialPhase.Massnahmenwahl)
        {
            GameObject.Find("Canvas").GetComponent<Tutorial>().tutorialPhase = Tutorial.TutorialPhase.Events;
            GameObject.Find("Canvas").GetComponent<Tutorial>().ZeigeTutorialText("Phase3", GameObject.Find("Ok3").GetComponent<Button>(), false);
        }
        else if (GameObject.Find("Canvas").GetComponent<Tutorial>().tutorialPhase == Tutorial.TutorialPhase.History)
        {
            GameObject.Find("Canvas").GetComponent<Tutorial>().ZeigeTutorialText("Phase5", GameObject.Find("Ok5").GetComponent<Button>(), true);
        }
        else if (GameObject.Find("Canvas").GetComponent<Tutorial>().tutorialPhase == Tutorial.TutorialPhase.Ressortwahl)
        {
            GameObject.Find("Canvas").GetComponent<Tutorial>().ZeigeTutorialText("Phase2", GameObject.Find("Ok2").GetComponent<Button>(), true);
        }

        //die nächste Runde wird eingeleitet
        GameObject.Find("Canvas").GetComponent<GameController>().naechsteRunde();
    }

    //beim Hovern über eine Maßnahme verändert sich die Farbe des Buttons und des Textes und die Veränderungen, die die Maßnahme bewirken würde, werden angezeigt
    public void MassnahmenButtonHover()
    {
        int i = 0;

        //zeigt die Veränderungen, die die Maßnahme bewirken würde, an
        foreach (Transform child in Attributswerte.transform)
        {
            if (transform.GetChild(1).GetComponent<Massnahme>().veranderungen[i] != 0)
            {
                if (transform.GetChild(1).GetComponent<Massnahme>().veranderungen[i]>0) child.transform.Find("AttChange").GetComponent<RawImage>().color = new Color(0.0f, 0.37f, 0.08f, 0.63f); else child.transform.Find("AttChange").GetComponent<RawImage>().color = new Color(0.82f, 0.0f, 0.0f, 0.63f);
                child.transform.Find("AttChange").GetComponent<RectTransform>().localScale = new Vector3(child.transform.Find("AttChange").GetComponent<RectTransform>().localScale.x, transform.GetChild(1).GetComponent<Massnahme>().veranderungen[i], child.transform.Find("AttChange").GetComponent<RectTransform>().localScale.z);
                child.transform.Find("AttChange").GetComponent<RectTransform>().localPosition = new Vector3(child.transform.Find("AttChange").GetComponent<RectTransform>().localPosition.x, child.transform.Find("AttWert").GetComponent<AttWert>().wert + (transform.GetChild(1).GetComponent<Massnahme>().veranderungen[i] / 2) - 50, child.transform.Find("AttChange").GetComponent<RectTransform>().localPosition.z);
                child.transform.Find("AttChange").GetComponent<RawImage>().enabled = true;
            }

            i++;
        }

        //verändert die Farbe des Buttons und des Textes
        transform.Find("Text").GetComponent<Text>().color = new Color(0.08f, 0.08f, 0.08f, 1.0f);
        UIVerwaltung.OnButtonHover(this.GetComponent<Image>());
    }

    //nach dem Hovern über eine Maßnahme wird  die Farbe des Buttons und des Textes zurück geändert und die Veränderungen ausgeblendet
    public void MassnahmenButtonLeave()
    {
        //blendet die Veränderungen aus
        foreach (Transform child in Attributswerte.transform)
        {
            child.transform.Find("AttChange").GetComponent<RawImage>().enabled = false;
        }

        //ändert die Farben zurück
        transform.Find("Text").GetComponent<Text>().color = new Color(0.2f, 0.2f, 0.2f, 1.0f);
        UIVerwaltung.OnButtonLeave(this.GetComponent<Image>());
        GetComponent<Doozy.Engine.UI.UIButton>().ExecutePointerExit();
    }
}
