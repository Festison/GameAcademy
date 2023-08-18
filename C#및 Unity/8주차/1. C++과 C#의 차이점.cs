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
    // 깊은 복사
    void Swap(int a, int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    // C#에서의 콜 바이 레퍼런스
    void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    void Start()
    {
        // C++에서의 배열
        // int arr[10]; 

        // C#에서의 배열
        // 힙 영역에 할당
        int[] arr = new int[10];

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = i;
        }

        // 구조체는 값 타입이기 떄문에 new가 스택영역에 할당된다.
        PositionStruct positionStruct = new PositionStruct();
        positionStruct.Set(2, 3);

        // 클래스는 참조 타입이기 때문에 new가 힙영역에 할당된다.
        PositionClass positionClass = new PositionClass();
        positionClass.Set(3, 4);

        // 구조체는 값 타입임으로 값을 완전히 복사해 넣는 깊은 복사가 일어난다
        PositionStruct tempstruct;
        tempstruct = positionStruct;
        tempstruct.Set(7, 7);

        // 클래스는 참조 타입임으로 주소를 복사하는 얕은 복사가 일어난다.
        PositionClass tempclass;
        tempclass = positionClass;
        tempclass.Set(7, 7);

        #region 1. C#과 C++의 차이점
        // C#과 C++의 차이점

        // bool 타입에 정수형 1은 C#에서 넎을 수 없다.
        // 오로지 true나 false만 가능, 즉 기준이 엄격해 졌다.
        // bool isCheck = 1; 불가능

        // 데이터 타입이 구조체로 이루어져 있다. 
        // C#에는 직접적인 포인터의 사용이 없다.
        // C++의 강력한 기능인 포인터에 대해 사용자의 실수를 방지하기 위해서 직접 사용 하지 않는다.
        // 포인터는 메모리에 대한 이점을 가진다.
        // Garbage Collector라고 하는 친구가 대신 메모리를 해제해 준다.

        int num = 10;

        for (int i = 0; i < num; i++)
        {
            // cout<<i<<endl;
            // Debug.Log(i);
        }

        // C#에는 값 타입과, 참조 타입이라는 것이 존재한다.
        // 값 타입은 Stack영역에 할당되고 참조 타입은 Heap영역에 할당 된다.
        // int는 값타입이기 때문에 , 값자체가 복사되어 들어가는 깊은 복사가 일어난다.
        // 값이 복사되어 들어가면 깊은 복사 라고 한다.

        int numA = 30;
        int numB = 10;
        Swap(numA, numB);

        // 콜바이 레퍼런스를 위해 ref 키워드 사용
        Swap(ref numA, ref numB);

        Debug.Log(numA);
        Debug.Log(numB);

        // 문자열로 치환 된다.
        Debug.Log(numA + "," + numB);

        // 콜바이 벨류, 콜바이 레퍼런스의 C#
        #endregion
    }
}