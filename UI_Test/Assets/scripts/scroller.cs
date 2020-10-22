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
        //loading initial cards
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

        //checks position of scroller, if near bottom it will load more cards, then moves the scroller up a little to stop it from loading too many
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
