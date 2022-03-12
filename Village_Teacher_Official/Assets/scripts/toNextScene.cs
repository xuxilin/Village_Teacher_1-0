using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class toNextScene : MonoBehaviour
{
    
    private int nextSceneToLoad;

    private void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex+1;
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    
    {
        //print("is trigger");
        SceneManager.LoadScene(nextSceneToLoad);
    }
}
