using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 확장 메서드

    public float value = 50;
    public float min = -10;
    public float max = 10;

    public void Start()
    {
        Debug.Log(value);
    }
}
