using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class player_move : MonoBehaviour

{
    Rigidbody2D rigidbody2d;
    public GameObject interactableIcon;
    public Animator animator;
    public float speed = 10;
    bool facingLeft;
    Vector2 move;
    Vector3 rotate;
    private Vector2 boxSize = new Vector2(0.1f, 1f);

    //Stay Inside script objects
    public GameObject topRightLimitGameObject;
    public GameObject bottomLeftLimitGameObject;


    private Vector3 topRightLimit;
    private Vector3 bottomLeftLimit;



    void Start()
    {
        topRightLimit = topRightLimitGameObject.transform.position;
        bottomLeftLimit = bottomLeftLimitGameObject.transform.position;

        if (!Save_and_load_system.instance.has_load) {
            Save_and_load_system.instance.SaveD.scene_num = 0;
        }
        //Debug.Log("_________________________________________________________________________________________");
        rigidbody2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckInteraction();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S hited");
            Save_and_load_system.instance.SaveD.scene_num = SceneManager.GetActiveScene().buildIndex;
            Save_and_load_system.instance.SaveD.player_location = transform.position;
            Save_and_load_system.instance.SaveD.loaded = true;
            Save_and_load_system.instance.Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("L hited");
            //Save_and_load_system.instance.Load();
            //SceneManager.LoadScene(Save_and_load_system.instance.SaveD.scene_num);
            Save_and_load_system.instance.Load();
            Debug.Log("L hit 2");
            if (Save_and_load_system.instance.SaveD.loaded)
            {
                Debug.Log("In_checker");
                Debug.Log(transform.position);
                while (transform.position != Save_and_load_system.instance.SaveD.player_location)
                {
                    Debug.Log("Checker?");
                    //transform.position = Save_and_load_system.instance.SaveD.player_location;
                    tested();
                }
                Save_and_load_system.instance.SaveD.loaded = false;
                Save_and_load_system.instance.Save();
                Debug.Log(transform.position);
            }


        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("C hited");
            Save_and_load_system.instance.Delete();
        }
        
        //Debug.Log(transform.position);
        



    }
    public void tested() {
        transform.position = Save_and_load_system.instance.SaveD.player_location;

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
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
        rigidbody2d.MovePosition(transform.position);
    }
    
    public void OpenInteractableIcon()
    {
        interactableIcon.SetActive(true);
    }

    public void CloseInteractableIcon()
    {
        interactableIcon.SetActive(false);
    }

    private void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position,boxSize,0,Vector2.zero);

        if(hits.Length > 0)
        {
            foreach(RaycastHit2D rc in hits)
            {
                if(rc.isInteractable())
                {
                    rc.Interact();
                    return;
                }
            }
        }
    }

}