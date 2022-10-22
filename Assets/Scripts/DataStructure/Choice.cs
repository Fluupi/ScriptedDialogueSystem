using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PNJName_C_Depth_Number", menuName = "DialogOption/Choice")]
public class Choice : TextStep
{
    [Header("Choice Specifics")]
    public List<Answer> choices;
}
