using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Skript befindet sich auf jedem Attribut. Speichert den Attributwert und steuert die Animation bei Veränderung des Wertes

public class AttWert : MonoBehaviour
{
    public int wert;
    private int increaseSpeed = 40;
    private float prevWert;
    private GameObject attChange;
    

    void Start()
    {
        prevWert = 0;
        attChange = transform.parent.transform.Find("AttChange").gameObject;        
    }

    //Update wird jeden Frame ausgeführt
    void Update()
    {
        //begrenzt den Wert auf ein Gebiet von 0 bis 100
        if (wert > 100) wert = 100;
        if (wert < 0) wert = 0;

        //Wenn sich der Wert seit dem vorherigen Frame verändert hat, wird die Animation angezeigt
        if (wert != prevWert)
        {
            //je nachdem, ob der neue Wert größer oder kleiner ist, wird die Farbe der Veränderung grün oder rot gesetzt und entsprechend der Wert langsam angehoben oder gesenkt
            if (wert > prevWert)
            {
                attChange.GetComponent<RawImage>().color = new Color(0.0f, 0.37f, 0.08f, 0.63f);
                if ((wert - prevWert) > (Time.deltaTime * increaseSpeed))
                    prevWert += Time.deltaTime * increaseSpeed;
                else prevWert = wert;
            }
            else
            {
                attChange.GetComponent<RawImage>().color = new Color(0.82f, 0.0f, 0.0f, 0.63f);
                if ((wert - prevWert) < Time.deltaTime * increaseSpeed)
                    prevWert -= Time.deltaTime * increaseSpeed;
                else prevWert = wert;
            }

            //Die Größe und die Position der Balken des Wertes und der Veränderung werden angepasst
            GetComponent<RectTransform>().localScale = new Vector3(GetComponent<RectTransform>().localScale.x, prevWert, GetComponent<RectTransform>().localScale.z);
            GetComponent<RectTransform>().localPosition = new Vector3(GetComponent<RectTransform>().localPosition.x, prevWert / 2 - 50, GetComponent<RectTransform>().localPosition.z);
            attChange.GetComponent<RectTransform>().localScale = new Vector3(attChange.GetComponent<RectTransform>().localScale.x, Mathf.Abs(prevWert - wert), attChange.GetComponent<RectTransform>().localScale.z);
            attChange.GetComponent<RectTransform>().localPosition = new Vector3(attChange.GetComponent<RectTransform>().localPosition.x, wert + ((prevWert - wert) / 2) - 50, attChange.GetComponent<RectTransform>().localPosition.z);
            attChange.GetComponent<RawImage>().enabled = true;
        }
    }
}
