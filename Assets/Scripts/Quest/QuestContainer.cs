using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(menuName = "Quests/Quest")] 
public class QuestContainer : ScriptableObject
{
    public string questID;
    public string questName;
    public string description;
    public List<QuestObjective> objectives;

    private void OnEnable()
    {
        if (string.IsNullOrEmpty(questID))
        {
            questID = questName + Guid.NewGuid().ToString();
        }
    }

    [System.Serializable]
    public class QuestObjective
    {
        public string objectiveID; //Match with ID of objective
        public string description;
        public ObjectiveType type;
    }

    public enum ObjectiveType { CollectItem, DefeatEnemy, Custom}

}
