using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PostController : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(HttpConnect());
        
    }
    IEnumerator HttpConnect()
    {
        WWWForm form = new WWWForm();//昔の送信したいときの名残を書く。インスタンスを作る。post通信はWWWForm使う。
        form.AddField("x", 5);//フィールドを追加していく。x=5というフィールドに追加それでサーバー側に置く
        form.AddField("y", 8);//hashmap と一緒.第一引数はキー　第二は値。第二は小数点入れるときは文字列にする。requestparameter は文字列になる。

        string url= "https://joytas.net/php/calc.php";
        UnityWebRequest uwr = UnityWebRequest.Post(url,form);//リクエストとリスポンスを構成するモジュラーを提供する
        yield return uwr.SendWebRequest();//sendwebrequest 送受信開始
        if (uwr.isHttpError || uwr.isNetworkError)
        {
            Debug.Log(uwr.error);//コンソールに文字を表す

        }
        else
        {
            Debug.Log(uwr.downloadHandler.text);//ダウンロードハンドラーでデータの送信処理を行う。
        }
    }

 
}
