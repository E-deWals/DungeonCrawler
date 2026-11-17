using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestSO", menuName = "Scriptable Objects/QuestSO")]
public class QuestSO : ScriptableObject
{
    public string questname;
    public TMP_Text QuestText;
    public int AmountToComplete;
    public int XPOnCompletion;
    
}
