using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpace : MonoBehaviour {
    public UnityEngine.UI.Button button;
    public UnityEngine.UI.Text buttontext;

    private GameController gameController;


    public void SetSpace() {
        if (gameController.playerMove == true) {
            buttontext.text = gameController.GetPlayerside();
            button.interactable = false;
            gameController.EndTurn();
        }
        
    }
    public void SetGameControllerReference(GameController controller) {
        gameController = controller;
    }
}
