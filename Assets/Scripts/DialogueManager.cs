using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextTrigger[] textTriggers;

    private void Awake()
    {
        foreach(TextTrigger trigger in textTriggers)
        {
            trigger.onDialogueTrigger.AddListener(Read);
        }
    }

    public void Read(TextStep textRoot)
    {
        Debug.Log(textRoot.baseText);
    }
}
