using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject topRightLimitGameObject;
    public GameObject bottomLeftLimitGameObject;

    private Vector3 topRightLimit;
    private Vector3 bottomLeftLimit;

    // Start is called before the first frame update
    void Start()
    {
        topRightLimit = topRightLimitGameObject.transform.position;
        bottomLeftLimit = bottomLeftLimitGameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
