using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using SimpleJSON;

public class card : MonoBehaviour
{


    private readonly string baseURL = "https://jsonplaceholder.typicode.com/photos/";
    public RawImage image;
    public TMP_Text text;

    void Start()
    {
         StartCoroutine(getImageAtID(Random.Range(1, 5000)));
    }

   IEnumerator getImageAtID(int ID)
    {
        
        //access API
        string fullURL = baseURL + ID.ToString();

        UnityWebRequest getInfo = UnityWebRequest.Get(fullURL);

        yield return getInfo.SendWebRequest();

        if(getInfo.isNetworkError || getInfo.isHttpError)
        {
            Debug.LogError(getInfo.error);
            yield break;
        }

        JSONNode photoInfo = JSON.Parse(getInfo.downloadHandler.text);

        string photoURL = photoInfo["url"];
        string title = photoInfo["title"];
        //access photo
        UnityWebRequest getPhoto = UnityWebRequestTexture.GetTexture(photoURL);

        yield return getPhoto.SendWebRequest();

        if (getPhoto.isNetworkError || getPhoto.isHttpError)
        {
            Debug.LogError(getPhoto.error);
            yield break;
        }

        //set image and text

        image.texture = DownloadHandlerTexture.GetContent(getPhoto);

        text.text = title;

    }
}
