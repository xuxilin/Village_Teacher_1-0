using UnityEngine;
using UnityEngine.Events;

public class player_move : MonoBehaviour

{
    public Animator animator;
    public float speed = 10;
    bool facingLeft;
    Vector2 move;
    Vector3 rotate;

    private void FixedUpdate()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        if (move.x != 0)
        {
            animator.SetBool("moving", true);
            if (move.x > 0)
            {
                animator.SetBool("facingLeft", false);
            }
            else
            {
                animator.SetBool("facingLeft", true);
            }
        }
        else
        {
            animator.SetBool("moving", false);
        }



        if (move.x < 0)
        {
            //transform.localRotation = Quaternion.Euler(0, -180.0f, 0);
        }
        else

        {
            //transform.localRotation = Quaternion.Euler(0, 180.0f, 0);
        }
        // transform.rotation = Quaternion.LookRotation(move);
       // transform.localRotation = Quaternion.Euler(0, -180.0f, 0);
        transform.Translate(move * speed * Time.deltaTime);
    }
    

}