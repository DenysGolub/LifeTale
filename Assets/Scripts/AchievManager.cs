using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AchievManager : MonoBehaviour
{
    public GameObject azkabanQuestIcon;
    public GameObject cassettesFoundIcon;
    public GameObject foxesMetIcon;
    public GameObject achievText;

    void Start()
    {
        if (PlayerPrefs.GetInt("quest_fox", 0) == 1)
            ActivateAchievement(azkabanQuestIcon);

        if (PlayerPrefs.GetInt("quest_casettes_ended", 0) == 1)
            ActivateAchievement(cassettesFoundIcon);

        if (PlayerPrefs.GetInt("has_met_foxes", 0) == 1)
            ActivateAchievement(foxesMetIcon);
    }

    void ActivateAchievement(GameObject achiev)
    {
        var butt = achiev.GetComponent<Image>();
        var tempColor = butt.color;
        tempColor.a = 1f;
        butt.color = tempColor;
    }

    public void OnAchievementClick()
    {        
        achievText.GetComponent<TextMeshProUGUI>().text = GameObject.Find(EventSystem.current.currentSelectedGameObject.name).GetComponent<Button>().name;
    }

    public void toMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    
}
