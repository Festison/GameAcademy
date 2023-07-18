#include<iostream>
using namespace std;

int* IntDynamicAllocation(int Item)
{
	int* x = new int;
	*x = Item;

	return x;
}

int main()
{
	// 동적 할당 : 런타임에 할당되는 것을 의미
	// 힙영역에 할당
	int x = 10;
	int* nPtr = new int;
	nPtr = &x;

	// 동적할당 방법
	// new 데이터타입  <- 데이터타입의 크기만큼 Heap에 할당되고
	// 그 주소를 가져옴.
	//가져온 주소를 포인터변수에 넣음.   	

	cout << *nPtr << endl;	// 동적 할당을 통해 우리가 빌린건 우리가 돌려줘야한다.
	delete nPtr;			// 따로 해제해주지 않으면 메모리의 누수가 발생

	return 0;
}

