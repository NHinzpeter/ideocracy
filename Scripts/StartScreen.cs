using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//Verwaltet den Startscreen

public class StartScreen : MonoBehaviour
{
   
    void Start()
    {
        StartCoroutine(LoadingScreen());
    }

    //Update wird jeden Frame ausgeführt
    void Update()
    {
        //Jeden Frame wird das Logo in der Mitte ein Stück größer
        GameObject.Find("RawImage").GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("RawImage").GetComponent<RectTransform>().rect.width + Time.deltaTime * 15, GameObject.Find("RawImage").GetComponent<RectTransform>().rect.height + Time.deltaTime * 15);
    }

    IEnumerator LoadingScreen()
    {
        //nach 1,5 Sekunden wird zum eigentlichen Spiel übergeleitet
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadSceneAsync(1);
    }

    }
