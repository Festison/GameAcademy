using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nullable : MonoBehaviour
{
    // ? �ø���

    // Nullable ���� ���� �� �ְ� �ȴ�.
    bool? isCheck;

    private void Start()
    {
        int value;
        value = (bool)isCheck ? 10 : 20;
    }
}
