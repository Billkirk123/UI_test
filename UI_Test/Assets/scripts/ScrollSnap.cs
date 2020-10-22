using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollSnap : MonoBehaviour
{
    public RectTransform panel;
    public RawImage[] element;
    public RectTransform center;

    private float[] distance;
    private bool dragging = false;
    private int elementDistance;
    private int minElementNum;


    //card sizes
    Vector3 defultSize = new Vector3(2f, 2f, 2f);
    Vector3 size1 = new Vector3(0.75f, 0.75f, 1f);
    Vector3 size2 = new Vector3(0.5f, 0.5f, 0.5f);
    Vector3 size3 = new Vector3(0.25f, 0.25f, 0.25f);

    
    

    // Start is called before the first frame update
    void Start()
    {
        int elementLength = element.Length;
        distance = new float[elementLength];       
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < element.Length; i++)
        {
            //get distance between all cards and center point
            distance[i] = Mathf.Abs(center.transform.position.x - element[i].transform.position.x);

            //change card size and position depending on how far away from the centre they are
            //Quite messy honestly
            if (distance[i] < 200)
            {
                element[i].transform.localScale = Vector3.Lerp(element[i].transform.localScale, defultSize, 0.1f);
                element[i].rectTransform.anchoredPosition = Vector2.MoveTowards(element[i].rectTransform.anchoredPosition, new Vector2(element[i].rectTransform.anchoredPosition.x, 85), 5f);
            }
            else if (distance[i] >= 200 && distance[i] < 400)
            {
                element[i].transform.localScale = Vector3.Lerp(element[i].transform.localScale, size1, 0.1f);
                element[i].rectTransform.anchoredPosition = Vector2.MoveTowards(element[i].rectTransform.anchoredPosition, new Vector2(element[i].rectTransform.anchoredPosition.x, -50), 5f);
            }
            else if (distance[i] >= 400 && distance[i] < 600)
            {
                element[i].transform.localScale = Vector3.Lerp(element[i].transform.localScale, size2, 0.1f);
                element[i].rectTransform.anchoredPosition = Vector2.MoveTowards(element[i].rectTransform.anchoredPosition, new Vector2(element[i].rectTransform.anchoredPosition.x, -115), 5f);
            }
            else if (distance[i] >= 600)
            {
                element[i].transform.localScale = Vector3.Lerp(element[i].transform.localScale, size3, 0.1f);
                element[i].rectTransform.anchoredPosition = Vector2.MoveTowards(element[i].rectTransform.anchoredPosition, new Vector2(element[i].rectTransform.anchoredPosition.x, -215), 5f);
            }



        }

        //workout which card is closest to center
        float minDistance = Mathf.Min(distance);

        for (int a = 0; a < element.Length; a++)
        {
            if(minDistance == distance[a])
            {
                minElementNum = a;
            }
        }
        if (!dragging)
        {
            lerpToElement(element[minElementNum].rectTransform.anchoredPosition.x*-1);
        }
    }

    void lerpToElement(float image)
    {
        
        Vector2 newPos = new Vector2(image, panel.anchoredPosition.y);

        panel.anchoredPosition = Vector2.MoveTowards(panel.anchoredPosition, newPos, 10f);
    }

    //these use event handlers in the editor
    public void StartDrag()
    {
        dragging = true;
    }

    public void endDrag()
    {
        dragging = false;
    }


}




