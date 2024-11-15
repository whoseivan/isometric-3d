using UnityEngine;

public class CollectBarrels : MonoBehaviour
{
    public string collectTag; // ��� ��� ��������
    public int amountToCollect; // ���������� ��������� ��� �����
    public string questName; // �������� ������, ������� �����������

    private void OnTriggerEnter(Collider other)
    {
        // ���������, ������ �� ����� ������� � ������ �����
        if (other.CompareTag(collectTag) && amountToCollect > 0)
        {
            Destroy(other.gameObject); // ���������� ��������� ������
            amountToCollect--; // ��������� ������� ��������� ���������

            // ���������, ���� ��� �������� �������
            if (amountToCollect <= 0)
            {
                QuestManager.Instance.CompleteQuest(questName); // ��������� �����
            }
        }
    }
}
