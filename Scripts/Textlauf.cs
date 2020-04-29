using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Verwaltet den Textlauf, also die Eilmeldungen am unteren Bildschirmrand. Befindet sich auf jeder einzelnen Meldung bzw dessen Wiederholung

public class Textlauf : MonoBehaviour
{
    public bool aktiv = false;
    public GameObject Hintergrund, Hitbox, Canvas;
    public Color standard, hervorgehoben;
    private GameObject naechstes = null;

    //Update wird jeden Frame ausgeführt
    void Update()
    {
        //sofern der Textlauf aktiv ist (nach Start des ersten Events und sofern die Pause nicht aktiv ist), wird dieser jeden Frame bewegt und ggf ein nächstes Textelement erschaffen
        if (aktiv == true)
        {
            //bewegt den Text jeden Frame. Time.deltaTime ist die Zeit, die zur Erstellung des letzten Frames benötigt wurde, der Text bewegt sich also jede Sekunde unabhängig von der Framerate gleich weit.
            transform.localPosition = new Vector3(transform.localPosition.x - Time.deltaTime*150, transform.localPosition.y, transform.localPosition.z);

            //Sobald der Text vollständig im Bildschirm ist, wird ein nächstes Textelement erstellt
            if (transform.localPosition.x < GameObject.Find("Canvas").GetComponent<RectTransform>().rect.size.x / 2 - GetComponent<RectTransform>().rect.size.x / 2 - 75 && naechstes == null && Canvas.GetComponent<GameController>().TextlaufStop == false)
            {
                naechstes = GameObject.Instantiate(this.gameObject, transform.parent);
                naechstes.transform.localPosition = new Vector3(transform.localPosition.x + GetComponent<RectTransform>().rect.size.x + 85, transform.localPosition.y, transform.localPosition.z);
                naechstes.GetComponent<Textlauf>().aktiv = true;
                GameObject.Find("Canvas").GetComponent<GameController>().TextlaufObject = naechstes;
                Hitbox.transform.SetAsLastSibling();
            }

            //Sobald der Text vollständig aus dem Bild ist, wird das Objekt zerstört
            if (transform.localPosition.x < -GameObject.Find("Canvas").GetComponent<RectTransform>().rect.size.x / 2 - GetComponent<RectTransform>().rect.size.x / 2)
            {
                Destroy(this.gameObject);
            }
        }
    }

    //Initiiert den Textlauf jedes Mal, wenn eine neues Ereignis eintritt
    public IEnumerator StarteTextLauf(string text)
    {
        //positioniert den Text zunächst im Nirvana und wartet bis zum nächsten Frame ab, damit die Größe des Elements erst durch Unity seines Inhalts angepasst werden kann
        transform.localPosition = new Vector3(GameObject.Find("Canvas").GetComponent<RectTransform>().rect.size.x*5, transform.localPosition.y, transform.localPosition.z);
        GetComponent<Text>().text = text;
        yield return new WaitForEndOfFrame();

        //positioniert den Text anschließend am rechten Bildrand und spielt den Signalton ab
        aktiv = true;
        transform.localPosition = new Vector3(GameObject.Find("Canvas").GetComponent<RectTransform>().rect.size.x / 2 + GetComponent<RectTransform>().rect.size.x / 2 + 10, transform.localPosition.y, transform.localPosition.z);
        transform.parent.GetComponent<AudioSource>().Play();

        yield break;
    }

    //lässt den unteren Bildschirmrand aufblinken, wenn ein neues Ereignis eintritt
    public IEnumerator Blinken()
    {
        for (int i = 0; i < 5; i++)
        {
            Hintergrund.GetComponent<Image>().color = hervorgehoben;
            yield return new WaitForSeconds(0.2f);
            Hintergrund.GetComponent<Image>().color = standard;
            yield return new WaitForSeconds(0.2f);
        }

        yield break;
    }
}
