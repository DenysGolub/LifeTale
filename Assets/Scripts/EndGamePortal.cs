using UnityEngine;
using UnityEngine.SceneManagement;

public class endGamePortal : MonoBehaviour
{
    DialogueManager dialogueManager;
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerPrefs.SetInt("quest_fox", (bool)dialogueManager.GetVariable("quest_fox") ? 1 : 0);
        PlayerPrefs.SetInt("quest_casettes_ended", (bool)dialogueManager.GetVariable("quest_casettes_ended") ? 1 : 0);
        PlayerPrefs.SetInt("has_met_foxes", (bool)dialogueManager.GetVariable("has_met_foxes") ? 1 : 0);
        PlayerPrefs.Save();

        SceneManager.LoadSceneAsync("EndGame");
    }

    string endFlag = "is_end_game";
    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }
    void Update()
    {
        if ((bool)dialogueManager.GetVariable(endFlag))
        {
            gameObject.SetActive(true);
        }
    }

}
