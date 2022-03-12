using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toPreviousLevel : MonoBehaviour
{
    
    private int previousSceneToLoad;

    private void Start()
    {
        previousSceneToLoad = SceneManager.GetActiveScene().buildIndex-1;
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    
    {
        //print("is trigger");
        SceneManager.LoadScene(previousSceneToLoad);
    }
}
