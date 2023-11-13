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
    // public static 리턴타입 확장 메서드명 (this 확장할 데이터 타입 value, 매개변수)
    public static bool IsBetween(this float curValue, float min, float max)
    {
        return curValue > min && curValue < max;
    }
    // 실습 Clamp 기능 작성
    // ex) float value = 50;
    // value.Clamp(-10.10)
    // Debug.Log(value); // 10


}
