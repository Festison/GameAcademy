#include<iostream>
using namespace std;

// �迭�� ���ڷ� �ϸ� Call By Address�̱� ������ ��ȯ���̾�� �����Լ��� ���� �ٲ��.
int* MultipleOfNumber(int* array, int num)
{
	for (int i = 0; i < 1000; i++)
	{
		array[i] = i * num;
	}

	return array;
}

int* InitArr(int* arr, int num)
{
	for (int i = 0; i < 10; i++)
	{
		arr[i] = num;
	}

	return arr;
}

void PrintArr(int* arr)
{
	for (int i = 0; i < 10; i++)
	{
		cout << arr[i] << endl;
	}
}

int main()
{
	int arr[10];
	InitArr(arr, -1);
	PrintArr(arr);

	int array[1000];
	MultipleOfNumber(array, 2);
	cout << array[15] << endl;

	return 0;
}


