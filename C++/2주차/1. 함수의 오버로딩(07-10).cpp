#include<iostream>
using namespace std;

void PrintMenu()
{
	cout << "-------------" << endl;
	cout << "---Default---" << endl;
	cout << "-------------" << endl;
	cout << endl;
}

void PrintMenu(int i)
{
	cout << "-------------" << endl;
	cout << "----Menu" << i << "----" << endl;
	cout << "-------------" << endl;
	cout << endl;
}

void ShowInventory()
{
	int inventorySize = 10;

	cout << "--------Inventory--------" << endl;

	for (int i = 0; i < inventorySize; i++)
	{
		cout << i << "���� �κ��丮 ������" << endl;
	}

	cout << "--------Inventory--------" << endl;
	cout << endl;
}

void ShowInventory(int index)
{
	cout << index << "��° �κ��丮 ������" << endl;
	cout << endl;
}

void ShowInventory(float value)
{
	cout << "�߸��� ������Ÿ�� �ӷµ�" << endl;
	cout << endl;
}

void ShowInventory(char ch)
{
	cout << "������ ������ Ÿ�� �Է�" << endl;
	cout << endl;
}

void ShowInventory(bool pro)
{
	cout << "�� �Ǵ� ����" << endl;
	cout << endl;
}

int main()
{
	// �Լ� �����ε� : �Լ��� �̸��� ���Ƶ� �Ű������� ���� �پ��� ����� �������� �ϴ� ���
	// ������

	PrintMenu();
	PrintMenu(2);
	ShowInventory();
	ShowInventory(8);
	ShowInventory(3.54f);
	ShowInventory('a');
	ShowInventory(true);

	return 0;
}