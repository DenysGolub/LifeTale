using UnityEngine;

public class AppleCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.SetVariable("got_apple", true);
        this.gameObject.SetActive(false);
    }
}
