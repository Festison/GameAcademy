#include<iostream>
using namespace std;

int main()
{
#pragma region 사칙 연산
	// 연산자
	// 사칙연산
	// +, -, *, /

	int valueA = 10;
	int valueB = 20;
	int result = 0;

	result += valueA;
	cout << "result += valueA = " << result << endl;
	result -= valueB;
	cout << "result -= valueB = " << result << endl;
	result *= valueA;
	cout << "result *= valueA = " << result << endl;
	result /= valueB;
	cout << "result /= valueB = " << result << endl;
	result %= valueA;
	cout << "result %= valueA = " << result << endl;
#pragma endregion

#pragma region 논리 연산자
	// AND 연산자 &&
	// A조건 && B조건 = R
	// true && true = true
	// false && true = false
	// false && false = false
	// A와 B조건이 모두 참이여야만 참이된다.

	// OR 연산자 ||
	// A조건 || B조건 = R
	// true || true = true
	// false || true = true
	// false || false = false
	// A와 B조건이 중 하나만 참이여도 참이된다.

	int value = 75;

	if (value >= 50 && value <= 100)
	{
		cout << value << endl;
	}
#pragma endregion

#pragma region 조건문
	bool isDead = false;

	int x = 5;
	int y = 30;

	// y가 -10보다 작아지면 죽음
	// y가 20보다 커지면 죽음

	if (y < -10 || y > 20)
	{
		isDead = true;
	}

	if (isDead)
	{
		cout << "죽었을 때의 처리" << endl;
	}
#pragma endregion

#pragma region 반복문, 구구단
	int number = 2;
	int gugudan = 1;
	int result2 = 2;

	while (gugudan < 10)
	{
		result2 = number * gugudan;
		gugudan++;
		cout << number << " * " << gugudan << " = " << result2 << endl;
	}

	for (int i = 1; i < 10; i++)
	{
		cout << number << " * " << i << " = " << number * i << endl;
	}
#pragma endregion

#pragma region 별찍기
	for (int i = 4; i >= 0; i--)
	{
		cout << "*";

		for (int j = 0; j < i; j++)
		{
			cout << "*";
		}
		cout << endl;
	}
#pragma endregion

	return 0;
}