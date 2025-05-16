using UnityEngine;

public class CasetteCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        gameObject.SetActive(false);
        dialogueManager.StartDialogue("collect_cassette");
    }
}
