using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum BIT_FLAG
{
    NONE = 0,
    FLAG1 = 1<<1,
    FLAG2 = 1<<2,
    FLAG3 = 1<<3,
    FLAG4 = 1<<4,
    CUSTOMFALGS = FLAG3|FLAG4|FLAG2,
}

public class BitTest : MonoBehaviour
{
    public BIT_FLAG flags = BIT_FLAG.NONE;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            //flags�� FLAG1�� ���ش�.
            flags = flags | BIT_FLAG.FLAG1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //flags�� FLAG4�� ���ش�.
            flags = flags | BIT_FLAG.FLAG4;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //flags�� FlAG3�� ���(���������� ����, ���������� Ű��)���ش�.
            flags = flags ^ BIT_FLAG.CUSTOMFALGS;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            //flags�� FLAG4�� ���ش�.
            flags = flags & ~BIT_FLAG.FLAG4;
        }

        if(Input.GetKeyDown(KeyCode.G))
        {
            if((flags & BIT_FLAG.FLAG3) != 0)
            {
                Debug.Log("�÷���3�� �����ֽ��ϴ�.");
            }
        }
    }

}
