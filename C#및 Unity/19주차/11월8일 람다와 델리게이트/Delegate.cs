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
    public delegate void CustomFoo();
    public CustomFoo customFoo = null;

    // �Ű������� ���� ��ȯ Ÿ�Ե� ���� delegate ���ø� : Action
    Action action;
    // �Ű������� ��ȯ Ÿ���� ���׸����� �����ִ� delegate ���ø� : Func 
    // �������� �ִ� bool�� ��ȯ��, �� ���� ������ �Ű������̴�.
    Func<int, bool> func;

    private void Start()
    {
        customFoo = Foo;
        customFoo();
    }


    public void Foo()
    {
        Debug.Log("�Լ� ȣ��");
    }

    public void FooTwo()
    {
        Debug.Log("�Լ� ȣ��2");
    }
}
