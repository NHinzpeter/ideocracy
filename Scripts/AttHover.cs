using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Doozy;

//Skript befindet sich auf jedem einzelnen Attribut oben rechts

public class AttHover : MonoBehaviour
{
    //zeigt beim Hovern den Namen des jeweiligen Attributs an
    public void ZeigeText()
    {
        transform.parent.Find("Text").GetComponent<Text>().enabled = true;
        transform.parent.Find("Image").GetComponent<Image>().color = new Color(0.16f, 0.6f, 0.97f, 1.0f);
        transform.parent.Find("Image").GetComponent<Doozy.Engine.UI.UIButton>().ExecutePointerEnter();
    }

    //blendet nach dem Hovern den Namen des jeweiligen Attributs aus
    public void LöscheText()
    {
        transform.parent.Find("Text").GetComponent<Text>().enabled = false;
        transform.parent.Find("Image").GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
    }
}
