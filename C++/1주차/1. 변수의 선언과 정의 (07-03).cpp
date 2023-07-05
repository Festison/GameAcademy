#include<iostream>
using namespace std;

int main()
{
	// 상수 : 10,20 같은 정해져 있는 수
	// 변수 : 변할 수 있는 수
	// 변수의 선언, 변수의 정의
	// 변수의 선언 : 메모리를 할당한다.
	int num = 10;   // lvalue : 표현식 이후에도 사라지지 않는 값, 이름을 지니는 변수.
	num = num + 1;  // lvalue = rvalue : 표현식 이후에는 사라지는 임시적인 값, 임시 변수.

	++num; // lvalue
	num++; // rvalue
	cout << num << endl;

	num = 20;
	cout << num << endl;

	// 변수의 선언과 정의
	int num2 = 50;
	cout << num2 << endl;
	cout << num2 << " " << num << endl;
	cout << num2 + num << endl;

	// 변수의 명명 규칙
	// 카멜 케이스를 사용
	
	// 데이터 타입 변수명 
	// int    정수형 데이터 타입 : 10, 20
	// float  실수형 데이터 타입 : 1.0, 2.0
	// bool   논리형 데이터 타입 : true, false
	// char   문자형 데이터 타입 : 'a', 'b'
	int intValue;
	float floatValue;
	bool isCheck = true;
	char charValue = 'a';
	cout << charValue << endl;

	floatValue = 3.54f;
	cout << floatValue << endl;

	// 캐스팅(형변환)
	intValue = (int)3.54f;
	cout << intValue << endl;

	floatValue = intValue;
	cout << floatValue << endl;

	// cout은 출력문
	cout << "Hello World" << endl;

	return 0;
}