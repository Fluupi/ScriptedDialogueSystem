using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextTrigger[] textTriggers;

    private void Awake()
    {
        foreach(TextTrigger trigger in textTriggers)
        {
            trigger.onDialogueTrigger.AddListener(Read);
        }
    }

    public abstract void Read(TextStep textRoot);
}
