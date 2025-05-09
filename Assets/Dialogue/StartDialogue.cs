using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Dialogue start");
            TriggerDialogue();
        }
    }

    void TriggerDialogue()
    {
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        if (dialogueManager != null)
        {
            dialogueManager.StartDialogue();
        }
        else
        {
            Debug.LogWarning("DialogueManager не знайдено в сцені!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter collider");
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Гравець поруч з NPC. Натисни E для взаємодії.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
