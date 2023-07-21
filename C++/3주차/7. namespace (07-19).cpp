#include<iostream>
using namespace std;

// namespace는 단순히 영역의 구분하기 위한것
// 동명의 변수나 함수가 생겼을때 충돌을 방지하기 위해 사용

// A개발자
namespace A
{
	int num;
	void Print()
	{
		cout << "메뉴를 출력하는 함수" << endl;
	}
}

// B개발자
namespace B
{
	int num;
	void Print()
	{
		cout << "학생의 정보를 출력하는 함수" << endl;
	}
}

// using namespace는 해당 영역의 변수와 함수를 디폴트로 사용한다는 것
int main()
{
	B::Print();
	A::Print();
	B::num = 10;
}