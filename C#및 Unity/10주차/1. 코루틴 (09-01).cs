using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 1. �ڷ�ƾ : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CoolTimeCo());
    }

    void Update()
    {
        // �����̽��� ������ ���� ���� �ٸ� �����ƾ�� �ڷ�ƾ�� ȣ��
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(CoolTimeCo());
        }
    }

    IEnumerator CoolTimeCo()
    {
        while (true)
        {
            Debug.Log("�ڷ�ƾ �׽�Ʈ1");

            // yield return + ���� : return�� �ٸ��� ������ ���� �ҽ� �ٽ� �ڷ�ƾ �Լ������� ���ƿ´�.

            // 1. yield return null; : ���� �����ӿ� ���� ��.
            // 2. yield return new WaitForSeconds(float);  : ����Ƽ �ð� �Ű������� �Է��� ���ڿ� �ش��ϴ� �ʸ� ŭ ��ٷȴٰ� �����.
            // 3 .yield return new WaitForSecondsRealtime(flaot);  : ���� �ð� �Ű������� �Է��� ���ڿ� �ش��ϴ� �ʸ�ŭ ��ٷȴٰ� �����.

            // �ڷ�ƾ�� ���� : �ڷ�ƾ���� �ݺ����� ����ϸ� Update�ʹ� ������ �����ϱ� ������ ��� ��ũ��Ʈ�� ���������� �����ϰ� �ȴ�.
            yield return new WaitForSeconds(1);
        }
    }
}
