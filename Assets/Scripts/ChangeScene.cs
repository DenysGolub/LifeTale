using System.Collections;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public GameObject ToLocation;
    public GameObject FromLocation;
    public Vector3 PlayerToPosition;
    public GameObject Player;

    public GameObject FadeInTrans;  // затемнення (чорний екран)
    public GameObject FadeOutTrans; // засвітлення (повернення до нормального)

    public float FadeDuration = 1f; // скільки триває анімація

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(HandleSceneChange());
    }

    private IEnumerator HandleSceneChange()
    {
        // 1. Почати fade-in
        FadeInTrans.SetActive(true);

        // 2. Почекати, поки анімація відбудеться
        yield return new WaitForSeconds(FadeDuration);

        // 3. Переключити локації
        ToLocation.SetActive(true);
        FromLocation.SetActive(false);

        Player.transform.position = PlayerToPosition;

        // 4. Почати fade-out
        FadeInTrans.SetActive(false);
        FadeOutTrans.SetActive(true);

        // 5. Можна дочекатися fade-out, якщо хочеш
        yield return new WaitForSeconds(FadeDuration);

        // 6. Вимкнути fade об'єкти
        FadeOutTrans.SetActive(false);
    }
}
