using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{
    public GameObject dialogTips;
    public GameObject dialogFish;
    public GameObject baitPanel;
    public RubySetting player;
    public Text text1;
    public Text text2;
    public Button bait_A;
    public Button bait_B;
    public Button bait_C;
    public float fishTime = 20.0f;

    bool fishingStatus;
    bool catchFish;
    float timer;
    float timer2;
    int ranNum;
    string fishBait;

    // Start is called before the first frame update
    void Start()
    {
        //set to defualt status
        dialogTips.SetActive(false);
        dialogFish.SetActive(false);
        text1.text = "Press E to fish";
        text2.text = "...fishing...";
        //init varible
        fishingStatus = false;
        catchFish = false;
        timer = -1.0f;
        timer2 = -1.0f;
        ranNum = -1;
        fishBait = "null";
        //init buttons
        Button btnA = bait_A.GetComponent<Button>();
        btnA.onClick.AddListener(ButtonPressedA);
        Button btnB = bait_B.GetComponent<Button>();
        btnB.onClick.AddListener(ButtonPressedB);
        Button btnC = bait_C.GetComponent<Button>();
        btnC.onClick.AddListener(ButtonPressedC);
    }

    // Update is called once per frame
    void Update()
    {
        //if player touches the pool
        if (dialogTips.activeSelf == true) 
        {
            //start fishing game
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                baitPanel.SetActive(true);
                text1.text = "Select the bait";
            }
            //after select bait
            if (fishBait != "null")
            {
                baitPanel.SetActive(false);
                dialogTips.SetActive(false);
                fishingStatus = true;
                timer = fishTime;
            }
        }
        //begin fishing
        if (fishingStatus == true)
        {
            if (timer >= 0)
            {
                dialogFish.SetActive(true);
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    //no fish eats the bait
                    text2.text = "Nothing...";
                    dialogTips.SetActive(true);
                    fishingStatus = false;
                }
                //wait for fish
                if (!catchFish)
                {
                    ranNum = Random.Range(1, 500);
                }
                if (ranNum == 50 && !catchFish)
                {
                    text2.text = "!!!";
                    timer2 = timer;
                    catchFish = true;
                }
                //fish eats the bait
                if (catchFish)
                {
                    //2s no action -> miss fish
                    if (timer2 - timer > 2)
                    {
                        text2.text = "Fish runs away";
                        fishingStatus = false;
                        catchFish = false;
                    }
                    //catch
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        text2.text = "Catch";
                        fishingStatus = false;
                        catchFish = false;
                        player.Fishing(1);
                    }
                }
            }
        }
        

    }

    public void ButtonPressedA()
    {
        fishBait = "A";
        Debug.Log("Bait type: A");
    }
    
    public void ButtonPressedB()
    {
        fishBait = "B";
        Debug.Log("Bait type: B");
    }

    public void ButtonPressedC()
    {
        fishBait = "C";
        Debug.Log("Bait type: C");
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log("Tag: " + coll.gameObject.tag);
        if (coll.gameObject.tag == "Player") 
        {
            dialogTips.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Button btnA = bait_A.GetComponent<Button>();
            btnA.onClick.RemoveListener(ButtonPressedA);
            Button btnB = bait_B.GetComponent<Button>();
            btnB.onClick.RemoveListener(ButtonPressedB);
            Button btnC = bait_C.GetComponent<Button>();
            btnC.onClick.RemoveListener(ButtonPressedC);
            Start();
        }
    }
}
