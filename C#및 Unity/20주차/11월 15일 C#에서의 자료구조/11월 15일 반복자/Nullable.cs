using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nullable : MonoBehaviour
{
    // ? 시리즈

    // Nullable 널을 가질 수 있게 된다.
    bool? isCheck;

    private void Start()
    {
        int value;
        value = (bool)isCheck ? 10 : 20;
    }
}
