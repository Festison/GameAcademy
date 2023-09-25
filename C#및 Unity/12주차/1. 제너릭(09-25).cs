using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic : MonoBehaviour
{
    // 정적 배열 : 크기가 정해진 배열
    int[] intArray = new int[5];

    // 가변 배열 : 크기가 변하는 배열
    // List<T>
    List<int> intList = new List<int>();
    ArrayList arrayList = new ArrayList();

    Queue<int> intQueue = new Queue<int>();
    Stack<int> intStack = new Stack<int>();

    Dictionary<int, string> textDic = new Dictionary<int, string>();

    // 논 제너릭 딕셔너리 오브젝트 타입으로 이루어져 있다.
    Hashtable hashtable = new Hashtable();

    private void Start()
    {
        int num = 10;

        // 값 타입을 참조 타입으로 변경 object의 형태로 형변환(박싱)  - 명시적으로 해주지않아도됨
        object obj = (object)num;
        // 참조 타입을 값 타입으로 변경 object의 형태에서 원래형태로 형변환(언박싱) - 명시적으로 해줘야함.
        int numB = 10 + (int)obj;

        for (int i = 0; i < 10; i++)
        {
            int inputValue = i * 10;

            // List에 데이터 삽입 Add
            intList.Add(inputValue);
            // Queue에 데이터 삽입 Enqueue
            intQueue.Enqueue(inputValue);
            // Stack에 데이터 삽입 Push
            intStack.Push(inputValue);
        }

        // List에서 데이터 추출
        Debug.Log(intList[0]);
        // Queue에서 데이터 추출 Dequeue
        Debug.Log(intQueue.Dequeue());
        // Stack에서 데이터 추출 Pop
        Debug.Log(intStack.Pop());

        // 원하는 자료구조를 담고 그 값을 value에 넣어 준다.
        foreach (int value in intList)
        {
            Debug.Log(value);
        }

    }

}
