using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class KnifeDamage : MonoBehaviour
{
    public Slider healthSlider;
    public GameObject fightRoot;
    public int damageAmount = 5;
    public GameObject textHP;
    private AudioSource audio;
    public GameObject worldExploring;

    public void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Triggered");
        if (collision.gameObject.CompareTag("Player"))
        {
            if (healthSlider != null)
            {
                healthSlider.value -= damageAmount;
                var text = textHP.GetComponent<TextMeshProUGUI>();
                text.text = healthSlider.value.ToString();
                audio.Play();
                if (healthSlider.value <= 1)
                {
                    if (fightRoot != null)
                    {
                        fightRoot.SetActive(false);
                        worldExploring.SetActive(true);
                    }
                }
            }
        }
    }
}
