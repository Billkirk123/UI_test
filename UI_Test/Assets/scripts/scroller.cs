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

    public GameObject cardPrefab;

    public GameObject content;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            Instantiate(cardPrefab, content.transform);
        }

        myScrRect.verticalNormalizedPosition = 1f;
    }

    // Update is called once per frame
    void Update()
    {


        if (myScrRect.verticalNormalizedPosition <= 0.01f)
        {
            for (int i = 0; i < 20; i++)
            {
                Instantiate(cardPrefab, content.transform);
            }

            myScrRect.verticalNormalizedPosition = 0.05f;
        }
    }
}
