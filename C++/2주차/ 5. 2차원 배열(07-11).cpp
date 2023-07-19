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
	// 이중배열은 실제로 메모리에 저장될 때는 일차원으로 저장된다.
	int arr[2][5];
	InitArr(arr, -1);

	int arrB[2][5] = { {0,1,2,3,4}, {5,6,7,8,9} };

	// 2차원 배열 전체의 시작 주소
	cout << arrB << endl;

	// 2차원 배열이기 문에 값을 구하기 위해서는 *이 두개 필요하다.
	cout << *(*(arrB + 0) + 0) << endl; // arrB[0][0]의 값
	cout << *(*(arrB + 0) + 1) << endl; // arrB[0][1]의 값
	cout << *(*(arrB + 1) + 0) << endl; // arrB[1][0]의 값	
	cout << *arrB << endl;              // arrB[0][0]의 주소
	cout << *arrB + 1 << endl;          // arrB[0][1]의 주소	
	cout << *(arrB + 1) << endl;        // arrB[1][0]의 주소

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
