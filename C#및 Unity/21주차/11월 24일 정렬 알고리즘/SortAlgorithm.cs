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

    // ���� ������ Ư¡ : 
    // ���� ������ �� ��° �ڷ���� �����Ͽ� �� ��(����)�� �ڷ��� ���Ͽ� ������ ��ġ�� ������ �� �ڷḦ �ڷ� �ű��
    // ������ �ڸ��� �ڷḦ �����Ͽ� �����ϴ� �˰����̴�.��, �� ��° �ڷ�� ù ��° �ڷ�,
    // �� ��° �ڷ�� �� ��°�� ù ��° �ڷ�,
    // �� ��° �ڷ�� �� ��°, �� ��°, ù ��° �ڷ�� ���� �� �ڷᰡ ���Ե� ��ġ�� ã�´�.
    // �ڷᰡ ���Ե� ��ġ�� ã�Ҵٸ� �� ��ġ�� �ڷḦ �����ϱ� ���� �ڷḦ �� ĭ�� �ڷ� �̵���Ų��.
    // ó�� Key ���� �� ��° �ڷ���� �����Ѵ�.
    public void InsertionSort(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            // ù��° ���� ���ĵǾ��ٰ� ġ�� Ű���� �ι�° �ε��� ���� ����
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

    // �־��� �迭���� ���� ���� ���Ҹ� �����Ͽ� �����ϴ� �˰���
    // ������ ���Ҹ� �迭�� �� �� �Ǵ� �� �ڷ� �ű��, ������ �κп��� ������ ������ �ݺ��մϴ�.
    public void SelectionSort(int[] array)
    {
        //�迭�� ������ ���� �ڿ������� ������ �ǹǷ� �迭ũ�� -1 ��ŭ �ݺ�
        for (int i = 0; i < array.Length - 1; i++)
        {
            // �ּҰ��� ���ϱ� ���ؼ� ���� �ϳ� ����
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

    // ���� ������ Ư¡ : 
    // ������ �� ���Ҹ� ���Ͽ� �����ϴ� �˰���
    // ���� �� ���� ���Ұ� �����ʿ� �ִٸ�, �� ���Ҹ� ��ȯ�մϴ�.
    // �̷� ������ �迭�� ������ �����ϸ� ���� ū ���Ұ� ���� ���������� �̵��ϰ� �˴ϴ�.
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
