using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Person
{
    public static int totalPersonCount = 0;
    public string name;

    public void Die()
    {

    }
}

public static class ExtensionMethod
{
    // public static ����Ÿ�� Ȯ�� �޼���� (this Ȯ���� ������ Ÿ�� value, �Ű�����)
    public static bool IsBetween(this float curValue, float min, float max)
    {
        return curValue > min && curValue < max;
    }
    // �ǽ� Clamp ��� �ۼ�
    // ex) float value = 50;
    // value.Clamp(-10.10)
    // Debug.Log(value); // 10


}
