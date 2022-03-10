using UnityEngine;
using UnityEngine.Events;

public class player_move : MonoBehaviour

{
    public Animator animator;
    public float speed = 10;
    bool facingLeft;
    Vector2 move;
    Vector3 rotate;

    //Stay Inside script objects
    public GameObject topRightLimitGameObject;
    public GameObject bottomLeftLimitGameObject;

    private Vector3 topRightLimit;
    private Vector3 bottomLeftLimit;

    void Start()
    {
        topRightLimit = topRightLimitGameObject.transform.position;
        bottomLeftLimit = bottomLeftLimitGameObject.transform.position;
    }

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
      
        transform.Translate(move * speed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }
    

}