#include<iostream>
using namespace std;

// namespace�� �ܼ��� ������ �����ϱ� ���Ѱ�
// ������ ������ �Լ��� �������� �浹�� �����ϱ� ���� ���

// A������
namespace A
{
	int num;
	void Print()
	{
		cout << "�޴��� ����ϴ� �Լ�" << endl;
	}
}

// B������
namespace B
{
	int num;
	void Print()
	{
		cout << "�л��� ������ ����ϴ� �Լ�" << endl;
	}
}

// using namespace�� �ش� ������ ������ �Լ��� ����Ʈ�� ����Ѵٴ� ��
int main()
{
	B::Print();
	A::Print();
	B::num = 10;
}