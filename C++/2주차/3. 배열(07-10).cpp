#include<iostream>
using namespace std;

int main()
{
	// 배열 
	// 배열 : 동일한 데이터타입의 묶음
	int scores[3];
	scores[0] = 80;
	scores[1] = 70;
	scores[2] = 50;

	// 배열의 시작 주소
	cout << scores << endl;

	// 배열은 메모리내에서 연속적인 흐름을 가지고 있다.
	for (int i = 0; i < 3; i++)
	{
		cout << i << "번째의 값 : " << scores[i] << endl;
		cout << i << "번째의 주소 : " << &scores[i] << endl;
	}
	cout << endl;

	cout << &scores[0] << endl;
	cout << &scores[0] + 1 << endl; // 첫번째 원소의 주소
	cout << &scores[0] + 2 << endl; // 두번째 원소의 주소
	cout << endl;

	cout << *(&scores[0]) << endl;
	cout << *(&scores[0] + 1) << endl;
	cout << *(&scores[0] + 2) << endl;
	cout << endl;

	int num = 1784;
	int array[10];
	int tempArr[10];

	for (int i = 0; i < 10; i++)
	{
		array[i] = -1;
	}

	int count = 0;
	while (num > 0)
	{
		tempArr[count] = num % 10;
		num = num / 10;
		count++;
	}

	for (int i = 0; i < count; i++)
	{
		array[count - 1 - i] = tempArr[i];
	}

	for (int i = 0; i < 10; i++)
	{
		cout << array[i] << endl;
	}

	return 0;
}