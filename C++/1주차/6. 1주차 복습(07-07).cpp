#include<iostream>
using namespace std;

// Call By Address
void Swap(int* x, int* y)
{
	int temp = 0;
	temp = *x;
	*x = *y;
	*y = temp;
}

// Call By Value
#pragma region 함수 복습
// 함수는 기능
// 함수의 선언과 정의

// 함수의 선언
// 리턴타입 함수명 (매개변수..)
//{
//		함수의 내용
//}

// input도 없고 output도 없는 함수
void Foo()
{
	cout << "TEST 함수 실행" << endl;
	cout << "TEST 함수 실행" << endl;
	cout << "TEST 함수 실행" << endl;
}

// input은 없고 output은 있는 함수
int GetNumberOne() // rvalue
{
	cout << "GetNumberOne함수 실행" << endl;

	// 1을 가지고 돌아간다. 
	// GetNumberOne이 1이 된다.
	return 1;
}
// input은 있고 output은 없는 함수
void PrintNumber(int n)
{
	cout << "n의 값은 : " << n << endl;
}

/// <summary>
/// 두가지의 값을 더하는 함수 입니다.
/// </summary>
/// <param name="a">첫번째 더할 값</param>
/// <param name="b">두번쨰 더할 값</param>
/// <returns></returns>
/// input도 있고 output도 있는 함수
int Sum(int a, int b)
{
	return a + b;
}
#pragma endregion

#pragma region 재귀함수 복습
void Func(int n)
{
	if (n <= 0)
	{
		return;
	}

	Func(n - 1);
}

int TotalSum(int n)
{
	if (n == 1)
	{
		return 1;
	}

	return n + TotalSum(n - 1);
}

int Factorial(int number)
{
	if (number == 1)
	{
		return 1;
	}

	return number * Factorial(number - 1);
}
#pragma endregion

int main()
{
#pragma region 조건문과 반복문 복습
	bool isCheck = false;
	int state = 0; // 0: 기본 1: 작동 2: 긴급정지 3: 정지

	// 조건문 switch case문
	switch (state)
	{
	case 0:
		cout << "기본 상태 처리" << endl;
		break;
	case 1:
		cout << "작동 상태 처리" << endl;
		break;
	case 2:
		cout << "긴급정지 상태 처리" << endl;
		break;
	case 3:
		cout << "정지 상태 처리" << endl;
		break;
	default:
		break;
	}

	// 조건문 if문, else if문 else문
	if (state == 1)
	{
		cout << "작동 상태 처리" << endl;
	}
	else if (state == 2)
	{
		cout << "긴급정지 상태 처리" << endl;
	}
	else if (state == 3)
	{
		cout << "정지 상태 처리" << endl;
	}
	else
	{
		cout << "기본 상태 처리" << endl;
	}

	// 반복문 while문 (조건)
	//{
	//	조건이 참인 동안 수행되는 구문
	//}

	int i = 0;
	while (i < 10)
	{
		cout << i << endl;
		i++;
	}

	// 반복문 for문
	// for(선언식; 조건식; 증감식)
	for (int i = 0; i < 10; i++)
	{
		// break문 : 반복문을 탈출
		if (i == 5)
		{
			break;
		}
		// continue문 : 조건문은 탈출하고 반복문을 다시 실행
		if (i % 2 == 0)
		{
			continue;
		}
		cout << i << endl;
	}
#pragma endregion

#pragma region 포인터 복습
	// 포인터 변수 : 주소를 값으로 담는 변수
	int num = 10;
	// nullptr을 가리켜 안전하고 코드의 가독성을 올린다.
	int* nPtr = nullptr;
	nPtr = &num;

	cout << num << endl;
	// &변수명 , 변수의 주소
	cout << &num << endl;
	// *주소 , 주소안의 값
	cout << *&num << endl;
	cout << nPtr << endl;
	cout << *nPtr << endl;

	*nPtr = 30;
	cout << num << endl;

	int a = 30;
	int b = 50;

	cout << "스왑 전 : " << a << " " << b << endl;
	Swap(&a, &b);
	cout << "스왑 후 : " << a << " " << b << endl;


#pragma endregion


	return 0;
}