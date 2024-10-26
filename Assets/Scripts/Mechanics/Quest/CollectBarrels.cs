using UnityEngine;

public class CollectBarrels : MonoBehaviour
{
    public string collectTag; // Тэг для проверки
    public int amountToCollect; // Количество предметов для сбора
    public string questName; // Название квеста, который выполняется

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, собрал ли игрок предмет с нужным тегом
        if (other.CompareTag(collectTag) && amountToCollect > 0)
        {
            Destroy(other.gameObject); // Уничтожаем собранный объект
            amountToCollect--; // Уменьшаем счетчик собранных предметов

            // Проверяем, если все предметы собраны
            if (amountToCollect <= 0)
            {
                QuestManager.Instance.CompleteQuest(questName); // Завершаем квест
            }
        }
    }
}
