using UnityEngine;
using Ink.Runtime;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextAsset inkJSON;
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;

    private Story story;
    public GameObject battleCanvas;
    public GameObject worldExploringParent;

    public GameObject Toriel;
    public GameObject Flowey;

    public GameObject apple;
    public GameObject[] cassettes; 

    private Vector3 flowey_position = new Vector3(15, 16.96f);
    private Vector3 toriel_position_enter = new Vector3(11.86f, -33.76f, -3.594692f);
    private Vector3 toriel_position_out = new Vector3(-1.1f, 35.3f, -3.594692f);


    bool isEscaping = false;
    bool isTorielOut = false;

    public GameObject toFoxesTeleport;

    public AudioSource foxLaughSource;
    public GameObject endPortal;

    public Story Story { get => story; set => story = value; }

    void Start()
    {

        Story = new Story(inkJSON.text);
        dialoguePanel.SetActive(false);
        //StartDialogue();

        Story.BindExternalFunction("StartFight", () => {
            battleCanvas.SetActive(true);
            worldExploringParent.SetActive(false);

            //isInBattle = true;
        });

        Story.BindExternalFunction("SpawnTorielAndDisableFlowey", () => 
        {
            Flowey.transform.localPosition = flowey_position;
            Toriel.SetActive(true);

            Toriel.transform.localPosition = toriel_position_enter;
            //worldExploringParent.SetActive(true);

            //isInBattle = true;
        });

        Story.BindExternalFunction("SpawnTorielAtHome", () =>
        {
            Toriel.transform.localPosition = toriel_position_out;
            dialoguePanel.SetActive(false);
        });

        Story.BindExternalFunction("SpawnApple", () =>
        {
            apple.SetActive(true);
        });

        Story.BindExternalFunction("SpawnCasettes", () =>
        {
            foreach(var c in cassettes)
            {
                c.gameObject.SetActive(true);
            }
        });

        Story.BindExternalFunction("StartFox", () =>
        {
            toFoxesTeleport.SetActive(true);
        });

        Story.BindExternalFunction("PlayFoxLaugh", () =>
        {
            foxLaughSource.Play();
        });
        Story.BindExternalFunction("SpawnEndPortal", () =>
        {
            endPortal.SetActive(true);
        });


        PlayerPrefs.SetInt("quest_fox", (bool)GetVariable("quest_fox") ? 1 : 0);
        PlayerPrefs.SetInt("quest_casettes_ended", (bool)GetVariable("quest_casettes_ended") ? 1 : 0);
        PlayerPrefs.SetInt("has_met_foxes", (bool)GetVariable("has_met_foxes") ? 1 : 0);
        PlayerPrefs.Save();

    }

    public void StartDialogue(string knot="start")
    {

        dialoguePanel.SetActive(true);
        Story.ChoosePathString(knot);
        ContinueStory();
    }


   


    void Update()
    {
        if (dialoguePanel.activeInHierarchy && Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
        }
    }

    public void OnDialogueButtonPressed()
    {
        if (dialoguePanel.activeInHierarchy)
        {
            ContinueStory();
        }
    }


    public void ContinueStory()
    {
        if (Story.canContinue)
        {
            dialogueText.text = Story.Continue();

            if(dialogueText.text == "")
            {
                dialoguePanel.SetActive(false);
            }
        }
        else
        {
            dialogueText.text = "";
            dialoguePanel.SetActive(false);
        }
    }

    public void SetVariable(string varName, object value)
    {
        Story.variablesState[varName] = value;
    }


    public object GetVariable(string varName)
    {
        return Story.variablesState[varName];
    }
}
