using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestProgress
{
    public Quest quest;
    public List<QuestObjectives> objectives;

    public QuestProgress(Quest quest)
    {
        this.quest = quest;
        objectives = new List<QuestObjectives>();

        //Deep copy to avoid modifying original
        foreach (var obj in quest.objectives)
        {
            objectives.Add(new QuestObjectives
            {
                objectiveID = obj.objectiveID,
                description = obj.description,
                type = obj.type,
                requiredAmount = obj.requiredAmount,
                currentAmount = 0
            });
        }
    }

    public bool IsCompleted => objectives.TrueForAll(o => o.IsCompleted);

    public string QuestID => quest.questID;
}

