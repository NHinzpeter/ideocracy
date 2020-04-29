using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Skript, das zentral alle UI-Elemente aktiviert/deaktiviert oder ihre Farben ändert

public static class UIVerwaltung
{
    //deaktiviert alle Buttons der Ressortwahl
    public static void RessortwahlOff()
    {
        GameObject Ressortwahl = GameObject.Find("Ressortwahl");
        foreach (Transform child in Ressortwahl.transform)
        {
            child.GetComponent<Image>().enabled = false;
            child.GetComponent<Button>().enabled = false;
            child.transform.Find("Text").GetComponent<Text>().enabled = false;
        }
    }

    //aktiviert alle Buttons der Ressortwahl
    public static void RessortwahlOn()
    {
        GameObject Ressortwahl = GameObject.Find("Ressortwahl");
        foreach (Transform child in Ressortwahl.transform)
        {
            child.GetComponent<Image>().enabled = true;
            child.localScale = new Vector3(1, 1, 1);
            child.GetComponent<Button>().enabled = true;
            child.transform.Find("Text").GetComponent<Text>().enabled = true;
        }
    }

    //aktiviert alle Buttons der Maßnahmenwahl und die Überschriften
    public static void MassnahmenwahlOn()
    {
        GameObject Massnahmenwahl = GameObject.Find("Massnahmenwahl");
        GameObject Massnahmenwahl2 = GameObject.Find("Massnahmenwahl2");

        foreach (Transform child in Massnahmenwahl.transform)
        {
            child.GetComponent<Image>().enabled = true;
            child.localScale = new Vector3(1, 1, 1);
            child.GetComponent<Button>().enabled = true;
            child.transform.Find("Text").GetComponent<Text>().enabled = true;

        }

        foreach (Transform child in Massnahmenwahl2.transform)
        {
            child.GetComponent<Text>().enabled = true;
        }
    }

    //deaktiviert alle Buttons der Maßnahmenwahl und die Überschriften
    public static void MassnahmenwahlOff()
    {
        GameObject Massnahmenwahl = GameObject.Find("Massnahmenwahl");
        GameObject Massnahmenwahl2 = GameObject.Find("Massnahmenwahl2");

        foreach (Transform child in Massnahmenwahl.transform)
        {
            child.GetComponent<Image>().enabled = false;
            child.GetComponent<Button>().enabled = false;
            child.transform.Find("Text").GetComponent<Text>().enabled = false;

        }

        foreach (Transform child in Massnahmenwahl2.transform)
        {
            child.GetComponent<Text>().enabled = false;
        }

    }

    //öffnet den Endscreen als solchen und den Reiter der Punkteübersicht
    public static void Endscreen()
    {
        GameObject.Find("EndscreenText").GetComponent<Text>().enabled = true;
        GameObject.Find("EndscreenText").GetComponent<Text>().text = "Spielende";
        GameObject.Find("Neustart").GetComponent<Button>().enabled = true;
        GameObject.Find("Neustart").GetComponent<Image>().enabled = true;
        GameObject.Find("Punkte").GetComponent<Image>().enabled = true;
        GameObject.Find("PunkteImage").GetComponent<Image>().enabled = true;
        GameObject.Find("Chronik").GetComponent<Image>().enabled = true;
        GameObject.Find("ChronikImage").GetComponent<Image>().enabled = true;
        GameObject.Find("Graphen").GetComponent<Image>().enabled = true;
        GameObject.Find("GraphenImage").GetComponent<Image>().enabled = true;
        GameObject.Find("Endscreen Hintergrund").GetComponent<Image>().enabled = true;
        GameObject.Find("Neustart").transform.Find("Text").GetComponent<Text>().enabled = true;
        GameObject.Find("Verlassen").GetComponent<Button>().enabled = true;
        GameObject.Find("Verlassen").GetComponent<Image>().enabled = true;
        GameObject.Find("Verlassen").transform.Find("Text").GetComponent<Text>().enabled = true;
        GameObject.Find("Rundenanzeige").GetComponent<Text>().enabled = false;
        GameObject.Find("MassnahmenHistory").transform.Find("Image").GetComponent<Button>().enabled = false;
        GameObject.Find("MassnahmenHistory").transform.Find("Image").GetComponent<Image>().enabled = false;
        GameObject.Find("PausenMenu").transform.Find("Image").GetComponent<Button>().enabled = false;
        GameObject.Find("PausenMenu").transform.Find("Image").GetComponent<Image>().enabled = false;
        GameObject.Find("Hilfe").transform.Find("Image").GetComponent<Button>().enabled = false;
        GameObject.Find("Hilfe").transform.Find("Image").GetComponent<Image>().enabled = false;
        GameObject.Find("Attribute Hintergrund").GetComponent<Image>().enabled = false;

        EndscreenPunkteOn();
               

    }
    
    //zeigt einen Text an, wenn das Spiel zwar vorbei ist, jedoch noch nicht alle Ereignisse abgehandelt wurden
    public static void EndscreenWait()
    {
        GameObject.Find("EndscreenText").GetComponent<Text>().enabled = true;
        GameObject.Find("EndscreenText").GetComponent<Text>().text = "Warte auf aktuelle Nachrichtenlage...";
    }

    //öffnet den Reiter der Punkteübersicht im Endscreen
    public static void EndscreenPunkteOn()
    {
        GameObject.Find("Punkte").GetComponent<RectTransform>().sizeDelta = new Vector2(150, 50);
        GameObject.Find("PunkteImage").GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        GameObject.Find("PunkteImage").transform.parent.GetChild(GameObject.Find("PunkteImage").transform.GetSiblingIndex() - 3).GetComponent<Doozy.Engine.UI.UIButton>().ExecutePointerExit();
        GameObject.Find("Endpunkte").GetComponent<Text>().enabled = true;
        GameObject.Find("Endpunkte1").GetComponent<Text>().enabled = true;

        EndscreenAttributswerteOn();

    }

    //schließt den Reiter der Punkteübersicht im Endscreen
    public static void EndscreenPunkteOff()
    {
        GameObject.Find("Punkte").GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);        
        GameObject.Find("Endpunkte").GetComponent<Text>().enabled = false;
        GameObject.Find("Endpunkte1").GetComponent<Text>().enabled = false;

        EndscreenAttributswerteOff();
    }

    //aktiviert die Leiste mit den Attributen und schiebt diese an die richtige Position im Endscreen
    public static void EndscreenAttributswerteOn()
    {
        GameObject.Find("Attributswerte").transform.localPosition = new Vector3(GameObject.Find("Endscreen Hintergrund").transform.localPosition.x, GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height / 2 - 70, GameObject.Find("Attributswerte").transform.localPosition.z);

        foreach (Transform child in GameObject.Find("Attributswerte").transform)
        {
            child.transform.Find("Hintergrund").GetComponent<RawImage>().enabled = true;
            child.transform.Find("AttWert").GetComponent<RawImage>().enabled = true;
            child.transform.Find("Image").GetComponent<Image>().enabled = true;
            child.transform.Find("Hitbox").GetComponent<RawImage>().enabled = true;
        }
    }

    //deaktiviert die Leiste mit den Attributen im Endscreen
    public static void EndscreenAttributswerteOff()
    {
        foreach (Transform child in GameObject.Find("Attributswerte").transform)
        {
            child.transform.Find("Hintergrund").GetComponent<RawImage>().enabled = false;
            child.transform.Find("AttWert").GetComponent<RawImage>().enabled = false;
            child.transform.Find("Image").GetComponent<Image>().enabled = false;
            child.transform.Find("Hitbox").GetComponent<RawImage>().enabled = false;
        }
    }

    //öffnet die Chronik im Endscreen
    public static void EndscreenChronikOn()
    {
        GameObject.Find("Chronik").GetComponent<RectTransform>().sizeDelta = new Vector2(150, 50);
        GameObject.Find("ChronikImage").GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        GameObject.Find("ChronikImage").transform.parent.GetChild(GameObject.Find("ChronikImage").transform.GetSiblingIndex() - 3).GetComponent<Doozy.Engine.UI.UIButton>().ExecutePointerExit();

        //verschiebt die Chronik aus dem Chronik-Meü in den Endscreen, passt die Größe entsprechend an und aktiviert alle Elemente
        GameObject.Find("Scroll View").GetComponent<RectTransform>().localPosition = GameObject.Find("Endscreen Hintergrund").GetComponent<RectTransform>().localPosition;
        GameObject.Find("Scroll View").GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("Endscreen Hintergrund").GetComponent<RectTransform>().sizeDelta.x, GameObject.Find("Scroll View").GetComponent<RectTransform>().rect.height);
        GameObject.Find("Scroll View").GetComponent<ScrollRect>().enabled = true;
        GameObject.Find("Scroll View").GetComponent<Image>().enabled = true;
        GameObject.Find("Viewport").GetComponent<Mask>().enabled = true;
        GameObject.Find("Viewport").GetComponent<Image>().enabled = true;
        GameObject.Find("Scrollbar Vertical").GetComponent<Image>().enabled = true;
        GameObject.Find("Handle").GetComponent<Image>().enabled = true;

        //aktiviert jedes einzelne Element in der Chronik
        foreach (Transform child in GameObject.Find("Content").transform)
        {
            child.GetComponent<Image>().enabled = true;
            foreach (Transform child2 in child)
            {
                child2.GetComponent<Text>().enabled = true;
            }
        }

        EndscreenAttributswerteOn();

    }

    //deaktiviert die Chronik im Endscreen
    public static void EndscreenChronikOff()
    {
        GameObject.Find("Chronik").GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);
        GameObject.Find("Scroll View").GetComponent<ScrollRect>().enabled = false;
        GameObject.Find("Scroll View").GetComponent<Image>().enabled = false;
        GameObject.Find("Viewport").GetComponent<Mask>().enabled = false;
        GameObject.Find("Viewport").GetComponent<Image>().enabled = false;
        GameObject.Find("Scrollbar Vertical").GetComponent<Image>().enabled = false;
        GameObject.Find("Handle").GetComponent<Image>().enabled = false;
        
        foreach (Transform child in GameObject.Find("Content").transform)
        {
            child.GetComponent<Image>().enabled = false;
            foreach (Transform child2 in child)
            {
                child2.GetComponent<Text>().enabled = false;
            }
        }

        EndscreenAttributswerteOff();
    }

    //aktiviert die Graphen/Statistiken im Endscreen
    public static void EndscreenGraphenOn()
    {
        GameObject.Find("Graphen").GetComponent<RectTransform>().sizeDelta = new Vector2(150, 50);
        GameObject.Find("StatsText").GetComponent<Text>().enabled = true;
        GameObject.Find("StatsText1").GetComponent<Text>().enabled = true;
        GameObject.Find("StatsText2").GetComponent<Text>().enabled = true;
        GameObject.Find("StatsText3").GetComponent<Text>().enabled = true;
        GameObject.Find("GraphenImage").GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        GameObject.Find("GraphenImage").transform.parent.GetChild(GameObject.Find("GraphenImage").transform.GetSiblingIndex() - 3).GetComponent<Doozy.Engine.UI.UIButton>().ExecutePointerExit();

        //die Graphen aller Ideologien werden aktiviert
        foreach (Transform child in GameObject.Find("IdeologienStats").transform)
        {
            child.GetComponent<Image>().enabled = true;
            child.Find("StatWert").GetComponent<Image>().enabled = true;
            child.Find("Hitbox").GetComponent<Image>().enabled = true;
            child.Find("Name").GetComponent<Text>().enabled = true;
        }

        //die Graphen aller Ressorts werden aktiviert
        foreach (Transform child in GameObject.Find("RessortStats").transform)
        {
            child.GetComponent<Image>().enabled = true;
            child.Find("StatWert").GetComponent<Image>().enabled = true;
            child.Find("Hitbox").GetComponent<Image>().enabled = true;
            child.Find("Name").GetComponent<Text>().enabled = true;
        }
    }

    //deaktiviert die Graphen/Statistiken im Endscreen
    public static void EndscreenGraphenOff()
    {
        GameObject.Find("Graphen").GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);
        GameObject.Find("StatsText").GetComponent<Text>().enabled = false;
        GameObject.Find("StatsText1").GetComponent<Text>().enabled = false;
        GameObject.Find("StatsText2").GetComponent<Text>().enabled = false;
        GameObject.Find("StatsText3").GetComponent<Text>().enabled = false;

        //die Graphen aller Ideologien werden deaktiviert
        foreach (Transform child in GameObject.Find("IdeologienStats").transform)
        {
            child.GetComponent<Image>().enabled = false;
            child.Find("StatWert").GetComponent<Image>().enabled = false;
            child.Find("Hitbox").GetComponent<Image>().enabled = false;
            child.Find("Name").GetComponent<Text>().enabled = false;
        }

        //die Graphen aller Ressorts werden deaktiviert
        foreach (Transform child in GameObject.Find("RessortStats").transform)
        {
            child.GetComponent<Image>().enabled = false;
            child.Find("StatWert").GetComponent<Image>().enabled = false;
            child.Find("Hitbox").GetComponent<Image>().enabled = false;
            child.Find("Name").GetComponent<Text>().enabled = false;
        }
    }

    //aktiviert die Chronik während des Spiels
    public static IEnumerator MassnahmenHistoryMenuOn()
    {
        GameObject.Find("Curtain").GetComponent<Image>().enabled = true;
        GameObject.Find("Curtain").transform.Find("Text").GetComponent<Text>().enabled = true;
        GameObject.Find("Curtain").transform.Find("Text").GetComponent<Text>().text = "Maßnahmen-Chronik";
        GameObject.Find("Scroll View").GetComponent<ScrollRect>().enabled = true;
        GameObject.Find("Scroll View").GetComponent<Image>().enabled = true;
        GameObject.Find("Viewport").GetComponent<Mask>().enabled = true;
        GameObject.Find("Viewport").GetComponent<Image>().enabled = true;
        GameObject.Find("PausenMenu").transform.Find("Image").GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        GameObject.Find("Hilfe").transform.Find("Image").GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        //jedes einzelne Element mit einer Maßnahme oder einem Ereignis in der Chronik wird aktiviert
        foreach (Transform child in GameObject.Find("Content").transform)
        {
            child.GetComponent<Image>().enabled = true;
            foreach (Transform child2 in child)
            {
                child2.GetComponent<Text>().enabled = true;
            }
        }

        //wartet bis zum nächsten Frame, damit Unity zunächst die Größe der Elemente in Abhängigkeit des Inhalts festlegen kann
        yield return new WaitForEndOfFrame();
        
        //wenn die Menge an Ereignissen die Größe des Chronik-Fensters überschreitet, wird die Scrollbar aktiviert
        if (GameObject.Find("Content").GetComponent<RectTransform>().rect.height > GameObject.Find("Scroll View").GetComponent<RectTransform>().rect.height)
        {            
            GameObject.Find("Scrollbar Vertical").GetComponent<Image>().enabled = true;
            GameObject.Find("Handle").GetComponent<Image>().enabled = true;
        }
               
        yield break;
    }

    //deaktiviert die Chronik während des Spiels
    public static void MassnahmenHistoryMenuOff()
    {
        GameObject.Find("Curtain").GetComponent<Image>().enabled = false;
        GameObject.Find("Curtain").transform.Find("Text").GetComponent<Text>().enabled = false;
        GameObject.Find("Scroll View").GetComponent<ScrollRect>().enabled = false;
        GameObject.Find("Scroll View").GetComponent<Image>().enabled = false;
        GameObject.Find("Scrollbar Vertical").GetComponent<Image>().enabled = false;
        GameObject.Find("Handle").GetComponent<Image>().enabled = false;
        GameObject.Find("Viewport").GetComponent<Mask>().enabled = false;
        GameObject.Find("Viewport").GetComponent<Image>().enabled = false;
        GameObject.Find("PausenMenu").transform.Find("Image").GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        GameObject.Find("Hilfe").transform.Find("Image").GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f);

        //jedes einzelne Element mit einer Maßnahme oder einem Ereignis in der Chronik wird deaktiviert
        foreach (Transform child in GameObject.Find("Content").transform)
        {
            child.GetComponent<Image>().enabled = false;
            foreach (Transform child2 in child)
            {
                child2.GetComponent<Text>().enabled = false;
            }
        }
    }

    //aktiviert das Pausenmenü
    public static void PausenMenuOn()
    {
        GameObject.Find("Curtain").GetComponent<Image>().enabled = true;
        GameObject.Find("Curtain").transform.Find("Text").GetComponent<Text>().text = "Pause";
        GameObject.Find("Curtain").transform.Find("Text").GetComponent<Text>().enabled = true;
        GameObject.Find("PauseFortsetzen").GetComponent<Image>().enabled = true;
        GameObject.Find("PauseFortsetzen").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("PauseNeustart").GetComponent<Image>().enabled = true;
        GameObject.Find("PauseNeustart").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("PauseVerlassen").GetComponent<Image>().enabled = true;
        GameObject.Find("PauseVerlassen").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("PauseVerlassen").GetComponent<Button>().enabled = true;
        GameObject.Find("PauseNeustart").GetComponent<Button>().enabled = true;
        GameObject.Find("PauseFortsetzen").GetComponent<Button>().enabled = true;
        GameObject.Find("PauseFortsetzen").transform.Find("Text").GetComponent<Text>().enabled = true;
        GameObject.Find("PauseNeustart").transform.Find("Text").GetComponent<Text>().enabled = true;
        GameObject.Find("PauseVerlassen").transform.Find("Text").GetComponent<Text>().enabled = true;
        GameObject.Find("MassnahmenHistory").transform.Find("Image").GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        GameObject.Find("Hilfe").transform.Find("Image").GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        //stoppt die Textlauf-Elemente, also die Eilmeldungen am unteren Bildschirmrand
        for (int i = 1; i < GameObject.Find("Textlauf").transform.childCount - 1; i++)
        {
            GameObject.Find("Textlauf").transform.GetChild(i).GetComponent<Textlauf>().aktiv = false;
        }
    }

    //deaktiviert das Pausenmenü
    public static void PausenMenuOff()
    {
        GameObject.Find("Curtain").GetComponent<Image>().enabled = false;
        GameObject.Find("Curtain").transform.Find("Text").GetComponent<Text>().enabled = false;
        GameObject.Find("PauseFortsetzen").GetComponent<Image>().enabled = false;
        GameObject.Find("PauseNeustart").GetComponent<Image>().enabled = false;
        GameObject.Find("PauseVerlassen").GetComponent<Image>().enabled = false;
        GameObject.Find("PauseVerlassen").GetComponent<Button>().enabled = false;
        GameObject.Find("PauseNeustart").GetComponent<Button>().enabled = false;
        GameObject.Find("PauseFortsetzen").GetComponent<Button>().enabled = false;
        GameObject.Find("PauseFortsetzen").transform.Find("Text").GetComponent<Text>().enabled = false;
        GameObject.Find("PauseNeustart").transform.Find("Text").GetComponent<Text>().enabled = false;
        GameObject.Find("PauseVerlassen").transform.Find("Text").GetComponent<Text>().enabled = false;
        GameObject.Find("MassnahmenHistory").transform.Find("Image").GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        GameObject.Find("Hilfe").transform.Find("Image").GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f);

        //startet die Textlauf-Elemente wieder, also die Eilmeldungen am unteren Bildschirmrand
        for (int i = 1; i < GameObject.Find("Textlauf").transform.childCount - 1; i++)
        {
            if (GameObject.Find("Textlauf").transform.GetChild(i).GetComponent<Text>().text != "")  GameObject.Find("Textlauf").transform.GetChild(i).GetComponent<Textlauf>().aktiv = true;
        }
    }

    //ändert die Farbe der Buttons in blau
    public static void OnButtonHover(Image hoveredButton)
    {
        hoveredButton.color = new Color(0.72f, 0.85f, 0.99f, 1.0f);
    }

    //ändert die Farbe der Buttons in grau
    public static void OnButtonLeave(Image hoveredButton)
    {
         hoveredButton.color = new Color(0.0f, 0.0f, 0.0f, 0.04f);
    }

}
