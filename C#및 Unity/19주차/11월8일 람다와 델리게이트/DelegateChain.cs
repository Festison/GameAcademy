using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DelegateChain : MonoBehaviour
{
    public Action customDel = null;

    // delegateChain�� ���ؼ� ������ �Լ��� ���ÿ� ȣ��
    private void Start()
    {
        customDel += FooOne;
        customDel += FooTwo;
        customDel += FooThree;
        customDel();
    }

    public void FooOne()
    {
        Debug.Log("1");
    }
    public void FooTwo()
    {
        Debug.Log("2");
    }
    public void FooThree()
    {
        Debug.Log("3");
    }
}
