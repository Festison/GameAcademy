#include<iostream>
using namespace std;

// �����ʹ� �޸��� �ּҸ� ������ �ִ� ����(�ּ� ���� ���� �޸� ���� (���� ����))
// ���۷����� �ڽ��� �����ϴ� ������ ����� �� �ִ� �� �ϳ��� �̸��̴�.�� ����(���� ���� ���ؼ� �޸𸮸� �����Ѵ�.(���� ����))

// �����Ϳ� ���۷����� ������ :
// 1. null�ʱ�ȭ : �����ʹ� null�ʱ�ȭ ���� ���۷����� �Ұ��� ���� �ݵ�� ����� ���ÿ� �ʱ�ȭ �ʿ�
// 2. �޸� ������ �Ҹ� : �����ʹ� �ּҰ��� �����ϱ����� ������ �޸� ���� ���, ���۷����� �����̱� ������ ���� �޸� ���� ����
// 3. �ּ� ���޹��(call by address), ���� ���޹��(call by reference)

// �� ���� ��巹�� �ּҸ����� ����
void Swap(int* aPtr, int* bPtr)
{
	int temp;
	temp = *aPtr;
	*aPtr = *bPtr;
	*bPtr = temp;
}

// �� ���� ���� ���� ���� ����
void Swap(int a, int b)
{
	int temp;
	temp = a;
	a = b;
	b = temp;
}

// �� ���� ���۷��� �����ڸ� ���� ����
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

	// ������ ������Ÿ�� &
	// �����ڴ� �����̱� ������ ����� ���ÿ� �ʱ�ȭ�� �ؾ��Ѵ�.
	int& nRef = numA;
	nRef = numB; // numA�� 50�� ���� �ȴ�. �̷��� ���� ������ ����� ���ÿ� �ʱ�ȭ�� �ʿ�

	// �����ͺ����� �ּҸ� ���� �� �ִ� ������ �ֱ⶧����,
	// �����ͺ������� �ּҸ� ������ �� �ִ�.
	// �� ���� �������� ����ų �� �ִ�.
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