using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TextTrigger : MonoBehaviour
{
    [SerializeField] private bool triggerOnce;
    [SerializeField] private bool wasTriggered;

    public UnityEvent<TextStep> onDialogueTrigger;
    [SerializeField] private TextStep textRoot;

    public void Trigger()
    {
        if (triggerOnce && wasTriggered)
        {
            Debug.LogWarning("oopsie");

            return;
        }

        if (triggerOnce)
            wasTriggered = true;

        onDialogueTrigger.Invoke(textRoot);
    }
}
