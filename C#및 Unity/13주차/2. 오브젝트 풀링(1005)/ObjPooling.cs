using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������Ʈ Ǯ�� : ����� ������ �ı��� ���������� �� ȿ�����̴�.
// ���� ���� ����ϴ� ������Ʈ�� �̸� ������ ���� �̰� ����� ������ ���� ���� ���� �ϴ� ���� �ƴ� �̸� ������ ��ü���� ��Ƶ� �ݷ���(Ǯ)�� �����д�.
// ����� ���� ������Ʈ Ǯ���� ������ ����ϰ� ������ ���� ������ƮǮ���� ���������ν� �ܼ��ϰ� ������Ʈ�� Ȱ��ȭ ��Ȱ��ȭ�� �ϴ� �����̴�.

public class ObjPooling : MonoBehaviour
{
    // ������Ʈ Ǯ�� ����
    // 1. �̸� ������ ���ӿ�����Ʈ�� ��Ƶ� �ݷ���(Ǯ)�� �����.
    // 2. ��Ȱ��ȭ ���·� �����ؼ� �ݷ���(Ǯ)�� ��Ƶд�.
    // 3. ����� �� Ȱ��ȭ �Ѵ�.
    // 4. �� ���� ��Ȱ��ȭ ���·� �ݷ���(Ǯ)�� �ٽ� ��Ƶд�.

    public static ObjPooling instance = null;    // static�� �޸��� Ŭ���� ��ü�� ������ ����ƽ �����̴�.
    public Queue<GameObject> pool;               // ������Ʈ Ǯ�� ������ ť
    public GameObject prefab;                    // ������ƮǮ���� ������ ������Ʈ
    public int initSize;                         // �̸� �����ص� ������Ʈ�� ����   

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        pool = new Queue<GameObject>();

        Init();
    }

    // ������ ������Ʈ Ǯ���� �ʱ�ȭ �� �Լ�
    public void Init()
    {
        AddPool(initSize);
    }

    // ���߿� ���� ��Ȱ��ȭ�ϰ� �־��ִ� �Լ�
    public void AddPool(int size)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject temp = null;         // GameObject temp�� ���� null�� ����Ų��.
            temp = Instantiate(prefab);     // Instantiate�� ���ؼ� prefab�� �纻 ���ӿ�����Ʈ�� �����
                                            // temp�� ���� ������� �׳��� �ּҸ� ����Ű�����Ѵ�.
            temp.SetActive(false);          // temp�� ���� ������� ���� ����Ű�������Ƿ� SetActive(false)��
                                            // ���� ������� ������Ʈ�� ��Ȱ��ȭ �Ѵ�.
            pool.Enqueue(temp);             // ���� ��������� ��Ȱ��ȭ �� ���ӿ��������� �ּҸ� ť�� ��´�.
        }
    }

    // ť�� �ִ� ���ӿ�����Ʈ�� ��ġ�� ȸ���� ������ Ȱ��ȭ ��Ű�� �Լ�
    public void PopObj(Vector3 pos, Quaternion rot)
    {
        // ť�� ����ִ� ���ӿ�����Ʈ�� ������ 0 �����Ͻ� �߰��� �־� �ش�.
        if (pool.Count <= 0)
        {
            AddPool(initSize / 2);
        }

        GameObject dequeObj = pool.Dequeue();
        dequeObj.transform.position = pos;
        dequeObj.transform.rotation = rot;
        dequeObj.SetActive(true);
    }

    // �� �� ���ӿ�����Ʈ�� ��Ȱ��ȭ ���� Ǯ�� �־��ش�.
    public void ReturnPool(GameObject returnObj)
    {
        returnObj.SetActive(false);
        pool.Enqueue(returnObj);
    }
}
