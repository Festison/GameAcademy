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
	// ���� �Ҵ� : ��Ÿ�ӿ� �Ҵ�Ǵ� ���� �ǹ�
	// �������� �Ҵ�
	int x = 10;
	int* nPtr = new int;
	nPtr = &x;

	// �����Ҵ� ���
	// new ������Ÿ��  <- ������Ÿ���� ũ�⸸ŭ Heap�� �Ҵ�ǰ�
	// �� �ּҸ� ������.
	//������ �ּҸ� �����ͺ����� ����.   	

	cout << *nPtr << endl;	// ���� �Ҵ��� ���� �츮�� ������ �츮�� ��������Ѵ�.
	delete nPtr;			// ���� ���������� ������ �޸��� ������ �߻�

	return 0;
}

