using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PositionStruct
{
    public float x;
    public float y;

    public void Set(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
    public void Show()
    {
        Debug.Log(x + "," + y);
    }
}

public class PositionClass
{
    public float x;
    public float y;

    public void Set(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
    public void Show()
    {
        Debug.Log(x + "," + y);
    }
}

public class GameManager : MonoBehaviour
{
    // ���� ����
    void Swap(int a, int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    // C#������ �� ���� ���۷���
    void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    void Start()
    {
        // C++������ �迭
        // int arr[10]; 

        // C#������ �迭
        // �� ������ �Ҵ�
        int[] arr = new int[10];

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = i;
        }

        // ����ü�� �� Ÿ���̱� ������ new�� ���ÿ����� �Ҵ�ȴ�.
        PositionStruct positionStruct = new PositionStruct();
        positionStruct.Set(2, 3);

        // Ŭ������ ���� Ÿ���̱� ������ new�� �������� �Ҵ�ȴ�.
        PositionClass positionClass = new PositionClass();
        positionClass.Set(3, 4);

        // ����ü�� �� Ÿ�������� ���� ������ ������ �ִ� ���� ���簡 �Ͼ��
        PositionStruct tempstruct;
        tempstruct = positionStruct;
        tempstruct.Set(7, 7);

        // Ŭ������ ���� Ÿ�������� �ּҸ� �����ϴ� ���� ���簡 �Ͼ��.
        PositionClass tempclass;
        tempclass = positionClass;
        tempclass.Set(7, 7);

        #region 1. C#�� C++�� ������
        // C#�� C++�� ������

        // bool Ÿ�Կ� ������ 1�� C#���� ���� �� ����.
        // ������ true�� false�� ����, �� ������ ������ ����.
        // bool isCheck = 1; �Ұ���

        // ������ Ÿ���� ����ü�� �̷���� �ִ�. 
        // C#���� �������� �������� ����� ����.
        // C++�� ������ ����� �����Ϳ� ���� ������� �Ǽ��� �����ϱ� ���ؼ� ���� ��� ���� �ʴ´�.
        // �����ʹ� �޸𸮿� ���� ������ ������.
        // Garbage Collector��� �ϴ� ģ���� ��� �޸𸮸� ������ �ش�.

        int num = 10;

        for (int i = 0; i < num; i++)
        {
            // cout<<i<<endl;
            // Debug.Log(i);
        }

        // C#���� �� Ÿ�԰�, ���� Ÿ���̶�� ���� �����Ѵ�.
        // �� Ÿ���� Stack������ �Ҵ�ǰ� ���� Ÿ���� Heap������ �Ҵ� �ȴ�.
        // int�� ��Ÿ���̱� ������ , ����ü�� ����Ǿ� ���� ���� ���簡 �Ͼ��.
        // ���� ����Ǿ� ���� ���� ���� ��� �Ѵ�.

        int numA = 30;
        int numB = 10;
        Swap(numA, numB);

        // �ݹ��� ���۷����� ���� ref Ű���� ���
        Swap(ref numA, ref numB);

        Debug.Log(numA);
        Debug.Log(numB);

        // ���ڿ��� ġȯ �ȴ�.
        Debug.Log(numA + "," + numB);

        // �ݹ��� ����, �ݹ��� ���۷����� C#
        #endregion
    }
}