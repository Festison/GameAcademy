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

        // ���� ������ Ư¡ : 
        // ���� ������ �� ��° �ڷ���� �����Ͽ� �� ��(����)�� �ڷ��� ���Ͽ� ������ ��ġ�� ������ �� �ڷḦ �ڷ� �ű��
        // ������ �ڸ��� �ڷḦ �����Ͽ� �����ϴ� �˰����̴�.��, �� ��° �ڷ�� ù ��° �ڷ�,
        // �� ��° �ڷ�� �� ��°�� ù ��° �ڷ�,
        // �� ��° �ڷ�� �� ��°, �� ��°, ù ��° �ڷ�� ���� �� �ڷᰡ ���Ե� ��ġ�� ã�´�.
        // �ڷᰡ ���Ե� ��ġ�� ã�Ҵٸ� �� ��ġ�� �ڷḦ �����ϱ� ���� �ڷḦ �� ĭ�� �ڷ� �̵���Ų��.
        // ó�� Key ���� �� ��° �ڷ���� �����Ѵ�.
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

        // �־��� �迭���� ���� ���� ���Ҹ� �����Ͽ� �����ϴ� �˰���
        // ������ ���Ҹ� �迭�� �� �� �Ǵ� �� �ڷ� �ű��, ������ �κп��� ������ ������ �ݺ��մϴ�.
        public void SelectionSort(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                // �ּҰ��� ���ϱ� ���ؼ� ���� �ϳ� ����
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

        // ���� ������ Ư¡ : 
        // ������ �� ���Ҹ� ���Ͽ� �����ϴ� �˰���
        // ���� �� ���� ���Ұ� �����ʿ� �ִٸ�, �� ���Ҹ� ��ȯ�մϴ�.
        // �̷� ������ �迭�� ������ �����ϸ� ���� ū ���Ұ� ���� ���������� �̵��ϰ� �˴ϴ�.
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

        // �� ������ Ư¡ :
        // �� ������ ���� ����(divide and conquer) ����� ���� ����Ʈ�� �����Ѵ�.
        // ����Ʈ ����� �ϳ��� ���Ҹ� ����. �̷��� �� ���Ҹ� �ǹ��̶�� �Ѵ�.
        // �ǹ� �տ��� �ǹ����� ���� ���� ��� ���ҵ��� ����, �ǹ� �ڿ��� �ǹ����� ���� ū ��� ���ҵ��� ������ �ǹ��� �������� ����Ʈ�� �ѷ� ������.
        // �̷��� ����Ʈ�� �ѷ� ������ ���� �����̶�� �Ѵ�.������ ��ģ �ڿ� �ǹ��� �� �̻� �������� �ʴ´�.
        // ���ҵ� �� ���� ���� ����Ʈ�� ���� ���(Recursion) ������ �� ������ �ݺ��Ѵ�.��ʹ� ����Ʈ�� ũ�Ⱑ 0�̳� 1�� �� ������ �ݺ��ȴ�.
        // ��� ȣ���� �ѹ� ����� ������ �ּ��� �ϳ��� ���Ҵ� ���������� ��ġ�� �������Ƿ�, �� �˰����� �ݵ�� �����ٴ� ���� ������ �� �ִ�.

        // �������� ������ ����
        // �������� ������ pivot ���� �������� pivot �� �������� pivot ���� �������� �ΰ� �������� pivot ���� ū ���� �ΰ��� �Ѵ�.
        // �� ������ pivot�� �������� �� ��� �̺�ȭ �� ����Ʈ�� ��������� �ݺ����� �� �ᱹ ������ �ϼ� �ȴٴ� ��� ���̴�.
        // ���� ���� �����ϸ� pivot���� ū ���� pivot index ���� ���ʿ��� ã�� ( ū �� �� ��Ÿ�� ������ i index�� ������Ű���� �Ѵ�.)
        // pivot ���� ���� ���� pivot index ���� �����ʿ��� ã�´� ( ���� ���� ��Ÿ�� ������ j index�� ���ҽ�Ű���� �Ѵ�. )
        // pivot�� �������� �� �񱳰� �Ϸ�Ǿ��ٸ� index ��� i , j�� �� �غ���.
        // i ���� j �� ���� �۰ų� ���ٸ� �и� pivot �� �������� ��ȯ�� �ؾ��� ���� �ִٴ� ���� �ȴ�.
        // ��ȯ�� �� i �ε����� ���� j �ε����� ���� ������ �����Ѵ�.
        // i �ε����� j �ε������� �۰ų� ���ٸ� ��� �ݺ��ؼ� �����Ѵ�.
        // �� �� ���� ������ pivot�� �������� �������� ���ĵ� list ������ ���� Left ���� ���ҵ� j ���� �۴ٸ� ��� ����ϸ�ǰ�,
        // pivot�� �������� ���������� ���ĵ� list ������ ���� Right ���� ������ i ������ ũ�ٸ� ��� ����ϸ�ȴ�.

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

                //������ �ȵǾ��� ����, �޼հ� �������� ���� �ٲ�
                if (left < right)
                    Swap(list, left, right);
                //������ �Ǿ��� ����, ���ذ��� �������� ���� �ٲ�
                else
                    Swap(list, pivot, right);
            }

            //�������� �̹� ���ڸ��� ã�ư����Ƿ�
            //�������� �б�� ����(���ذ����� ��������)��
            //������(���ذ����� ū������ ������� �ٽ� ������ ����) 
            QuickSort(list, start, right - 1);
            QuickSort(list, right + 1, end);
        }

        // �պ� ������ Ư¡ : 
        // �ϳ��� ����Ʈ�� �� ���� �յ��� ũ��� �����ϰ� ���ҵ� �κ� ����Ʈ�� ������ ����,
        // �� ���� ���ĵ� �κ� ����Ʈ�� ���Ͽ� ��ü�� ���ĵ� ����Ʈ�� �ǰ� �ϴ� ����̴�.
        // �պ� ������ ������ �ܰ��� �̷������.
        // ����(Divide): �Է� �迭�� ���� ũ���� 2���� �κ� �迭�� �����Ѵ�.
        // ����(Conquer): �κ� �迭�� �����Ѵ�.�κ� �迭�� ũ�Ⱑ ����� ���� ������ ��ȯ ȣ�� �� �̿��Ͽ� �ٽ� ���� ���� ����� �����Ѵ�.
        // ����(Combine): ���ĵ� �κ� �迭���� �ϳ��� �迭�� �պ��Ѵ�.
        // �պ� ������ ����
        // �߰����� ����Ʈ�� �ʿ��ϴ�.
        // �� �κ� �迭�� ������ ���� �պ� ������ ��ȯ������ ȣ���Ͽ� �����Ѵ�.
        // �պ� ���Ŀ��� ������ ������ �̷������ ������ 2���� ����Ʈ�� �պ�(merge) �ϴ� �ܰ� �̴�.

        // ���� : 
        // �Ϲ����� ������� �������� �� �� ������ ���� ���� �� ���ϸ�, ���� ���� �˰����� �ϳ� �̴�.
        // ���� ����(divide and conquer) ���
        // ������ ���� 2���� ������ �и��ϰ� ������ �ذ��� ����, ����� ��Ƽ� ������ ������ �ذ��ϴ� �����̴�.
        // ���� ���� ����� �밳 ��ȯ ȣ���� �̿��Ͽ� �����Ѵ�.
        // ���� ����
        // ����Ʈ�� ���̰� 0 �Ǵ� 1�̸� �̹� ���ĵ� ������ ����.�׷��� ���� ��쿡��
        // ���ĵ��� ���� ����Ʈ�� �������� �߶� ����� ũ���� �� �κ� ����Ʈ�� ������.
        // �� �κ� ����Ʈ�� ��������� �պ� ������ �̿��� �����Ѵ�.
        // �� �κ� ����Ʈ�� �ٽ� �ϳ��� ���ĵ� ����Ʈ�� �պ��Ѵ�.

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


