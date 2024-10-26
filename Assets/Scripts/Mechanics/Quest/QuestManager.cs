using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; private set; } // Singleton

    [SerializeField] private List<QuestSO> quests = new List<QuestSO>();
    [SerializeField] private GameObject questItemPrefab;  // Префаб строки задания
    [SerializeField] private Transform contentParent;     // Content объекта Scroll View

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Удаляем дублирующийся объект QuestManager
        }
    }

    public void ShowActiveQuestsInScrollView()
    {
        // Удаляем старые элементы списка (если они были)
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        // Создаем строку для каждого задания
        foreach (var quest in quests)
        {
            GameObject questItem = Instantiate(questItemPrefab, contentParent);

            // Получаем дочерние компоненты TextMeshProUGUI
            TextMeshProUGUI questNameText = questItem.transform.Find("TaskName").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI questDescriptionText = questItem.transform.Find("TaskDescription").GetComponent<TextMeshProUGUI>();

            // Устанавливаем название и описание задания
            questNameText.text = quest.QuestName;
            questDescriptionText.text = $"{quest.Description} - {GetQuestStatusText(quest)}";
        }
    }

    private string GetQuestStatusText(QuestSO quest)
    {
        return quest.Status == QuestStatus.Completed ? "Завершено" : "В процессе";
    }

    public void CompleteQuest(string questName)
    {
        QuestSO quest = quests.Find(q => q.QuestName == questName);
        if (quest != null && quest.Status == QuestStatus.InProgress)
        {
            quest.Status = QuestStatus.Completed;
            ShowActiveQuestsInScrollView(); // Обновляем отображение квестов
        }
    }
}
