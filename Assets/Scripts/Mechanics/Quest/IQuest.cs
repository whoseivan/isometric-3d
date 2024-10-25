public interface IQuest
{
    string QuestName { get; }
    string Description { get; }
    bool IsCompleted { get; }
    void CompleteQuest();
}
