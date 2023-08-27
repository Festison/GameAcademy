using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    // public�� ���ؼ� �Ҹ� ������Ʈ�� ���ӿ�����Ʈ�� �ν����� â���� ���� �����ϰ� ���ش�.
    public GameObject bulletObj;
    // public�� ���ؼ� ���� ������Ʈ�� Ʈ������ ������Ʈ�� �ν����� â���� ���� �����ϰ� ���ش�.
    public Transform barrelTransform;
    // �ҷ� ������Ʈ�� ������ �ٵ� ���� ����
    Rigidbody bulletRigid;

    void Start()
    {
        // �ҷ� ������Ʈ�� ������ٵ� ������Ʈ�� �����´�.
        bulletRigid = bulletObj.GetComponent<Rigidbody>();
        // �Ҹ�������Ʈ�� �����ǿ� ����������Ʈ�� �������� ������ �Ҹ�������Ʈ�� ��ġ�� �̵�
        bulletObj.transform.position = barrelTransform.position;
        // �Ҹ�������Ʈ�� ������Ʈ�� ����������Ʈ�� ������Ʈ�� ������ �Ҹ�������Ʈ�� ������ ����
        bulletObj.transform.rotation = barrelTransform.rotation;
    }
}
