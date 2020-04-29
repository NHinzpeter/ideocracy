using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Verwaltet das Tutorial

public class Tutorial : MonoBehaviour
{
    public enum TutorialPhase {Attributswerte, Ressortwahl, Massnahmenwahl, Events, History, Completed}
    public TutorialPhase tutorialPhase;
    public Button Ja, Nein, Ok, Ok2, Ok3, Ok4, Ok5;
    
    void Start()
    {
        tutorialPhase = TutorialPhase.Completed;
        Nein.onClick.AddListener(NeinOnClick);
        Ja.onClick.AddListener(JaOnClick);
        Ok.onClick.AddListener(OkOnClick);
        Ok2.onClick.AddListener(Ok2OnClick);
        Ok3.onClick.AddListener(Ok3OnClick);
        Ok4.onClick.AddListener(Ok4OnClick);
        Ok5.onClick.AddListener(Ok5OnClick);
        
    }
    
    //schließt das aktuelle Tutorialfenster
    public void SchließeTutorialFenster()
    {
        switch (tutorialPhase)
        {

            case TutorialPhase.Completed:
                if (Ja.enabled == true) NeinOnClick();
                break;
            case TutorialPhase.Attributswerte:
                if (Ok.enabled == true) OkOnClick();
                break;
            case TutorialPhase.Ressortwahl:
                if (Ok2.enabled == true) Ok2OnClick();
                break;
            case TutorialPhase.Massnahmenwahl:
                if (Ok3.enabled == true) Ok3OnClick();
                break;
            case TutorialPhase.Events:
                if (Ok4.enabled == true) Ok4OnClick();
                break;
            case TutorialPhase.History:
                if (Ok5.enabled == true) Ok5OnClick();
                break;

        }
    }

    //startet das Tutorial, zeigt die benötigten UI-Elemente an
    public void StarteTutorial()
    {
        tutorialPhase = TutorialPhase.Completed;
        GameObject.Find("TutorialHintergrund").GetComponent<Image>().enabled = true;
        Ja.GetComponent<Image>().enabled = true;
        Ja.enabled = true;
        Ja.transform.Find("Text").GetComponent<Text>().enabled = true;
        Nein.GetComponent<Image>().enabled = true;
        Nein.enabled = true;
        Nein.transform.Find("Text").GetComponent<Text>().enabled = true;
        GameObject.Find("TutorialStart").transform.Find("Ueberschrift").GetComponent<Text>().enabled = true;
        GameObject.Find("TutorialStart").transform.Find("Inhalt").GetComponent<Text>().enabled = true;
    }

    //blendet die UI-Elemente des Tutorial-Starts wieder aus
    void TutorialStartOff()
    {

        GameObject.Find("TutorialHintergrund").GetComponent<Image>().enabled = false;
        Ja.GetComponent<Image>().enabled = false;
        Ja.enabled = false;
        Ja.transform.Find("Text").GetComponent<Text>().enabled = false;
        Nein.GetComponent<Image>().enabled = false;
        Nein.enabled = false;
        Nein.transform.Find("Text").GetComponent<Text>().enabled = false;
        GameObject.Find("TutorialStart").transform.Find("Ueberschrift").GetComponent<Text>().enabled = false;
        GameObject.Find("TutorialStart").transform.Find("Inhalt").GetComponent<Text>().enabled = false;
    }

    //blendet die UI-Elemente des Infofelds für den jeweiligen Tutorialabschnitt ein oder aus
    public void ZeigeTutorialText(string Phase, Button Ok, bool OnOff)
    {
        GameObject.Find(Phase).transform.Find("TutorialHintergrund1").GetComponent<Image>().enabled = OnOff;
        GameObject.Find(Phase).transform.Find("Ueberschrift").GetComponent<Text>().enabled = OnOff;
        GameObject.Find(Phase).transform.Find("Inhalt").GetComponent<Text>().enabled = OnOff;
        Ok.GetComponent<Image>().enabled = OnOff;
        Ok.enabled = OnOff;
        Ok.transform.Find("Text").GetComponent<Text>().enabled = OnOff;
    }  
       
    //OnClick-Events für die Buttons im Tutorial
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void JaOnClick()
    {
        tutorialPhase = TutorialPhase.Attributswerte;
        TutorialStartOff();
        ZeigeTutorialText("Phase1", Ok, true);
    }

    void NeinOnClick()
    {
        tutorialPhase = TutorialPhase.Completed;
        TutorialStartOff();

    }

    void OkOnClick()
    {
        tutorialPhase = TutorialPhase.Ressortwahl;
        ZeigeTutorialText("Phase1", Ok, false);
        if (GameObject.Find("Ressortwahl").transform.Find("Finanzen").GetComponent<Image>().enabled == true && GameObject.Find("Curtain").GetComponent<Image>().enabled == false)
        {
            ZeigeTutorialText("Phase2", Ok2, true);
        }

    }

    void Ok2OnClick()
    {
        tutorialPhase = TutorialPhase.Massnahmenwahl;
        ZeigeTutorialText("Phase2", Ok2, false);

    }

    void Ok3OnClick()
    {
        tutorialPhase = TutorialPhase.Events;
        ZeigeTutorialText("Phase3", Ok3, false);

    }

    void Ok4OnClick()
    {
        tutorialPhase = TutorialPhase.History;
        ZeigeTutorialText("Phase4", Ok4, false);

    }

    void Ok5OnClick()
    {
        tutorialPhase = TutorialPhase.Completed;
        ZeigeTutorialText("Phase5", Ok5, false);

    }
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
}
