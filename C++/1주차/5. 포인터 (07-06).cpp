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
	// �ּ��� ũ��� 4����Ʈ �� 8����Ʈ�� ����, ������� ����Ʈ ũ�⸦ ���󰣴�.
	int num = 30;

	// ������ ���� : �ּҸ� ��� ����
	int* numPtr = &num;

	cout << "num�� �� " << num << endl;

	// &������ : ������ �ּ�
	cout << "num�� �ּ� " << &num << endl;
	cout << "numPtr�� �� " << numPtr << endl;

	// *�ּ� : �ش� �ּ��� ��
	cout << "numPtr�� ����Ű�� �� " << *numPtr << endl;
	cout << "numPtr�� �ּ�" << &numPtr << endl;

	ValueChange(&num);

	cout << num << endl;

	int a = 30;
	int b = 50;

	cout << "���� �� : " << a << " " << b << endl;
	Swap(&a, &b);
	cout << "���� �� : " << a << " " << b << endl;

	return 0;
}