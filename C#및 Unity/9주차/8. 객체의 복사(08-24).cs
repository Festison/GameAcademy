using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ��ü�� ���� : MonoBehaviour
{
    public GameObject bulletObj;
    public GameObject firePointObj;
    GameObject copyObj;

    // ���� ������Ʈ bulletObj�� �����Ϸ���
    // Instantiate(������ ���, ���簡�� ��ġ, ȸ����);
    
    // �ҷ� ������Ʈ�� ������ ��ġ�� ȸ������ ����
    // Istantiate�� �����ؼ� ���ƿ��� ���� ���簡 �� ���ӿ�����Ʈ�̴�.
    copyObj = Instantiate(bulletObj, firePointObj.transform.position, firePointObj.transform.rotation);
    // bulletObj�� firePointObj�� ��ġ�� ȸ���� ������ ���� �����ؼ� ����� ���� ������Ʈ�� ��Ҵ�.
    copyObj.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 10, ForceMode.Impulse);
    // ��ü�� Prefabȭ ���Ѽ� ������ �������� ��ü�� ���� �� ���ִ�.
}
