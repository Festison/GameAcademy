#include<iostream>
using namespace std;

// �Լ��� ����� ����
// �Լ��� ����

// �Լ��� �Ľ�Į ǥ����� ���
// ���� Ÿ�� �Լ��� (�Ű�����)
// {
//		�Լ��� ����
// }

// input�� ���� output�� ���� �Լ�
void ShowInventoryMenu()
{
	cout << "----------------Invnetory---------------" << endl;
}

// input�� ������ output�� �ִ� �Լ�
int GetNumberOne()
{
	return 1;
}

// input�� ������ output�� ���� �Լ�
void PrintNumber(int inputA)
{
	cout << inputA << endl;
}

// input�� �ְ� output�� �ִ� �Լ�
int IntegerConversion(float value)
{
	cout << "�Ű����� value�� �� : " << value << endl;
	return value;
}

// �ּҰ��� �ִ밪, Ÿ���� �Ǵ� ���� ���� ��,
// �ּҰ� < Ÿ�ٰ� < �ִ밪
// Ÿ�ٰ��� �ּҰ��� �ִ밪 ���̿� �ִ��� üũ�ϴ� ���

bool BeetweenCheck(int min, int target, int max)
{
	bool isCheck = false;

	if (target >= min && target <= max)
	{
		isCheck = true;
	}

	if (isCheck == true)
	{
		cout << "���Դϴ�." << endl;
	}

	return isCheck;
}

int Gugudan(int i, int j)
{
	return i * j;
}

int main()
{
	// �Լ�
	// �Լ��� ����̴�.

	float num = 65.87f;
	ShowInventoryMenu();
	cout << GetNumberOne() << endl;
	PrintNumber(num);
	cout << IntegerConversion(num) << endl;
	BeetweenCheck(50, 75, 100);

	for (int i = 1; i < 10; i++)
	{
		for (int j = 1; j < 10; j++)
		{
			cout << i << " * " << j << " = " << Gugudan(i, j) << endl;
		}
	}

	return 0;
}

