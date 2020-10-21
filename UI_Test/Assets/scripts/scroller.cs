using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using SimpleJSON;
public class scroller : MonoBehaviour
{
    public ScrollRect myScrRect;

    public GameObject cardPrefab1;
    public GameObject cardPrefab2;


    public GameObject content;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(cardPrefab2, content.transform);
            Instantiate(cardPrefab1, content.transform);
        }

        myScrRect.verticalNormalizedPosition = 1f;
    }

    // Update is called once per frame
    void Update()
    {


        if (myScrRect.verticalNormalizedPosition <= 0.01f)
        {
            for (int i = 0; i < 10; i++)
            {               
                Instantiate(cardPrefab2, content.transform);           
                Instantiate(cardPrefab1, content.transform);
            }

            myScrRect.verticalNormalizedPosition = 0.1f;
        }
    }
}
