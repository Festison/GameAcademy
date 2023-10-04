using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic : MonoBehaviour
{
    // 정적 배열 : 크기가 정해진 배열
    int[] intArray = new int[5];

    // 가변 배열 : 크기가 변하는 배열
    // List<T>

    // 동적 할당을 해줘야 배열에 데이터를 집어 넣을 수 있다.
    List<int> intList = new List<int>();
    ArrayList arrayList = new ArrayList();

    // 큐와 스택은 논 제너릭 상태로 사용하면 오브젝트 타입을 가진다.
    Queue queue = new Queue();
    Queue<int> intQueue = new Queue<int>();
    Stack<int> intStack = new Stack<int>();
    
    Dictionary<string, Color> colorDic = new Dictionary<string, Color>();

    // 논 제너릭 딕셔너리 오브젝트 타입으로 이루어져 있다.
    Hashtable hashtable = new Hashtable();

    private void Start()
    {
        // 키와 갚이 쌍으로 이루어진 딕셔너리 Red라는 키를 입력시 갚 Color(1,0,0)이 나온다.
        colorDic.Add("Red", new Color(1, 0, 0));
        
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
