#include<iostream>
using namespace std;

// 함수의 선언과 정의
// 함수의 선언

// 함수는 파스칼 표기법을 사용
// 리턴 타입 함수명 (매개변수)
// {
//		함수의 내용
// }

// input도 없고 output도 없는 함수
void ShowInventoryMenu()
{
	cout << "----------------Invnetory---------------" << endl;
}

// input은 없지만 output은 있는 함수
int GetNumberOne()
{
	return 1;
}

// input은 있지만 output은 없는 함수
void PrintNumber(int inputA)
{
	cout << inputA << endl;
}

// input도 있고 output도 있는 함수
int IntegerConversion(float value)
{
	cout << "매개변수 value의 값 : " << value << endl;
	return value;
}

// 최소값과 최대값, 타겟이 되는 값이 있을 때,
// 최소값 < 타겟값 < 최대값
// 타겟값이 최소값과 최대값 사이에 있는지 체크하는 기능

bool BeetweenCheck(int min, int target, int max)
{
	bool isCheck = false;

	if (target >= min && target <= max)
	{
		isCheck = true;
	}

	if (isCheck == true)
	{
		cout << "참입니다." << endl;
	}

	return isCheck;
}

int Gugudan(int i, int j)
{
	return i * j;
}

int main()
{
	// 함수
	// 함수는 기능이다.

	float num = 65.87f;
	ShowInventoryMenu();
	cout << GetNumberOne() << endl;
	PrintNumber(num);
	cout << IntegerConversion(num) << endl;
	BeetweenCheck(50, 75, 100);

	for (int i = 1; i < 10; i++)
	{
		for (int j = 1; j < 10; j++)
		{
			cout << i << " * " << j << " = " << Gugudan(i, j) << endl;
		}
	}

	return 0;
}

