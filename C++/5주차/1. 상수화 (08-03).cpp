#include<iostream>
using namespace std;

// define ��ó���⸦ ���� �ɺ��� ���
#define MAX_ARR_SIZE_DEF 195

// ��� : ������ �ʴ� ��
// const�� ��Ÿ�� ������ Ÿ�� �� �� ��� ������ ���ȭ Ű����
// constexpr�� ������ �ð������� ��� ������ ���ȭ Ű���� cin >> �� ���� �Է� �޴� ���� �Ұ���
constexpr int constExprInt = 10;
const int MAX_ARR_SIZE = 195;

int* Foo(int* value)
{
	*value = 40;
	cout << *value << endl;
	return value;
}

// �Ű������� const Ű���带 ���� ���ȸ �� �����̸�,
// �Լ������� ������ �� ����.
const int* ConstFoo(const int* value)
{
	// *value = 40; //const Ű����� ���� �ּ� ���� ��, ���� �Ұ���
	cout << *value << endl;
	return value;
}

int main()
{
	int numA = 30;
	int numB = 50;

	*Foo(&numA) = 80;
	// ���� �� Ÿ���� const int* �̱⶧���� �ּҾ��� �� ���� �Ұ���
	// *ConstFoo(&numB) = 80;

	const int* nPtrA = &numA;		// ������ ������Ÿ�� ���� const�� �ּҿ� �ִ� ���� ���ȭ
	int* const nPtrB = &numA;		// ������ ������Ÿ�� ���� const�� �ּ���ü�� ���ȭ
	const int* const nPtrC = &numA;	// �Ѵ� ���ȭ

	nPtrA = &numB;
	// �Ұ��� nPtrB = &numB;
	// �Ұ��� nPtrC = &numB;

	// �Ұ��� *nPtrA = 20;
	*nPtrB = 20;
	// �Ұ��� *nPtrC = 20;

	cout << MAX_ARR_SIZE << endl;
	cout << MAX_ARR_SIZE_DEF << endl;

	return 0;
}