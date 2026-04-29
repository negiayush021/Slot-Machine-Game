using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }


    public ReelController[] controllers;
    public bool hasEvaluated = false;

    private void Update()
    {
        if (hasEvaluated) return;

        bool allfinished = true;
        foreach(var controller in controllers)
        {
            if (!controller.spinningfinish)
            {
                allfinished = false;
                break;
            }
        }

        if (allfinished)
        {
            hasEvaluated = true;
            HandleScript.instance.HandleButton.interactable = true;
            WinEvaluator();
        }
    }
    public void WinEvaluator()
    {
        int reelIndex = 0;

        for (int i = 0; i < controllers.Length; i++)
        {
            if (reelIndex == 0)
                reelIndex = controllers[i].index;
            else if (reelIndex == controllers[i].index)
                continue;
            else
            {
                reelIndex = -1;
                break;
            } 
        }

        if(reelIndex >= 0)
        {
            Debug.Log("You Win Jackpot !!");
        }
        else
        {
            Debug.Log("No Win");
        }
    }

    /*IEnumerator ShowWinningJackpot()
    {

    }*/
}
