using UnityEngine;
using Ink.Runtime;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextAsset inkJSON;
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;

    private Story story;

    void Start()
    {
        story = new Story(inkJSON.text);
        dialoguePanel.SetActive(false);
        //StartDialogue();
    }

    public void StartDialogue()
    {
        dialoguePanel.SetActive(true);
        story.ChoosePathString("start");
        ContinueStory();
    }

    void Update()
    {
        if (dialoguePanel.activeInHierarchy && Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
        }
    }


    public void ContinueStory()
    {
        if (story.canContinue)
        {
            dialogueText.text = story.Continue();
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }

    public void SetVariable(string varName, object value)
    {
        story.variablesState[varName] = value;
    }

    public object GetVariable(string varName)
    {
        return story.variablesState[varName];
    }
}
