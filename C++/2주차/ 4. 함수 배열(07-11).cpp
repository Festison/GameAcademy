#include<iostream>
using namespace std;

// 배열을 인자로 하면 Call By Address이기 때문에 반환값이없어도 메인함수의 값이 바뀐다.
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


