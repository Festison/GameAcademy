using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f;

    void Start()
    {
        // Vector3.zero�� static ��� ����
        // static ��ü�� ���α׷��� ����Ǳ� ������ �޸𸮸� �������� �ʰ� ��ü�� �������� �ʰ� ����� ������ �����ϴٴ� ������ �ִ�.

        transform.position = Vector3.zero;
    }

    void Update()
    {
        // transform ������Ʈ : ��� ������Ʈ�� �޷� ������ ������Ʈ�� ��ġ, ȸ��, ũ�⸦ ������ �� �ִ�. 
        // Translate�Լ� ������� : ���� ��ǥ�踦 �̿��� ���� �������� ������Ʈ�� �̵���Ű�ų� ���� �������� ������Ʈ�� �̵���Ű�� ����
        // �Լ��� ���� : public void Translate(Vector3 translation, [DefaultValue("Space.Self")] Space relativeTo)

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.localScale = Vector3.one * 2;
        }
    }
}
