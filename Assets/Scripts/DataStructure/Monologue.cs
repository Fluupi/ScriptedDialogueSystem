using UnityEngine;

[CreateAssetMenu(fileName = "PNJName_M_Depth_Number", menuName = "DialogOption/Monologue")]
public class Monologue : TextStep
{
    [Header("Monologue Specifics")]
    public string[] additionalMonologueSteps;

    public TextStep next;
}
