using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class QuestUIController : MonoBehaviour
{
    [Header("Quests")]
    public Transform questListContent;
    public GameObject questEntryPrefab;

    [Header("Objective")]
    public GameObject ObjectiveTextPrefab;

    [Header("testing")]
    public Quest testQuest;
    public int testQuestAmount;
    private List<QuestProgress> testQuests = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < testQuestAmount; i++)
        {
            testQuests.Add(new QuestProgress(testQuest));
        }

        UpdateQuestUI();
    }

    public void UpdateQuestUI()
    {
        //Destroys existing quest entries
        foreach (Transform child in questListContent)
        {
            Destroy(child.gameObject);
        }


        //Builds quest entries
        foreach (var quest in testQuests)
        {
            GameObject entry = Instantiate(questEntryPrefab, questListContent);
            TMP_Text questNameText = entry.transform.Find("QuestName").GetComponent<TMP_Text>();
            Transform objectiveList = entry.transform.Find("ObjectiveList");

            questNameText.text = quest.quest.name; 

            foreach (var objective in quest.objectives)
            {
                GameObject ObjectiveTextGameObject = Instantiate(ObjectiveTextPrefab, objectiveList);
                TMP_Text objectiveText = ObjectiveTextGameObject.GetComponent<TMP_Text>();
                objectiveText.text = $"{objective.description} ({objective.currentAmount} / {objective.requiredAmount})"; //example: Kill 5 enemies 0 / 5
            }

        }
    }
}
