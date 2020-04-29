using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//verwaltet den gesamten Endscreen

public class Endscreen : MonoBehaviour
{
    public Button Neustart, Verlassen, Punkte, Chronik, Graphen;
    public GameObject IdeologienStats, RessortStats, MassnahmenHistory;
    private int[] ideologienWerte = new int[3];
    private int[] ressortWerte = new int[6];
    
    void Start()
    {
        Neustart.onClick.AddListener(NeustartButtonOnClick);
        Verlassen.onClick.AddListener(VerlassenButtonOnClick);
        Punkte.onClick.AddListener(PunkteButtonOnClick);
        Chronik.onClick.AddListener(ChronikButtonOnClick);
        Graphen.onClick.AddListener(GraphenButtonOnClick);
    }

    private void NeustartButtonOnClick()
    {
        //Startet das Spiel neu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void VerlassenButtonOnClick()
    {
        //beendet das Spiel
        Application.Quit();
    }

    //OnClick-Event, das beim Klick auf den obersten Reiter im Endscreen ausgelöst wird
    private void PunkteButtonOnClick()
    {
        //überprüft, ob die Chronik oder die Graphen angezeigt werden, falls ja, schließt es den entsprechenden Reiter und öffnet die Punkteübersicht
        if (GameObject.Find("Chronik").GetComponent<RectTransform>().rect.width == 150)
        {
            UIVerwaltung.EndscreenChronikOff();
            UIVerwaltung.EndscreenPunkteOn();
        }
        else if (GameObject.Find("Graphen").GetComponent<RectTransform>().rect.width == 150)
        {
            UIVerwaltung.EndscreenGraphenOff();
            UIVerwaltung.EndscreenPunkteOn();

        }
    }

    //OnClick-Event, das beim Klick auf den mittleren Reiter im Endscreen ausgelöst wird
    private void ChronikButtonOnClick()
    {
        //erschafft für jede abgeschlossene Maßnahme und jedes Ereignis ein eigenes Element in der Chronik und füllt dieses mit den notwendigen Infos
        int childNr = 0;
        foreach (Transform child in GameObject.Find("MassnahmenContainer").transform)
        {
            if (childNr > GameObject.Find("Content").transform.childCount - 1)
                GameObject.Instantiate(GameObject.Find("Content").transform.GetChild(0), GameObject.Find("Content").transform);

            GameObject.Find("Content").transform.GetChild(childNr).Find("Ressortname").GetComponent<Text>().text = child.GetComponent<Massnahme>().ressort;
            GameObject.Find("Content").transform.GetChild(childNr).Find("Ideologie").GetComponent<Text>().text = child.GetComponent<Massnahme>().ideologie;
            GameObject.Find("Content").transform.GetChild(childNr).Find("Beschreibung").GetComponent<Text>().text = child.GetComponent<Massnahme>().Beschreibung;

            childNr++;
        }

        //überprüft, welcher der beiden anderen Reiter derzeit geöffnet ist und schließt den entsprechenden, anschließend wird der Chronik-Reiter geöffnet
        if (GameObject.Find("Punkte").GetComponent<RectTransform>().rect.width == 150)
        {
            UIVerwaltung.EndscreenPunkteOff();
            UIVerwaltung.EndscreenChronikOn();
        }
        else if (GameObject.Find("Graphen").GetComponent<RectTransform>().rect.width == 150)
        {
            UIVerwaltung.EndscreenGraphenOff();
            UIVerwaltung.EndscreenChronikOn();
        }
    }

    //OnClick-Event, das beim Klick auf den unteren Reiter im Endscreen ausgelöst wird
    private void GraphenButtonOnClick()
    {
        //überprüft, welcher der beiden anderen Reiter derzeit geöffnet ist und schließt den entsprechenden, anschließend wird der Graphen-Reiter geöffnet
        if (GameObject.Find("Chronik").GetComponent<RectTransform>().rect.width == 150)
        {
            UIVerwaltung.EndscreenChronikOff();
            UIVerwaltung.EndscreenGraphenOn();
        }
        else if (GameObject.Find("Punkte").GetComponent<RectTransform>().rect.width == 150)
        {
            UIVerwaltung.EndscreenPunkteOff();
            UIVerwaltung.EndscreenGraphenOn();
        }
    }

    //verändert die Farbe der großen Buttons links im Endscreen beim Hovern
    public void EndscreenButtonHover(GameObject Button)
    {
        UIVerwaltung.OnButtonHover(Button.GetComponent<Image>());
    }

    //ändert die Farbe der großen Buttons links im Endscreen zurück nach dem Hovern
    public void EndscreenButtonExit(GameObject Button)
    {
        UIVerwaltung.OnButtonLeave(Button.GetComponent<Image>());
        Button.GetComponent<Doozy.Engine.UI.UIButton>().ExecutePointerExit();
    }

    //verändert die Farbe und Größe der Reiter im Endscreen, sofern dieser nicht gerade ausgewählt ist
    public void SidebarButtonHover(GameObject Button)
    {
        if (Button.transform.parent.GetChild(Button.transform.GetSiblingIndex() - 3).GetComponent<RectTransform>().rect.width == 50)
        {
            Button.GetComponent<Image>().color = new Color(0.16f, 0.6f, 0.97f, 1.0f);
            Button.transform.parent.GetChild(Button.transform.GetSiblingIndex() - 3).GetComponent<Doozy.Engine.UI.UIButton>().ExecutePointerEnter();
        }
    }

    //ändert die Farbe und Größe der Reiter im Endscreen zurück
    public void SidebarButtonExit(GameObject Button)
    {
        if (Button.transform.parent.GetChild(Button.transform.GetSiblingIndex() - 3).GetComponent<RectTransform>().rect.width == 50)
        {
            Button.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            Button.transform.parent.GetChild(Button.transform.GetSiblingIndex() - 3).GetComponent<Doozy.Engine.UI.UIButton>().ExecutePointerExit();
        }
    }

    //beim Hovern über die Graphen werden die Werte als Zahlen angezeigt
    public void StatHover(GameObject parent)
    {
        foreach (Transform child in parent.transform) child.Find("WertText").GetComponent<Text>().enabled = true;
    }

    //blendet die Zahlen nach dem Hovern wieder aus
    public void StatExit(GameObject parent)
    {
        foreach (Transform child in parent.transform) child.Find("WertText").GetComponent<Text>().enabled = false;
    }

    //zeigt den Endpunktestand an und spielt die Animationen ab
    public IEnumerator ZeigeEndpunkte()
    {
        int Punkte = 0;
        GameObject.Find("Canvas").GetComponent<GameController>().GesamtPunkte = 0;

        //berechnet den Endpunktestand
        for (int i = 0; i < 10; i++)
        {
            GameObject.Find("Canvas").GetComponent<GameController>().GesamtPunkte += GameObject.Find("Attributswerte").transform.GetChild(i).transform.Find("AttWert").GetComponent<AttWert>().wert;
        }

        //der Trommelwirbel startet
        GetComponent<AudioSource>().Play();

        //Jeden Frame wird der angezeigte Punktestand ein bisschen erhöht, bis er den tatsächlichen Endpunktestand erreicht hat
        while (Punkte < GameObject.Find("Canvas").GetComponent<GameController>().GesamtPunkte)
        {
            Punkte += (int)Mathf.Round(Time.deltaTime * 120);

            if (Punkte > GameObject.Find("Canvas").GetComponent<GameController>().GesamtPunkte)
            {
                Punkte = GameObject.Find("Canvas").GetComponent<GameController>().GesamtPunkte;
            }

            GameObject.Find("Endpunkte").GetComponent<Text>().text = Punkte.ToString();
            yield return new WaitForEndOfFrame();
        }

        //Sobald der finale Endpunktestand erreicht ist, kommt das Konfetti und der Sound wird abgespielt
        GameObject.Find("KonfettiL").GetComponent<ParticleSystem>().Play();
        GameObject.Find("KonfettiL").GetComponent<AudioSource>().Play();
        GameObject.Find("KonfettiR").GetComponent<ParticleSystem>().Play();
        GameObject.Find("KonfettiR").GetComponent<AudioSource>().Play();
    }

    //berechnet die Graphen
    public void BerechneStats()
    {
        for (int i = 0; i < 3; i++) ideologienWerte[i] = 0;
        for (int i = 0; i < 6; i++) ressortWerte[i] = 0;

        //jede abgeschlossene Maßnahme wird ausgewertet, zu welcher Ideologie und welchem Ressort sie gehört
        foreach (Transform child in MassnahmenHistory.transform)
        {
            if (child.GetComponent<Massnahme>().ideologie == "Konservativismus") ideologienWerte[0]++;
            if (child.GetComponent<Massnahme>().ideologie == "Sozialdemokratie") ideologienWerte[1]++;
            if (child.GetComponent<Massnahme>().ideologie == "Liberalismus") ideologienWerte[2]++;

            if (child.GetComponent<Massnahme>().ressort == "Finanzen") ressortWerte[0]++;
            if (child.GetComponent<Massnahme>().ressort == "Innere Sicherheit") ressortWerte[1]++;
            if (child.GetComponent<Massnahme>().ressort == "Wirtschaft") ressortWerte[2]++;
            if (child.GetComponent<Massnahme>().ressort == "Arbeit") ressortWerte[3]++;
            if (child.GetComponent<Massnahme>().ressort == "Soziales") ressortWerte[4]++;
            if (child.GetComponent<Massnahme>().ressort == "Schwerpunkt") ressortWerte[5]++;
        }

        //die Größe der Balken wird entsprechend des Wertes angepasst
        foreach (Transform child in IdeologienStats.transform)
        {
            int groesse = (int)Mathf.Round(child.GetComponent<RectTransform>().rect.height / 15 * ideologienWerte[child.GetSiblingIndex()]);
            child.Find("StatWert").GetComponent<RectTransform>().sizeDelta = new Vector2(50, groesse);
            child.Find("StatWert").GetComponent<RectTransform>().localPosition = new Vector3(child.Find("StatWert").GetComponent<RectTransform>().localPosition.x, groesse / 2 - 100, child.Find("StatWert").GetComponent<RectTransform>().localPosition.z);
            child.Find("WertText").GetComponent<Text>().text = ideologienWerte[child.GetSiblingIndex()].ToString();
        }

        //die Größe der Balken wird entsprechend des Wertes angepasst
        foreach (Transform child in RessortStats.transform)
        {
            int groesse = (int)Mathf.Round(child.GetComponent<RectTransform>().rect.height / 5 * ressortWerte[child.GetSiblingIndex()]);
            child.Find("StatWert").GetComponent<RectTransform>().sizeDelta = new Vector2(50, groesse);
            child.Find("StatWert").GetComponent<RectTransform>().localPosition = new Vector3(child.Find("StatWert").GetComponent<RectTransform>().localPosition.x, groesse / 2 - 100, child.Find("StatWert").GetComponent<RectTransform>().localPosition.z);
            child.Find("WertText").GetComponent<Text>().text = ressortWerte[child.GetSiblingIndex()].ToString();
        }
    }
}
