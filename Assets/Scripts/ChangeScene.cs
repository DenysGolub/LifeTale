using System.Collections;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public GameObject ToLocation;
    public GameObject FromLocation;
    public Vector3 PlayerToPosition;
    public GameObject Player;

    public GameObject FadeInTrans;  // ���������� (������ �����)
    public GameObject FadeOutTrans; // ���������� (���������� �� �����������)

    public float FadeDuration = 1f; // ������ ����� �������

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(HandleSceneChange());
    }

    private IEnumerator HandleSceneChange()
    {
        // 1. ������ fade-in
        FadeInTrans.SetActive(true);

        // 2. ��������, ���� ������� ����������
        yield return new WaitForSeconds(FadeDuration);

        // 3. ����������� �������
        ToLocation.SetActive(true);
        FromLocation.SetActive(false);

        Player.transform.position = PlayerToPosition;

        // 4. ������ fade-out
        FadeInTrans.SetActive(false);
        FadeOutTrans.SetActive(true);

        // 5. ����� ���������� fade-out, ���� �����
        yield return new WaitForSeconds(FadeDuration);

        // 6. �������� fade ��'����
        FadeOutTrans.SetActive(false);
    }
}
