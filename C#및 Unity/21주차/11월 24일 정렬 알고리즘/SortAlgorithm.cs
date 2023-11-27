using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortAlgorithm : MonoBehaviour
{
    public int[] array = { 5, 2, 4, 3, 1 };

    void Start()
    {
        SelectionSort(array);
        Debug.Log(array[0]);
        Debug.Log(array[1]);
        Debug.Log(array[2]);
        Debug.Log(array[3]);
        Debug.Log(array[4]);
    }

    // 삽입 정렬의 특징 : 
    // 삽입 정렬은 두 번째 자료부터 시작하여 그 앞(왼쪽)의 자료들과 비교하여 삽입할 위치를 지정한 후 자료를 뒤로 옮기고
    // 지정한 자리에 자료를 삽입하여 정렬하는 알고리즘이다.즉, 두 번째 자료는 첫 번째 자료,
    // 세 번째 자료는 두 번째와 첫 번째 자료,
    // 네 번째 자료는 세 번째, 두 번째, 첫 번째 자료와 비교한 후 자료가 삽입될 위치를 찾는다.
    // 자료가 삽입될 위치를 찾았다면 그 위치에 자료를 삽입하기 위해 자료를 한 칸씩 뒤로 이동시킨다.
    // 처음 Key 값은 두 번째 자료부터 시작한다.
    public void InsertionSort(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            // 첫번째 값은 정렬되었다고 치고 키값은 두번째 인덱스 부터 시작
            int key = array[i];
            int j;

            for (j = i - 1; j >= 0; j--)
            {
                if (array[j] > key)
                {
                    array[j + 1] = array[j];
                }
                else
                {
                    break;
                }
            }

            array[j + 1] = key;
        }
    }

    // 주어진 배열에서 가장 작은 원소를 선택하여 정렬하는 알고리즘
    // 선택한 원소를 배열의 맨 앞 또는 맨 뒤로 옮기고, 나머지 부분에서 동일한 과정을 반복합니다.
    public void SelectionSort(int[] array)
    {
        //배열의 마지막 값은 자연스럽게 정렬이 되므로 배열크기 -1 만큼 반복
        for (int i = 0; i < array.Length - 1; i++)
        {
            // 최소값을 구하기 위해서 변수 하나 정의
            int minArr = i;

            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[minArr])
                {
                    minArr = j;
                }
            }

            int temp = array[i];
            array[i] = array[minArr];
            array[minArr] = temp;
        }
    }

    // 버블 정렬의 특징 : 
    // 인접한 두 원소를 비교하여 정렬하는 알고리즘
    // 만약 더 작은 원소가 오른쪽에 있다면, 두 원소를 교환합니다.
    // 이런 식으로 배열의 끝까지 진행하면 가장 큰 원소가 가장 오른쪽으로 이동하게 됩니다.
    public void BubbleSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    public void QucikSort(int[] array)
    {
        int pivot;
        int left;
        int right;

        for (int i = 0; i < array.Length - 1; i++)
        {
            pivot = i;
        }
    }
}
