using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HttpController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HttpConnect());
        
    }
    IEnumerator HttpConnect()
    {
        string url = "https://joytas.net/php/hello.php";

        UnityWebRequest uwr = UnityWebRequest.Get(url);//getnメソッド使うとインスタンスが返る。get()インスタンスメソッド
        yield return uwr.SendWebRequest();//get通信　sendwebrequestはメソッド　。通信してる間
        if (uwr.isHttpError || uwr.isNetworkError)//wifiがつながらないなどの通信エラー
        {
            Debug.Log(uwr.error);
        }
        else
        {
            Debug.Log(uwr.downloadHandler.text);//本文にアクセスできる。
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
