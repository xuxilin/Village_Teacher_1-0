using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class time_manager : MonoBehaviour
{
    public static Action OnPartChanged;
    // Start is called before the first frame update
    public static int part {get; private set;}
    private float timeUnit = 1;
    private float timer;
    void Start()
    {
        part = 12;
        timer = timeUnit;
    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
