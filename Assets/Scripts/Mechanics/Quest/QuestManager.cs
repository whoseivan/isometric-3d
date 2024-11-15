using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; private set; } // Singleton

    [SerializeField] private List<QuestSO> quests = new List<QuestSO>();
    [SerializeField] private GameObject questItemPrefab;  // ������ ������ �������
    [SerializeField] private Transform contentParent;     // Content ������� Scroll View

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // ������� ������������� ������ QuestManager
        }
    }

    public void ShowActiveQuestsInScrollView()
    {
        // ������� ������ �������� ������ (���� ��� ����)
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        // ������� ������ ��� ������� �������
        foreach (var quest in quests)
        {
            GameObject questItem = Instantiate(questItemPrefab, contentParent);

            // �������� �������� ���������� TextMeshProUGUI
            TextMeshProUGUI questNameText = questItem.transform.Find("TaskName").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI questDescriptionText = questItem.transform.Find("TaskDescription").GetComponent<TextMeshProUGUI>();

            // ������������� �������� � �������� �������
            questNameText.text = quest.QuestName;
            questDescriptionText.text = $"{quest.Description} - {GetQuestStatusText(quest)}";
        }
    }

    private string GetQuestStatusText(QuestSO quest)
    {
        return quest.Status == QuestStatus.Completed ? "���������" : "� ��������";
    }

    public void CompleteQuest(string questName)
    {
        QuestSO quest = quests.Find(q => q.QuestName == questName);
        if (quest != null && quest.Status == QuestStatus.InProgress)
        {
            quest.Status = QuestStatus.Completed;
            ShowActiveQuestsInScrollView(); // ��������� ����������� �������
        }
    }
}
