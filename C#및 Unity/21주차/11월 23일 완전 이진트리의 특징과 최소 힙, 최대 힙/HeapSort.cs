using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteBinaryTree
{
    public List<int> array;
    protected const int rootIndex = 1;

    public CompleteBinaryTree()
    {
        array = new List<int>();
        array.Add(-1);
    }

    public virtual void Add(int value)
    {
        array.Add(value);
    }

    public virtual int Remove()
    {
        int removeValue = array[array.Count - 1];
        array.RemoveAt(array.Count - 1);
        return removeValue;
    }
}

// 힙에서의 부모 자식 관계 :
// 오른쪽 자식의 인덱스 = (부모의 인덱스) *2 + 1

// 왼쪽 자식의 인덱스 = (부모의 인덱스) *2

// 부모의 인덱스 = (자식의 인덱스) / 2

public class MinHeap : CompleteBinaryTree
{
    public override void Add(int value)
    {
        array.Add(value);

        int inputCurIndex = array.Count - 1;
        while (inputCurIndex > 0)
        {
            int curParantIndex = inputCurIndex / 2;
            if (array[inputCurIndex] < array[curParantIndex])
                SwapValue(inputCurIndex, curParantIndex);
            else
                break;

            inputCurIndex = curParantIndex;
        }
    }

    public void SwapValue(int indexA, int indexB)
    {
        int tempValue = array[indexA];
        array[indexA] = array[indexB];
        array[indexB] = tempValue;
    }

    public override int Remove()
    {
        int leastValue = array[rootIndex];

        array[rootIndex] = array[array.Count - 1];
        array.RemoveAt(array.Count - 1);

        int curParentIndex = rootIndex;
        int last = array.Count - 1;

        while (curParentIndex < last)
        {
            int childIndex = curParentIndex * 2;

            if (childIndex < last)
            {
                if (array[childIndex] > array[childIndex + 1])
                {
                    childIndex = childIndex + 1;
                }
            }

            if (childIndex > last)
                break;
            if (array[curParentIndex] <= array[childIndex])
                break;

            SwapValue(childIndex, curParentIndex);
            curParentIndex = childIndex;
        }

        return leastValue;
    }
}

public class MaxHeap : CompleteBinaryTree
{
    public override void Add(int value)
    {
        array.Add(value);

        int inputCurIndex = array.Count - 1;
        
        while (inputCurIndex > rootIndex)
        {
            int curParantIndex = inputCurIndex / 2;
            if (array[inputCurIndex] < array[curParantIndex])
            {
                SwapValue(inputCurIndex, curParantIndex);
                inputCurIndex = curParantIndex;
            }               
            else
                break;          
        }
    }

    public void SwapValue(int indexA, int indexB)
    {
        int tempValue = array[indexA];
        array[indexA] = array[indexB];
        array[indexB] = tempValue;
    }

    public override int Remove()
    {
        int largestValue = array[rootIndex];

        array[rootIndex] = array[array.Count - 1];
        array.RemoveAt(array.Count - 1);

        int curParentIndex = rootIndex;
        int last = array.Count - 1;

        while (curParentIndex > last)
        {
            int childIndex = curParentIndex * 2;

            if (childIndex < last)
            {
                if (array[childIndex] < array[childIndex + 1])
                {
                    childIndex = childIndex + 1;
                }
            }

            if (childIndex > last)
                break;
            if (array[childIndex] > array[curParentIndex])
                break;

            SwapValue(childIndex, curParentIndex);
            curParentIndex = childIndex;
        }

        return largestValue;
    }
}

public class HeapSort : MonoBehaviour
{
    private void Start()
    {
        MinHeap minHeap = new MinHeap();
        MaxHeap maxHeap = new MaxHeap();

        minHeap.Add(30);
        minHeap.Add(20);
        minHeap.Add(10);
        minHeap.Add(40);
        minHeap.Add(50);
        minHeap.Add(60);

        maxHeap.Add(10);
        maxHeap.Add(30);
        maxHeap.Add(20);
        maxHeap.Add(40);
        maxHeap.Remove();

        Debug.Log(minHeap.array[1]);
    }
}
