using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // boxcollider�� ó���� �ƹ��͵� ����Ű�� ���� �ʾҴ�.
    public BoxCollider boxCollider = null;
    public GameObject cube = null;
    public GameObject targetObjFindOfType = null;


    private void Start()
    {
        // GetComponent<BoxCollider>()�� ���� Test������Ʈ�� �� �ִ� ���ӿ�����Ʈ�� ������Ʈ�� �˻��ؼ� boxcollider�� ������ �־� ���.
        boxCollider = GetComponent<BoxCollider>();

        // ������� �������� �Ȱ��� �̸��� ���� ������Ʈ�� ���� �� �־ ����� ����
        cube = GameObject.Find("Cube");

        // �ڽ� �ݶ��̴��� �������ִ� ���ӿ�����Ʈ�� ã�ƿ´�.
        // �ȿ��ִ� ������Ʈ�� �ϳ��ϳ� ���� Ȯ���Ѵ�.
        targetObjFindOfType = GameObject.FindObjectOfType<BoxCollider>().gameObject;

    }

    private void Update()
    {
        // boxCollider�� ���ؼ� ���ӿ�����Ʈ�� ������ �� �ִ�.
        Destroy(boxCollider.gameObject);
    }





}
