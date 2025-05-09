using UnityEngine;
using UnityEngine.UI;

public class Fight : MonoBehaviour
{

    public GameObject enemy;
    private Animator enemyAnimator;
    public Slider enemyhealthSlider;
    private int attackValue = 5;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyAnimator = enemy.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AttackEnemy()
    {
        enemyhealthSlider.value -= attackValue;
        attackValue += 25;
    }


    public void PlayAttack()
    {
        AttackEnemy();
        enemyAnimator.Play("Def");
        enemyAnimator.Play("Ghost_Attack1", 0, 0f);
    }

}
