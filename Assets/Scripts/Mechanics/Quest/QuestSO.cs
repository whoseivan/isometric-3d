using UnityEngine;

public enum QuestStatus
{
    InProgress,
    Completed
}

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class QuestSO : ScriptableObject
{
    public string QuestName;
    public string Description;
    public QuestStatus Status = QuestStatus.InProgress; // ���������� ����� � ��������

    public void CompleteQuest()
    {
        Status = QuestStatus.Completed;
    }
}
