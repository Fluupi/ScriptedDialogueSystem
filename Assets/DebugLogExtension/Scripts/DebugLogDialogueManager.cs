using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLogDialogueManager : DialogueManager
{
    [SerializeField] private float timingBetweenSteps;
    [SerializeField] private float timer;

    private bool hasStartedReading = false;

    [SerializeField] private TextStep currentStep;
    [SerializeField] private int stepProgress;

    private KeyCode[] numCodes =
    {
        KeyCode.Keypad1,
        KeyCode.Keypad2,
        KeyCode.Keypad3,
        KeyCode.Keypad4,
        KeyCode.Keypad5,
        KeyCode.Keypad6,
        KeyCode.Keypad7,
        KeyCode.Keypad8,
        KeyCode.Keypad9
    };

    public override void Read(TextStep textRoot)
    {
        Debug.Log(textRoot.baseText);
        currentStep = textRoot;
        hasStartedReading = true;

        if (currentStep == null || !(currentStep is Choice))
            return;

        Choice c = (Choice)currentStep;
        Debug.Log("");

        for(int i=0; i<c.choices.Count; i++)
        {
            Debug.Log($"{i+1} - {c.choices[i].text}");
        }
    }

    private void Start()
    {
        stepProgress = -1;
    }

    private void Update()
    {
        if (!hasStartedReading)
            return;

        if (timer > 0)
            timer -= Time.deltaTime;

        if(timer <= 0)
        {
            switch(currentStep)
            {
                case Monologue m:
                    if(Input.GetKeyDown(KeyCode.Space))
                    {
                        stepProgress++;
                        if (stepProgress < m.additionalMonologueSteps.Length)
                            Debug.Log($"{stepProgress} -> {m.additionalMonologueSteps[stepProgress]}");
                        else
                            NextStep(m.next);
                    }
                    break;
                case Choice c:
                    {
                        for(int i=0; i<c.choices.Count; i++)
                            if(Input.GetKeyDown(numCodes[i]))
                                NextStep(c.choices[i].next);
                    }
                    break;
            }
        }
    }

    private void NextStep(TextStep step)
    {
        currentStep = step;

        if (currentStep == null)
        {
            hasStartedReading = false;
            return;
        }

        stepProgress = -1;
        Read(currentStep);
    }
}
