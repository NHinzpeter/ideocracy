using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Verwaltet den Hilfe-Button oben links

public class Hilfe : MonoBehaviour
{
    Button HilfeButton;

    void Start()
    {
        HilfeButton = GetComponent<Button>();
        HilfeButton.onClick.AddListener(HilfeButtonOnClick);
    }
    
    void HilfeButtonOnClick()
    {
        //Schließt die Chronik oder das Pausenmenü (sofern geöffnet), schließt das aktuelle Infofenster des Tutorials (falls aktiv) und startet das Tutorial
        UIVerwaltung.MassnahmenHistoryMenuOff();
        UIVerwaltung.PausenMenuOff();
        GameObject.Find("Canvas").GetComponent<Tutorial>().SchließeTutorialFenster();
        GameObject.Find("Canvas").GetComponent<Tutorial>().StarteTutorial();

        //die andere Menü-Buttons werden weiß eingefärbt
        GameObject.Find("MassnahmenHistory").transform.Find("Image").GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        GameObject.Find("PausenMenu").transform.Find("Image").GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
    }

    public void HilfeButtonHover()
    {
        //beim Hovern über den Button wird dieser blau und führt die Animation aus
        transform.parent.Find("Image").GetComponent<Image>().color = new Color(0.16f, 0.6f, 0.97f, 1.0f);
        transform.parent.Find("Image").GetComponent<Doozy.Engine.UI.UIButton>().ExecutePointerEnter();
    }

    public void HilfeButtonExit()
    {
        //je nachdem, ob der Hintergrund ("Curtain") grau oder weiß ist, wird die Button-Farbe nach dem Hovern entsprechend weiß oder schwarz eingefärbt
        if (GameObject.Find("Curtain").GetComponent<Image>().enabled == false)
        {
            transform.parent.Find("Image").GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        }
        else
        {
            transform.parent.Find("Image").GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
