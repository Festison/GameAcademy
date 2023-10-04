using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �̱��� ���� : �޸����� �� ������ ������ ������ ���� ��ü�� �ν��Ͻ��� ���� 1���� �����ǰ��ϴ� �����̴�.
// ����Ƽ������ ����ȯ�� ���� ���ο� �����͸� �ҷ����� ������ ������ �ִ� �����Ͱ� �ϳ��� �����ϵ��� �̱��� ������ �̿��Ѵ�.
// �̱��� ������ �������� �Ŵ����� ������ֱ� ���ؼ� ���׸� ���
// where�� ����� �̱����� ��ӹ޴� Ŭ������ TŸ�Կ� �� �� �ִٴ� ���ѻ����� �ɾ��ݴϴ�.
public class SingleTon<T> : MonoBehaviour where T : SingleTon<T>
{
    // T�� ������� ������ Ÿ���� ����.
    public static T instance = null;

    // ����� ���� ���������ڸ� protected�� ����
    protected void Awake()
    {
        // �ν��ͽ��� ���������
        if (instance == null)
        {
            // ���� �ٸ� �ν��Ͻ����� �־��ֱ� ���ؼ� ĳ������ ���ؼ� �ν��Ͻ��� Ÿ���� �־��ش�.
            instance = (T)this;
            DontDestroyOnLoad(gameObject);
        }
        // �ν��Ͻ��� �̹� ������
        else
        {
            // ��ü�� �ν��Ͻ��� 1���� �����ǰ� �ϱ� ���� �ı�
            Destroy(this.gameObject);
        }

        Debug.Log("�̱��� ����");
    }
}
