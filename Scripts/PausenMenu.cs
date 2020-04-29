using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//verwaltet das Pausenmenü

public class PausenMenu : MonoBehaviour
{
    Button PausenButton;
    public Button Forsetzen, Neustart, Verlassen;
    public GameObject Textlauf;
    
    void Start()
    {
        PausenButton = GetComponent<Button>();
        PausenButton.onClick.AddListener(PausenButtonOnClick);
        Forsetzen.onClick.AddListener(ForsetzenButtonOnClick);
        Neustart.onClick.AddListener(NeustartButtonOnClick);
        Verlassen.onClick.AddListener(VerlassenButtonOnClick);
    }   
    

    public void PausenButtonOnClick()
    {
        //Je nachdem, ob das Pausenmenü derzeit geöffnet oder geschlossen ist, wird es entsprechend geschlossen oder geöffnet
        if (GameObject.Find("PauseFortsetzen").GetComponent<Image>().enabled == false)
        {
            //falls geöffnet, wird die Chronik und das aktuelle Infofenster des Tutorials geschlossen
            if (GameObject.Find("Scroll View").GetComponent<ScrollRect>().enabled == true)
            {
                UIVerwaltung.MassnahmenHistoryMenuOff();
                transform.parent.Find("Image").GetComponent<Image>().color = new Color(0.16f, 0.6f, 0.97f, 1.0f);

            }
            UIVerwaltung.PausenMenuOn();
            GameObject.Find("Canvas").GetComponent<Tutorial>().SchließeTutorialFenster();
        }
        else
        {
            UIVerwaltung.PausenMenuOff();

            //nach dem Schließen des Pausenmenüs wird ggf das Tutorial fortgesetzt
            if (GameObject.Find("Ressortwahl").transform.Find("Finanzen").GetComponent<Image>().enabled == true && GameObject.Find("Canvas").GetComponent<Tutorial>().tutorialPhase == Tutorial.TutorialPhase.Ressortwahl)
                GameObject.Find("Canvas").GetComponent<Tutorial>().ZeigeTutorialText("Phase2", GameObject.Find("Ok2").GetComponent<Button>(), true);              
        }
    }

    private void VerlassenButtonOnClick()
    {
        //beendet das Spiel
        Application.Quit();
    }

    private void NeustartButtonOnClick()
    {
        //Startet das Spiel neu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ForsetzenButtonOnClick()
    {
        PausenButtonOnClick();

        //Der Pausenbutton oben links wird wieder schwarz eingefärbt
        transform.parent.Find("Image").GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
    }

    public void PausenButtonHover()
    {
        //beim Hovern des Buttons oben links wird dieser blau eingefärbt und die Animation wird abgespielt
        transform.parent.Find("Image").GetComponent<Image>().color = new Color(0.16f, 0.6f, 0.97f, 1.0f);
        transform.parent.Find("Image").GetComponent<Doozy.Engine.UI.UIButton>().ExecutePointerEnter();
    }

    public void PausenButtonExit()
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

    public void PausenMenuButtonHover(Image Button)
    {
        //die eckigen Buttons im Pausenmenü werden beim Hovern blau eingefärbt
        UIVerwaltung.OnButtonHover(Button);
    }

    public void PausenMenuButtonExit(Image Button)
    {
        //die eckigen Buttons im Pausenmenü werden nach dem Hovern wieder grau eingefärbt
        Button.color = new Color(0.91f, 0.91f, 0.91f, 1.0f);
        Button.GetComponent<Doozy.Engine.UI.UIButton>().ExecutePointerExit();
    }
}
