#include<iostream>
using namespace std;

// define 전처리기를 통한 심볼릭 상수
#define MAX_ARR_SIZE_DEF 195

// 상수 : 변하지 않는 수
// const는 런타임 컴파일 타임 둘 다 사용 가능한 상수화 키워드
// constexpr은 컴파일 시간에서만 사용 가능한 상수화 키워드 cin >> 을 통한 입력 받는 것이 불가능
constexpr int constExprInt = 10;
const int MAX_ARR_SIZE = 195;

int* Foo(int* value)
{
	*value = 40;
	cout << *value << endl;
	return value;
}

// 매개변수가 const 키워드를 통해 상수회 된 변수이면,
// 함수내에서 변경할 수 없다.
const int* ConstFoo(const int* value)
{
	// *value = 40; //const 키워드로 인해 주소 안의 값, 변경 불가능
	cout << *value << endl;
	return value;
}

int main()
{
	int numA = 30;
	int numB = 50;

	*Foo(&numA) = 80;
	// 리턴 된 타입이 const int* 이기때문에 주소안의 값 변경 불가능
	// *ConstFoo(&numB) = 80;

	const int* nPtrA = &numA;		// 포인터 데이터타입 앞의 const는 주소에 있는 값을 상수화
	int* const nPtrB = &numA;		// 포인터 데이터타입 뒤의 const는 주소자체를 상수화
	const int* const nPtrC = &numA;	// 둘다 상수화

	nPtrA = &numB;
	// 불가능 nPtrB = &numB;
	// 불가능 nPtrC = &numB;

	// 불가능 *nPtrA = 20;
	*nPtrB = 20;
	// 불가능 *nPtrC = 20;

	cout << MAX_ARR_SIZE << endl;
	cout << MAX_ARR_SIZE_DEF << endl;

	return 0;
}