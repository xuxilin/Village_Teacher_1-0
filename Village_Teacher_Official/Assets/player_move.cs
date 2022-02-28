using UnityEngine;
using UnityEngine.Events;

public class player_move : MonoBehaviour

{
	private Rigidbody2D playerRigidbody;
    public float moveSpeed = 1f;
    public void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();

    
    }

    private void FixedUpdate()
    {
        if (playerRigidbody != null)
        {
            applyInput();
        }
        else
        {
            Debug.LogWarning("Rigid body not attached to player" + gameObject.name);
        }
    }

    public void applyInput()
    {
        float xInput = Input.GetAxis("Horizontal");

        float xForce = xInput * moveSpeed * Time.deltaTime;

        Vector2 force = new Vector2(xForce, 0);
        playerRigidbody.AddForce(force);

        Debug.Log("xForce: " + xForce);
        Debug.Log("Velocity: " + playerRigidbody.velocity.x + "" + playerRigidbody.velocity.y);
    }
}