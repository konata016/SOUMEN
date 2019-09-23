using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトルシーンから操作方法シーンへの遷移
/// </summary>
public class Title2UI : MonoBehaviour
{
    /* public変数*/

    /* --- SerializeFieldの変数 --- */

    /* --- 変数 ---*/

    /* --- private変数 --- */
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //遷移する際に押してもらうボタン。
        if (MyJoyCon.joyconDec.button != null)
        {
            Debug.Log("Transition");

            //効果音が終わるまで待つ。
            StartCoroutine("waitForSound", audioSource.clip.length);

            SceneManager.LoadScene(1);
        }
    }

    //効果音の長さを引数に、その分だけ待機する。
    private IEnumerator waitForSound(float soundLength)
    {
        audioSource.Play();
        yield return new WaitForSeconds(soundLength);
    }
}
