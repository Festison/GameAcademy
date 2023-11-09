using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 11�� 08�� �������� �н� ���� : delegate, Lambda
public class Delegate : MonoBehaviour
{
    // delegate �븮�� 
    // Ư�� �Ű� ���� ��� �� ��ȯ ������ �ִ� �Լ��� ���� ����
    // C++������ �Լ� �����Ϳ� ����.

    // delegate�� ���ؼ� �Լ��� ����ó�� ���氡��
    // delegate�� ���������� ���� ���簡 �Ͼ��.
    public delegate void CustomFoo();
    public CustomFoo customFoo = null;

    // �Ű������� ���� ��ȯ Ÿ�Ե� ���� delegate ���ø� : Action
    public Action action;
    // �Ű������� ��ȯ Ÿ���� ���׸����� �����ִ� delegate ���ø� : Func 
    // �������� �ִ� bool�� ��ȯ��, �� ���� ������ �Ű������̴�.
    public Func<int, bool> func;

    private void Start()
    {
        // �Լ� ����
        customFoo = Foo;
        // �Լ� ȣ��
        customFoo();
    }

    public void Foo()
    {
        Debug.Log("�Լ� ȣ��");
    }
}
