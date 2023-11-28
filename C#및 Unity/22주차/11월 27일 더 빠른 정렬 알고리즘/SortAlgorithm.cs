using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sort
{
    public class SortAlgorithm : MonoBehaviour
    {
        public List<int> list = new List<int>();

        void Start()
        {
            list.Add(5);
            list.Add(2);
            list.Add(3);
            list.Add(1);
            list.Add(4);
            list.Add(6);

            MergeSort(list, 0, list.Count - 1);

            foreach (int item in list)
            {
                Debug.Log(item);
            }
        }

        public void Swap(List<int> list, int indexA, int indexB)
        {
            int temp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = temp;
        }

        // 삽입 정렬의 특징 : 
        // 삽입 정렬은 두 번째 자료부터 시작하여 그 앞(왼쪽)의 자료들과 비교하여 삽입할 위치를 지정한 후 자료를 뒤로 옮기고
        // 지정한 자리에 자료를 삽입하여 정렬하는 알고리즘이다.즉, 두 번째 자료는 첫 번째 자료,
        // 세 번째 자료는 두 번째와 첫 번째 자료,
        // 네 번째 자료는 세 번째, 두 번째, 첫 번째 자료와 비교한 후 자료가 삽입될 위치를 찾는다.
        // 자료가 삽입될 위치를 찾았다면 그 위치에 자료를 삽입하기 위해 자료를 한 칸씩 뒤로 이동시킨다.
        // 처음 Key 값은 두 번째 자료부터 시작한다.
        public void InsertionSort(List<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                for (int j = 0; j >= 1; j--)
                {
                    if (list[j - 1] < list[j])
                    {
                        break;
                    }
                    Swap(list, j - 1, j);
                }
            }
        }

        // 주어진 배열에서 가장 작은 원소를 선택하여 정렬하는 알고리즘
        // 선택한 원소를 배열의 맨 앞 또는 맨 뒤로 옮기고, 나머지 부분에서 동일한 과정을 반복합니다.
        public void SelectionSort(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                // 최소값을 구하기 위해서 변수 하나 정의
                int minIndex = i;

                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[minIndex])
                    {
                        minIndex = j;
                    }
                }
                Swap(list, i, minIndex);
            }
        }

        // 버블 정렬의 특징 : 
        // 인접한 두 원소를 비교하여 정렬하는 알고리즘
        // 만약 더 작은 원소가 오른쪽에 있다면, 두 원소를 교환합니다.
        // 이런 식으로 배열의 끝까지 진행하면 가장 큰 원소가 가장 오른쪽으로 이동하게 됩니다.
        public void BubbleSort(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        Swap(this.list, j, j + 1);
                    }
                }
            }
        }

        // 퀵 정렬의 특징 :
        // 퀵 정렬은 분할 정복(divide and conquer) 방법을 통해 리스트를 정렬한다.
        // 리스트 가운데서 하나의 원소를 고른다. 이렇게 고른 원소를 피벗이라고 한다.
        // 피벗 앞에는 피벗보다 값이 작은 모든 원소들이 오고, 피벗 뒤에는 피벗보다 값이 큰 모든 원소들이 오도록 피벗을 기준으로 리스트를 둘로 나눈다.
        // 이렇게 리스트를 둘로 나누는 것을 분할이라고 한다.분할을 마친 뒤에 피벗은 더 이상 움직이지 않는다.
        // 분할된 두 개의 작은 리스트에 대해 재귀(Recursion) 적으로 이 과정을 반복한다.재귀는 리스트의 크기가 0이나 1이 될 때까지 반복된다.
        // 재귀 호출이 한번 진행될 때마다 최소한 하나의 원소는 최종적으로 위치가 정해지므로, 이 알고리즘은 반드시 끝난다는 것을 보장할 수 있다.

        // 퀵정렬의 간단한 설명
        // 퀵정렬은 임의의 pivot 값을 기준으로 pivot 의 좌측에는 pivot 보다 작은값을 두고 우측에는 pivot 보다 큰 값을 두고자 한다.
        // 이 행위는 pivot을 기준으로 좌 우로 이분화 된 리스트를 재귀적으로 반복했을 때 결국 정렬이 완성 된다는 방법 론이다.
        // 보다 쉽게 설명하면 pivot보다 큰 값을 pivot index 보다 왼쪽에서 찾고 ( 큰 값 이 나타날 때까지 i index를 증가시키도록 한다.)
        // pivot 보다 작은 값을 pivot index 보다 오른쪽에서 찾는다 ( 작은 값이 나타날 때까지 j index를 감소시키도록 한다. )
        // pivot을 기준으로 값 비교가 완료되었다면 index 결과 i , j를 비교 해본다.
        // i 값이 j 값 보다 작거나 같다면 분명 pivot 을 기준으로 교환을 해야할 값이 있다는 뜻이 된다.
        // 교환한 뒤 i 인덱스는 증가 j 인덱스는 감소 연산을 수행한다.
        // i 인덱스가 j 인덱스보다 작거나 같다면 계속 반복해서 수행한다.
        // 위 와 같은 과정은 pivot을 기준으로 왼쪽으로 정렬된 list 에서는 최초 Left 값이 감소된 j 보다 작다면 계속 재귀하면되고,
        // pivot을 기준으로 오른쪽으로 정렬된 list 에서는 최초 Right 값이 증가된 i 값보다 크다면 계속 재귀하면된다.

        public void QuickSort(List<int> list, int start, int end)
        {
            int pivot = start;
            int left = pivot + 1;
            int right = end;

            if (start >= end)
            {
                return;
            }

            while (left <= right)
            {
                while (list[left] <= list[pivot] && left < end)
                    left++;
                while (list[right] >= list[pivot] && right > start)
                    right--;

                //교차가 안되었을 때는, 왼손과 오른손의 값을 바꿈
                if (left < right)
                    Swap(list, left, right);
                //교차가 되었을 때는, 기준값과 오른손의 값을 바꿈
                else
                    Swap(list, pivot, right);
            }

            //기준점은 이미 제자리를 찾아갔으므로
            //기준점을 분기로 왼쪽(기준값보다 작은값들)과
            //오른쪽(기준값보다 큰값들을 대상으로 다시 퀵정렬 수행) 
            QuickSort(list, start, right - 1);
            QuickSort(list, right + 1, end);
        }

        // 합병 정렬의 특징 : 
        // 하나의 리스트를 두 개의 균등한 크기로 분할하고 분할된 부분 리스트를 정렬한 다음,
        // 두 개의 정렬된 부분 리스트를 합하여 전체가 정렬된 리스트가 되게 하는 방법이다.
        // 합병 정렬은 다음의 단계들로 이루어진다.
        // 분할(Divide): 입력 배열을 같은 크기의 2개의 부분 배열로 분할한다.
        // 정복(Conquer): 부분 배열을 정렬한다.부분 배열의 크기가 충분히 작지 않으면 순환 호출 을 이용하여 다시 분할 정복 방법을 적용한다.
        // 결합(Combine): 정렬된 부분 배열들을 하나의 배열에 합병한다.
        // 합병 정렬의 과정
        // 추가적인 리스트가 필요하다.
        // 각 부분 배열을 정렬할 때도 합병 정렬을 순환적으로 호출하여 적용한다.
        // 합병 정렬에서 실제로 정렬이 이루어지는 시점은 2개의 리스트를 합병(merge) 하는 단계 이다.

        // 과정 : 
        // 일반적인 방법으로 구현했을 때 이 정렬은 안정 정렬 에 속하며, 분할 정복 알고리즘의 하나 이다.
        // 분할 정복(divide and conquer) 방법
        // 문제를 작은 2개의 문제로 분리하고 각각을 해결한 다음, 결과를 모아서 원래의 문제를 해결하는 전략이다.
        // 분할 정복 방법은 대개 순환 호출을 이용하여 구현한다.
        // 과정 설명
        // 리스트의 길이가 0 또는 1이면 이미 정렬된 것으로 본다.그렇지 않은 경우에는
        // 정렬되지 않은 리스트를 절반으로 잘라 비슷한 크기의 두 부분 리스트로 나눈다.
        // 각 부분 리스트를 재귀적으로 합병 정렬을 이용해 정렬한다.
        // 두 부분 리스트를 다시 하나의 정렬된 리스트로 합병한다.

        public void MergeSort(List<int> list, int left, int right)
        {
            if (left == right)
                return;

            int mid = (left + right) / 2;

            MergeSort(list, left, mid);
            MergeSort(list, mid + 1, right);
            Merge(list, left, mid, right);
        }

        void Merge(List<int> list, int start, int mid, int end)
        {
            List<int> tempList = new List<int>();
            int leftIndex = start;
            int rightIndex = mid + 1;

            while (leftIndex <= mid && rightIndex <= end)
            {
                if (list[leftIndex] < list[rightIndex])
                {
                    tempList.Add(list[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    tempList.Add(list[rightIndex]);
                    rightIndex++;
                }
            }

            if (leftIndex > mid)
            {
                for (int i = rightIndex; i < end; i++)
                {
                    tempList.Add(list[i]);
                }
            }
            else
            {
                for (int i = leftIndex; i < mid; i++)
                {
                    tempList.Add(list[i]);
                }
            }

            for (int i = 0; i < tempList.Count; i++)
            {
                list[start + i] = tempList[i];
            }
        }
    }
}


