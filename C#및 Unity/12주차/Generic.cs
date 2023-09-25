using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic : MonoBehaviour
{
    // ���� �迭 : ũ�Ⱑ ������ �迭
    int[] intArray = new int[5];

    // ���� �迭 : ũ�Ⱑ ���ϴ� �迭
    // List<T>
    List<int> intList = new List<int>();
    ArrayList arrayList = new ArrayList();

    Queue<int> intQueue = new Queue<int>();
    Stack<int> intStack = new Stack<int>();

    Dictionary<int, string> textDic = new Dictionary<int, string>();

    // �� ���ʸ� ��ųʸ� ������Ʈ Ÿ������ �̷���� �ִ�.
    Hashtable hashtable = new Hashtable();

    private void Start()
    {
        int num = 10;

        // �� Ÿ���� ���� Ÿ������ ���� object�� ���·� ����ȯ(�ڽ�)  - ��������� �������ʾƵ���
        object obj = (object)num;
        // ���� Ÿ���� �� Ÿ������ ���� object�� ���¿��� �������·� ����ȯ(��ڽ�) - ��������� �������.
        int numB = 10 + (int)obj;

        for (int i = 0; i < 10; i++)
        {
            int inputValue = i * 10;

            // List�� ������ ���� Add
            intList.Add(inputValue);
            // Queue�� ������ ���� Enqueue
            intQueue.Enqueue(inputValue);
            // Stack�� ������ ���� Push
            intStack.Push(inputValue);
        }

        // List���� ������ ����
        Debug.Log(intList[0]);
        // Queue���� ������ ���� Dequeue
        Debug.Log(intQueue.Dequeue());
        // Stack���� ������ ���� Pop
        Debug.Log(intStack.Pop());

        // ���ϴ� �ڷᱸ���� ��� �� ���� value�� �־� �ش�.
        foreach (int value in intList)
        {
            Debug.Log(value);
        }

    }

}
