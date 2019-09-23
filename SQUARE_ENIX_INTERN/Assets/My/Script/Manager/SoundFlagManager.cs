using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 再生したい音のフラグを他スクリプトからtrueにすると、再生します。
/// シングルトンなのでフラグは全てstaticです。
/// </summary>
public class SoundFlagManager : MonoBehaviour
{
    /* public変数*/
    public static bool isJump;     //ジャンプ時のフラグ
    public static bool isLand;      //着水した時のフラグ

    /* --- SerializeFieldの変数 --- */
    [SerializeField] private AudioClip jumpSE;  //ジャンプ時の効果音
    [SerializeField] private AudioClip landSE;  //着水した時の効果音

    /* --- 変数 ---*/

    /* --- private変数 --- */
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //jumpした時にjumpSEにクリップを入れ替えて再生
        if (jumpSE)
        {
            audioSource.clip = jumpSE;
            audioSource.Play();
            isJump = false;
        }

        //着水した時にjumpSEにクリップを入れ替えて再生
        if (landSE)
        {
            audioSource.clip = landSE;
            audioSource.Play();
            isLand = false;
        }
    }
}
