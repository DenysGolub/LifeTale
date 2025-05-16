using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    private bool playerInRange = false;
    public string knot = "start";
    public GameObject dialoguePanel;

    void Update()
    {
        if (!dialoguePanel.activeInHierarchy && playerInRange && (Input.GetKeyDown(KeyCode.E)))
        {
            Debug.Log("Dialogue start");
            TriggerDialogue();
        }
    }

    public void OnDialogueButtonPressed()
    {
        if (!dialoguePanel.activeInHierarchy && playerInRange)
        {
            Debug.Log("Dialogue start (button)");
            TriggerDialogue();
        }
    }

    void TriggerDialogue()
    {
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        var story = dialogueManager.Story;
        if (dialogueManager != null)
        {

            bool metToriel = false;
            bool gotApple = false;

            if (story.variablesState["met_toriel"] != null)
                metToriel = (bool)story.variablesState["met_toriel"];

            if (story.variablesState["got_apple"] != null)
                gotApple = (bool)story.variablesState["got_apple"];

            if (!metToriel)
            {
                dialogueManager.StartDialogue("start");
            }
            else if ((bool)dialogueManager.GetVariable("quest_ingredients_var") == false) 
            {
                dialogueManager.StartDialogue("quest_ingredients");
            }
            else if(!(bool)dialogueManager.GetVariable("quest_ingredients_ended") && gotApple && (bool)dialogueManager.GetVariable("quest_ingredients_var") == true)
            {
                dialogueManager.StartDialogue("return_to_toriel_after_tree");
                Debug.Log("enter dialog");
            }
            else if((bool)dialogueManager.GetVariable("quest_ingredients_ended") && (int)dialogueManager.GetVariable("cassette_count") == 5)
            {
                dialogueManager.StartDialogue("return_with_cassettes");
            }
            
            
            if ((bool)dialogueManager.GetVariable("quest_ingredients_ended") && (bool)dialogueManager.GetVariable("quest_casettes_ended") && !(bool)dialogueManager.GetVariable("has_met_foxes"))
            {
                dialogueManager.StartDialogue("fox_scene");
                return;
            }
            else if ((bool)dialogueManager.GetVariable("has_met_foxes"))
            {
                dialogueManager.StartDialogue("fox_scene_one_action");
                return;
            }


            //dialogueManager.StartDialogue(knot);
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
