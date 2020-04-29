using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//befindet sich auf jedem einzelnen Element in der Chonik, die die vergangenen Maßnahmen und Ereignisse anzeigen

public class HistoryMassnahme : EventTrigger
{
    public override void OnScroll(PointerEventData eventData)
    {
        //die einzelnen Elemente in der Chonik, die die vergangenen Maßnahmen und Ereignisse anzeigen, senden an das sie umgebende Fenster, wenn über diesen gescrollt wird. 
        //Das ist wichtig, da das Scrollen innerhalb der Chronik sonst kaum möglich wäre, da diese Elemente ansonsten den Befehl "blockieren".
        GameObject.Find("Scroll View").GetComponent<ScrollRect>().SendMessage("OnScroll", eventData);
    }

}
