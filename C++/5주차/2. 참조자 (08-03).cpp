#include<iostream>
using namespace std;

// 포인터는 메모리의 주소를 가지고 있는 변수(주소 값을 통한 메모리 접근 (간접 참조))
// 레퍼런스는 자신이 참조하는 변수를 대신할 수 있는 또 하나의 이름이다.즉 별명(변수 명을 통해서 메모리를 참조한다.(직접 참조))

// 포인터와 레퍼런스의 차이점 :
// 1. null초기화 : 포인터는 null초기화 가능 레퍼런스는 불가능 또한 반드시 선언과 동시에 초기화 필요
// 2. 메모리 공간의 소모 : 포인터는 주소값을 저장하기위해 별도의 메모리 공간 사용, 레퍼런스는 별명이기 떄문에 같은 메모리 공간 참조
// 3. 주소 전달방식(call by address), 참조 전달방식(call by reference)

// 콜 바이 어드레스 주소를통한 접근
void Swap(int* aPtr, int* bPtr)
{
	int temp;
	temp = *aPtr;
	*aPtr = *bPtr;
	*bPtr = temp;
}

// 콜 바이 벨류 값을 통한 접근
void Swap(int a, int b)
{
	int temp;
	temp = a;
	a = b;
	b = temp;
}

// 콜 바이 레퍼런스 참조자를 통한 접근
void Swap(int& aRef, int& bRef)
{
	int temp;
	temp = aRef;
	aRef = bRef;
	bRef = temp;
}

int main()
{
	int numA = 30;
	int numB = 50;

	// 참조자 데이터타입 &
	// 참조자는 별명이기 떄문에 선언과 동시에 초기화를 해야한다.
	int& nRef = numA;
	nRef = numB; // numA에 50이 대입 된다. 이러한 이유 때문에 선언과 동시에 초기화가 필요

	// 포인터변수는 주소를 담을 수 있는 공간이 있기때문에,
	// 포인터변수안의 주소를 변경할 수 있다.
	// 즉 여러 변수들을 가르킬 수 있다.
	int* nPtr = &numA;

	*nPtr = 0;
	nPtr = &numB;
	*nPtr = 0;

	cout << numA << endl;
	nRef = numB;
	cout << numA << endl;
	nRef = 60;
	cout << numA << endl;
}