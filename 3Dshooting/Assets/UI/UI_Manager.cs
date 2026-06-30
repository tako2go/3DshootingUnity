using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject UI_Dialogue;
    private CanvasGroup UI_Dialogue_Group;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        UI_Dialogue_Group = UI_Dialogue.GetComponent<CanvasGroup>();
    }
    void Update()
    {
        if (gameManager.nowGamePhase == GameManager.GamePhase.talk)//現在会話シーンだった場合
        {
            UI_Dialogue_Group.alpha = 1;
        }
        else
        {
            UI_Dialogue_Group.alpha = 0;
        }
    }
}
