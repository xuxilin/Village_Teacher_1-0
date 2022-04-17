using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public bool isHappy;
    public Animator animator;
    
    public void beHappy()
    
    {
        if(!isHappy)
        {
            isHappy = true;
            Debug.Log("Cat is happy");
            animator.SetBool("tail_interact",isHappy);
        }
    }

    
}
