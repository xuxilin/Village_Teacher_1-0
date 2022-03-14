using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

[System.Serializable]
public class Player {
    public Image panel;
    public Text text;
    
}
[System.Serializable]
public class PlayerColor
{
    public Color panelColor;
    public Color textColor;

}

public class GameController : MonoBehaviour
{
    public Text[] buttonList;
    
    public GameObject GameOver;
    public Text GameOverText;

    public GameObject Restart;

    public Player playerX;
    public Player playerO;
    public PlayerColor act_playercolor;
    public PlayerColor non_act_playercolor;

    private string playerside;
    private string computerside;
    public bool playerMove;
    public float delay;
    private int value;
    bool wins = false;
    private int count;
    void Awake()
    {
        GameOver.SetActive(false);
        SetGameControllerReferenceOnButton();
        playerside = "X";
        Restart.SetActive(false);
        SetPLayerColor(playerX, playerO);
        playerMove = true;
        computerside = "O";
    }
    /*
    private void Update()//Easy
    {
        if (!playerMove) {
            delay += delay * Time.deltaTime;
            if(delay >= 50){
                value = UnityEngine.Random.Range(0, 8);
                if (buttonList[value].GetComponentInParent<Button>().interactable) {
                    buttonList[value].text = GetComputerside();
                    buttonList[value].GetComponentInParent<Button>().interactable = false;
                    EndTurn();
                }
            }
        }
    }*/
    /*
    private void Update()//HARD
    {
        if (!playerMove && !wins) {
            delay += delay * Time.deltaTime;
            if (delay > 50) {
                value = check_move(buttonList);
                buttonList[value].text = GetComputerside();
                buttonList[value].GetComponentInParent<Button>().interactable = false;
                EndTurn();
            }
           
        }
    }*/
    
    private void Update()//Med
    {
        if (!playerMove && !wins)
        {
            delay += delay * Time.deltaTime;
            if (delay > 50)
            {
                value = check_move1(buttonList);
                buttonList[value].text = GetComputerside();
                buttonList[value].GetComponentInParent<Button>().interactable = false;
                EndTurn();
            }

        }
    }
public int check_move1(Text[] buttonList)
    {
        int Best_score = 0;
        int ret = -1;
        int i = 0;
        int decide = UnityEngine.Random.Range(0, 10);
        Debug.Log("DECIDE: " + decide);
        while (i < 9)
        {
            if (buttonList[i].text == "")
            {
                List<String> temp_grid = DeepCopy(buttonList);
                temp_grid[i] = GetComputerside();
                int temp_score = Minimax(temp_grid, false);
                print("----------------;;;" + temp_score);
                if (decide < 7 && decide > 4 && temp_score == 1)
                {
                    Best_score = temp_score;
                    ret = i;
                }
                else if (decide > 7 && temp_score == -1)
                {
                    Best_score = temp_score;
                    ret = i;
                }
                else if (decide < 7 && temp_score == 0)  {
                    Best_score = temp_score;
                    ret = i;
                }
                i++;
            }
            else
            {
                i++;
            }
        }
        if (ret == -1) {
            for (int k = 0; k < 9; k++) {
                if (buttonList[k].GetComponentInParent<Button>().interactable == true) {
                    ret = k;
                    break;
                }     
            }
        }
        //Debug.Log("The point" + ret);
        return ret;
    }


    public string check_win(List<String> buttonList)
    {
        if (buttonList[0] != "" && buttonList[0] == buttonList[1] && buttonList[1] == buttonList[2])
            return buttonList[0];
        else if (buttonList[3] != "" && buttonList[3] == buttonList[4] && buttonList[4] == buttonList[5])
            return buttonList[3];
        else if(buttonList[6] != "" && buttonList[6] == buttonList[7] && buttonList[7] == buttonList[8])
            return buttonList[6];
        else if(buttonList[0] != "" && buttonList[0] == buttonList[3] && buttonList[3] == buttonList[6])
            return buttonList[0];
        else if(buttonList[1] != "" && buttonList[1] == buttonList[4] && buttonList[4] == buttonList[7])
            return buttonList[1];
        else if(buttonList[2] != "" && buttonList[2] == buttonList[5] && buttonList[5] == buttonList[8])
            return buttonList[2];
        else if(buttonList[0] != "" && buttonList[0] == buttonList[4] && buttonList[4] == buttonList[8])
            return buttonList[0];
        else if(buttonList[2] != "" && buttonList[2] == buttonList[4] && buttonList[4] == buttonList[6])
            return buttonList[2];
        else
        {
            for (int i = 0; i < 9; i++)
            {
                if (buttonList[i] == "")
                {
                    return "NONE";
                }
            }
        }
        return "DRAW";
    }

    public List<String> DeepCopy(Text[] buttonList) {
        List<String> new_list = new List<String>();
        for (int i = 0; i < buttonList.Length; i++) {
            if (buttonList[i].text == "X")
                new_list.Add("X");
            else if (buttonList[i].text == "O")
                new_list.Add("O");
            else {new_list.Add("");}
                
                
        }

        return new_list;
    }
    public int check_move(Text[] buttonList) {
        int Best_score = -50000;
        int ret = -1;
        int i = 0;
        while (i < 9) {
            if (buttonList[i].text == "")
            {
                List<String> temp_grid = DeepCopy(buttonList);
                temp_grid[i] = GetComputerside();
                int temp_score = Minimax(temp_grid, false);
                print("----------------;;;"+temp_score);
                if (Best_score < temp_score)
                {
                    Best_score = temp_score;
                    ret = i;
                }
                i++;
            }
            else {
                i++;
            }
        }
        Debug.Log("The point"+ret);
        return ret;
    }

    public int Minimax(List<String> buttonList,bool AI)
    {
        string check = check_win(buttonList);
        if (check == "X")
            return -1;
        if (check == "O")
            return 1;
        if (check == "DRAW")
            return 0;
        if (AI)
        {
            int temp_score1;
            int best_score1 = -40320;
            for (int i = 0; i < 9; i++)
            {
                if (buttonList[i] == "")
                {
                    buttonList[i] = "O";
                    //Print_grid(buttonList);
                    temp_score1 = Minimax(buttonList, false);
                    buttonList[i] = "";
                    if (best_score1 < temp_score1)
                        best_score1 = temp_score1;
                }
            }
            return best_score1;
        }
        else {
            int temp_score2;
            int best_score2 = 40320;
            for (int i = 0; i < 9; i++) {
                if (buttonList[i] == "")
                {
                    buttonList[i] = "X";
                    //Print_grid(buttonList);
                    temp_score2 = Minimax(buttonList, true);
                    buttonList[i] = "";
                    if (best_score2 > temp_score2 )
                        best_score2 = temp_score2;
                }
            }
            return best_score2;
        }
       
    }
    void SetGameControllerReferenceOnButton() {
        for (int i = 0; i < buttonList.Length; i++) {

            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }
    public string GetPlayerside() {
        return playerside;
    }

    public string GetComputerside()
    {
        return computerside;
    }
    public void EndTurn() {
        count++;
        //Debug.Log("Count " + count);
        if ((buttonList[0].text != "" && buttonList[0].text == buttonList[1].text && buttonList[1].text == buttonList[2].text) ||
            (buttonList[3].text != "" && buttonList[3].text == buttonList[4].text && buttonList[4].text == buttonList[5].text) ||
            (buttonList[6].text != "" && buttonList[6].text == buttonList[7].text && buttonList[7].text == buttonList[8].text) ||
            (buttonList[0].text != "" && buttonList[0].text == buttonList[3].text && buttonList[3].text == buttonList[6].text) ||
            (buttonList[1].text != "" && buttonList[1].text == buttonList[4].text && buttonList[4].text == buttonList[7].text) ||
            (buttonList[2].text != "" && buttonList[2].text == buttonList[5].text && buttonList[5].text == buttonList[8].text) ||
            (buttonList[0].text != "" && buttonList[0].text == buttonList[4].text && buttonList[4].text == buttonList[8].text) ||
            (buttonList[2].text != "" && buttonList[2].text == buttonList[4].text && buttonList[4].text == buttonList[6].text))
        {
            GameEnd();
            GameOver.SetActive(true);
            //Debug.Log("count"+count);
            if(count%2 == 1)
                GameOverText.text = playerside + " Wins";
            else
                GameOverText.text = computerside + " Wins";
            wins = true;
            count = 0;
        }
        else if (count == 9)
        {
            GameEnd();
            GameOver.SetActive(true);
            GameOverText.text = "DRAW";
            count = 0;
        }
        else { delay = 10; ChangeSides(); }
    }

    void SetPLayerColor(Player player1, Player player2) {
        player1.panel.color = act_playercolor.panelColor;
        player2.panel.color = non_act_playercolor.panelColor;
        player1.text.color = act_playercolor.textColor;
        player2.text.color = non_act_playercolor.textColor;
    }

    void GameEnd() {
        for (int i = 0; i < buttonList.Length; i++) {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
        Restart.SetActive(true);
        Debug.Log("Game_End");
    }
    void ChangeSides() {
        //playerside = (playerside == "X") ? "O" : "X";
        playerMove = (playerMove == true) ? false: true;
        //if (playerside == "X")
        if(playerMove)
            SetPLayerColor(playerX, playerO);
        else
            SetPLayerColor(playerO, playerX);
    }
    public void RestartGame() {
        playerside = "X";
        GameOver.SetActive(false);
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = true;
            buttonList[i].text = "";
        }
        SetPLayerColor(playerX, playerO);
        Restart.SetActive(false);
        wins = false;
        playerMove = true;
    }

}
