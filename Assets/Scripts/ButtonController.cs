using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ButtonController : MonoBehaviour
{
    public InputField et1; //inputfield型. UIを置くとできる。
    public InputField et2;
    public Text result;//textをコンポーネントを置く

    public void btClick()
    {
        string x = et1.text;
        string y = et2.text;
        StartCoroutine(HttpConnect(x, y));
    }
    IEnumerator HttpConnect(string x, string y)//文字列２つで受け取る
    {
        WWWForm form = new WWWForm();
        form.AddField("x", x); 
        form.AddField("y", y);
        string url = "https://joytas.net/php/calc.php";//post通信でjoytasへ送る。
        UnityWebRequest uwr = UnityWebRequest.Post(url, form);
        yield return uwr.SendWebRequest();
        if (uwr.isHttpError || uwr.isNetworkError)
        {
            Debug.Log(uwr.error);
        }
        else
        {
            result.text = uwr.downloadHandler.text; //通信したときの結果をresult.textで代入.
            Debug.Log(result.text);
        }
    }
}