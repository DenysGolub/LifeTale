using System;
using TMPro;
using UnityEngine;

public class CheckQuestProgress : MonoBehaviour
{
    DialogueManager dialogueManager;
    TextMeshProUGUI textQuest;
    void Start()
    {
        textQuest = GetComponent<TextMeshProUGUI>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        textQuest.text = Convert.ToString(dialogueManager.GetVariable("quest_count"));
    }
}
