using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public DialogueManager dialogue;

    public void OnPlayerPickedUpKey()
    {
        dialogue.SetVariable("has_key", true);
    }

    public bool IsQuestCompleted()
    {
        return (bool)dialogue.GetVariable("quest_completed");
    }
}
