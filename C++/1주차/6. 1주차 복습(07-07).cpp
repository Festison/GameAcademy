#include<iostream>
using namespace std;

// Call By Address
void Swap(int* x, int* y)
{
	int temp = 0;
	temp = *x;
	*x = *y;
	*y = temp;
}

// Call By Value
#pragma region �Լ� ����
// �Լ��� ���
// �Լ��� ����� ����

// �Լ��� ����
// ����Ÿ�� �Լ��� (�Ű�����..)
//{
//		�Լ��� ����
//}

// input�� ���� output�� ���� �Լ�
void Foo()
{
	cout << "TEST �Լ� ����" << endl;
	cout << "TEST �Լ� ����" << endl;
	cout << "TEST �Լ� ����" << endl;
}

// input�� ���� output�� �ִ� �Լ�
int GetNumberOne() // rvalue
{
	cout << "GetNumberOne�Լ� ����" << endl;

	// 1�� ������ ���ư���. 
	// GetNumberOne�� 1�� �ȴ�.
	return 1;
}
// input�� �ְ� output�� ���� �Լ�
void PrintNumber(int n)
{
	cout << "n�� ���� : " << n << endl;
}

/// <summary>
/// �ΰ����� ���� ���ϴ� �Լ� �Դϴ�.
/// </summary>
/// <param name="a">ù��° ���� ��</param>
/// <param name="b">�ι��� ���� ��</param>
/// <returns></returns>
/// input�� �ְ� output�� �ִ� �Լ�
int Sum(int a, int b)
{
	return a + b;
}
#pragma endregion

#pragma region ����Լ� ����
void Func(int n)
{
	if (n <= 0)
	{
		return;
	}

	Func(n - 1);
}

int TotalSum(int n)
{
	if (n == 1)
	{
		return 1;
	}

	return n + TotalSum(n - 1);
}

int Factorial(int number)
{
	if (number == 1)
	{
		return 1;
	}

	return number * Factorial(number - 1);
}
#pragma endregion

int main()
{
#pragma region ���ǹ��� �ݺ��� ����
	bool isCheck = false;
	int state = 0; // 0: �⺻ 1: �۵� 2: ������� 3: ����

	// ���ǹ� switch case��
	switch (state)
	{
	case 0:
		cout << "�⺻ ���� ó��" << endl;
		break;
	case 1:
		cout << "�۵� ���� ó��" << endl;
		break;
	case 2:
		cout << "������� ���� ó��" << endl;
		break;
	case 3:
		cout << "���� ���� ó��" << endl;
		break;
	default:
		break;
	}

	// ���ǹ� if��, else if�� else��
	if (state == 1)
	{
		cout << "�۵� ���� ó��" << endl;
	}
	else if (state == 2)
	{
		cout << "������� ���� ó��" << endl;
	}
	else if (state == 3)
	{
		cout << "���� ���� ó��" << endl;
	}
	else
	{
		cout << "�⺻ ���� ó��" << endl;
	}

	// �ݺ��� while�� (����)
	//{
	//	������ ���� ���� ����Ǵ� ����
	//}

	int i = 0;
	while (i < 10)
	{
		cout << i << endl;
		i++;
	}

	// �ݺ��� for��
	// for(�����; ���ǽ�; ������)
	for (int i = 0; i < 10; i++)
	{
		// break�� : �ݺ����� Ż��
		if (i == 5)
		{
			break;
		}
		// continue�� : ���ǹ��� Ż���ϰ� �ݺ����� �ٽ� ����
		if (i % 2 == 0)
		{
			continue;
		}
		cout << i << endl;
	}
#pragma endregion

#pragma region ������ ����
	// ������ ���� : �ּҸ� ������ ��� ����
	int num = 10;
	// nullptr�� ������ �����ϰ� �ڵ��� �������� �ø���.
	int* nPtr = nullptr;
	nPtr = &num;

	cout << num << endl;
	// &������ , ������ �ּ�
	cout << &num << endl;
	// *�ּ� , �ּҾ��� ��
	cout << *&num << endl;
	cout << nPtr << endl;
	cout << *nPtr << endl;

	*nPtr = 30;
	cout << num << endl;

	int a = 30;
	int b = 50;

	cout << "���� �� : " << a << " " << b << endl;
	Swap(&a, &b);
	cout << "���� �� : " << a << " " << b << endl;


#pragma endregion


	return 0;
}