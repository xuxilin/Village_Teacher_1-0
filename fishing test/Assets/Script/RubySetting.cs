using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubySetting : MonoBehaviour
{
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    public float speed = 3.0f;
    public int maxFishNum = 10;
    int currFishNum;



    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    //Start
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currFishNum = 0;
    }

    //Update
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    public void Fishing(int amount) 
    {
        currFishNum = Mathf.Clamp(currFishNum + amount, 0, maxFishNum);
        Debug.Log("Current Fish Get: " + currFishNum + "/" + maxFishNum);
    }
}
