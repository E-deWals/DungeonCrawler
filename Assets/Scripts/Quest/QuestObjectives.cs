using UnityEngine;

[System.Serializable]
public class QuestObjectives
{
    public string objectiveID; //Match with ID of objective
    public string description;
    public EObjectiveType type;
    public int requiredAmount;
    public int currentAmount;

    public bool IsCompleted => currentAmount >= requiredAmount;
}
