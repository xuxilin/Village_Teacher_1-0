using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_effect_script : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioClip Play_O, Play_X, Begin;
    static AudioSource audiosource;
    void Start()
    {
        Play_O = Resources.Load<AudioClip>("ֽ�澮����/huayuan");
        Play_X = Resources.Load<AudioClip>("ֽ�澮����/huacha");
        Begin= Resources.Load<AudioClip>("ֽ�澮����/huasitiaoxian");

        audiosource = GetComponent<AudioSource>();
        //audiosource.PlayOneShot(Begin);
    }
    /*
    public static void  Play_at_begin() {
        audiosource.PlayOneShot(Begin);
          
    }*/
    public static void Play(string name) {
        switch (name) {
            case "X":
                audiosource.PlayOneShot(Play_X);
                break;
            case "O":
                audiosource.PlayOneShot(Play_O);
                break;
        }
    }
}
