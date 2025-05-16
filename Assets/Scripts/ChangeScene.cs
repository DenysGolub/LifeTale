using System.Collections;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public GameObject ToLocation;
    public GameObject FromLocation;
    public Vector3 PlayerToPosition;
    public GameObject Player;
    public bool isFading = true;

    public GameObject FadeInTrans; 
    public GameObject FadeOutTrans; 

    public float FadeDuration = 1f; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(HandleSceneChange());
    }

    private IEnumerator HandleSceneChange()
    {
        if(isFading)
        {
            FadeInTrans.SetActive(true);

            yield return new WaitForSeconds(FadeDuration);

            ToLocation.SetActive(true);
            FromLocation.SetActive(false);

            Player.transform.localPosition = PlayerToPosition;

            FadeInTrans.SetActive(false);
            FadeOutTrans.SetActive(true);

            yield return new WaitForSeconds(FadeDuration);

            FadeOutTrans.SetActive(false);
        }
        else
        {
            ToLocation.SetActive(true);
            Player.transform.localPosition = PlayerToPosition;
        }

    }
}
