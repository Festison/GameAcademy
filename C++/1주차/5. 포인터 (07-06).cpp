#include<iostream>
using namespace std;

void Swap(int* x, int* y)
{
	int temp = 0;
	temp = *x;
	*x = *y;
	*y = temp;
}

void ValueChange(int* value)
{
	*value = 50;
}

int main()
{
	// 포인터 변수의 주소의 크기는 4바이트 및 8바이트로 고정, 디버거의 바이트 크기를 따라간다.
	int num = 30;

	// 포인터 변수 : 주소를 담는 변수
	int* numPtr = &num;

	cout << "num의 값 " << num << endl;

	// &변수명 : 변수의 주소
	cout << "num의 주소 " << &num << endl;
	cout << "numPtr의 값 " << numPtr << endl;

	// *주소 : 해당 주소의 값
	cout << "numPtr이 가리키는 값 " << *numPtr << endl;
	cout << "numPtr의 주소" << &numPtr << endl;

	ValueChange(&num);

	cout << num << endl;

	int a = 30;
	int b = 50;

	cout << "스왑 전 : " << a << " " << b << endl;
	Swap(&a, &b);
	cout << "스왑 후 : " << a << " " << b << endl;

	return 0;
}
