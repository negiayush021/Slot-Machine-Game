using System;
using UnityEngine;

public class HandleScript : MonoBehaviour
{
    public static event Action OnHandleTrigger;

    public void TriggerHandle()
    {
        OnHandleTrigger?.Invoke();

        Animator an = GetComponent<Animator>();
        an.Play("Handle Down and Up");
    }
}
