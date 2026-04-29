using System;
using UnityEngine;
using UnityEngine.UI;

public class HandleScript : MonoBehaviour
{
    public static HandleScript instance;
    private void Awake()
    {
        instance = this;
    }


    public static event Action OnHandleTrigger;
    public Button HandleButton;
    public void TriggerHandle()
    {
        OnHandleTrigger?.Invoke();

        Animator an = GetComponent<Animator>();
        an.Play("Handle Down and Up");

        GameManager.instance.hasEvaluated = false;
        HandleButton.interactable = false;
    }
}
