#include<iostream>
using namespace std;

int main()
{
#pragma region ��Ģ ����
	// ������
	// ��Ģ����
	// +, -, *, /

	int valueA = 10;
	int valueB = 20;
	int result = 0;

	result += valueA;
	cout << "result += valueA = " << result << endl;
	result -= valueB;
	cout << "result -= valueB = " << result << endl;
	result *= valueA;
	cout << "result *= valueA = " << result << endl;
	result /= valueB;
	cout << "result /= valueB = " << result << endl;
	result %= valueA;
	cout << "result %= valueA = " << result << endl;
#pragma endregion

#pragma region �� ������
	// AND ������ &&
	// A���� && B���� = R
	// true && true = true
	// false && true = false
	// false && false = false
	// A�� B������ ��� ���̿��߸� ���̵ȴ�.

	// OR ������ ||
	// A���� || B���� = R
	// true || true = true
	// false || true = true
	// false || false = false
	// A�� B������ �� �ϳ��� ���̿��� ���̵ȴ�.

	int value = 75;

	if (value >= 50 && value <= 100)
	{
		cout << value << endl;
	}
#pragma endregion

#pragma region ���ǹ�
	bool isDead = false;

	int x = 5;
	int y = 30;

	// y�� -10���� �۾����� ����
	// y�� 20���� Ŀ���� ����

	if (y < -10 || y > 20)
	{
		isDead = true;
	}

	if (isDead)
	{
		cout << "�׾��� ���� ó��" << endl;
	}
#pragma endregion

#pragma region �ݺ���, ������
	int number = 2;
	int gugudan = 1;
	int result2 = 2;

	while (gugudan < 10)
	{
		result2 = number * gugudan;
		gugudan++;
		cout << number << " * " << gugudan << " = " << result2 << endl;
	}

	for (int i = 1; i < 10; i++)
	{
		cout << number << " * " << i << " = " << number * i << endl;
	}
#pragma endregion

#pragma region �����
	for (int i = 4; i >= 0; i--)
	{
		cout << "*";

		for (int j = 0; j < i; j++)
		{
			cout << "*";
		}
		cout << endl;
	}
#pragma endregion

	return 0;
}