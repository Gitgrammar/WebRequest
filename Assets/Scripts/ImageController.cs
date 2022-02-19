using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ImageController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HttpConnect());
    }

    IEnumerator HttpConnect()
    {
        string url= "https://joytas.net/php/man.jpg";
        UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url);
        yield return uwr.SendWebRequest();
        if (uwr.isHttpError || uwr.isNetworkError)
        {
            Debug.Log(uwr.error);
        }
        else
        {

            Texture texture = DownloadHandlerTexture.GetContent(uwr);//textureは単なる画像
            //単なる画像をスプライトに変える。キャンバスは中心の概念があるため変える必要がある。

            Sprite sp = Sprite.Create((Texture2D)texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));//スプライトに変換する。
                                                                                                                                  //　１引数がダウンロードしたtextureダウンキャスト。ダウンキャストはもう決まり。もともとの画像第二引数。第三引数はピボット
            sp.name = "man";
            Image image = GetComponent<Image>();//imagecomponent 取得

            image.rectTransform.sizeDelta = new Vector2(texture.width, texture.height);

            image.sprite = sp;

        }
    }

}
