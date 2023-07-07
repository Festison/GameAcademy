#include<iostream>
using namespace std;

// 전역 변수 
// 알아서 초기화가 된다.
// 프로그램이 끝날때 반환된다.
int depth = 0;

// 재귀 함수 : 함수에서 자기 자신을 호출해 수행
int Factorial(int number)
{
	if (number == 1)
	{
		return 1;
	}

	return number * Factorial(number - 1);
}

int main()
{
	cout << Factorial(3) << endl;

	return 0;
}