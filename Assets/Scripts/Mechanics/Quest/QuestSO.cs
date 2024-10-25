using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quests/Quest")]
public class QuestSO : ScriptableObject, IQuest
{
    [SerializeField] private string questName;
    [SerializeField] private string description;
    [SerializeField] private bool isCompleted;

    public string QuestName => questName;
    public string Description => description;
    public bool IsCompleted => isCompleted;

    public void CompleteQuest()
    {
        isCompleted = true;
        Debug.Log(" вест завершен: " + questName);
    }
}

