#include<iostream>
using namespace std;

void PrintArr(int arr[2][5])
{
	for (int i = 0; i < 2; i++)
	{
		for (int j = 0; j < 5; j++)
		{
			cout << arr[i][j] << endl;
		}
	}

	for (int i = 0; i < 10; i++)
	{
		cout << *(*(arr + 0) + i) << endl;
	}
}

void InitArr(int arr[2][5], int num)
{
	for (int i = 0; i < 2; i++)
	{
		for (int j = 0; j < 5; j++)
		{
			arr[i][j] = num;

			cout << arr[i][j] << endl;
		}
	}
}
int main()
{
	// ���߹迭�� ������ �޸𸮿� ����� ���� ���������� ����ȴ�.
	int arr[2][5];
	InitArr(arr, -1);

	int arrB[2][5] = { {0,1,2,3,4}, {5,6,7,8,9} };

	// 2���� �迭 ��ü�� ���� �ּ�
	cout << arrB << endl;

	// 2���� �迭�̱� ������ ���� ���ϱ� ���ؼ��� *�� �ΰ� �ʿ��ϴ�.
	cout << *(*(arrB + 0) + 0) << endl; // arrB[0][0]�� ��
	cout << *(*(arrB + 0) + 1) << endl; // arrB[0][1]�� ��
	cout << *(*(arrB + 1) + 0) << endl; // arrB[1][0]�� ��	
	cout << *arrB << endl;              // arrB[0][0]�� �ּ�
	cout << *arrB + 1 << endl;          // arrB[0][1]�� �ּ�	
	cout << *(arrB + 1) << endl;        // arrB[1][0]�� �ּ�

	int arr[10][10];

	for (int i = 0; i < 10; i++)
	{
		for (int j = 0; j < 10; j++)
		{
			arr[i][j] = i * j;
		}
	}

	cout << arr[9][9] << endl;

	return 0;
}