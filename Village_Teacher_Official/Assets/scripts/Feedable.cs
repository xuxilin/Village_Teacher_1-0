using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Feedable : Interactable
{
   public Sprite Before;
   public Sprite After;

   private SpriteRenderer sr;
   private bool isFed;

    public override void Interact()
    {
        if(isFed)
            sr.sprite = After;
        else
            sr.sprite = Before;

        isFed = !isFed;
    }
   private void Start()
   {
       sr = GetComponent<SpriteRenderer>();
       sr.sprite=Before;
   }
}
