#include<iostream>
using namespace std;

// ���� ���� 
// �˾Ƽ� �ʱ�ȭ�� �ȴ�.
// ���α׷��� ������ ��ȯ�ȴ�.
int depth = 0;

// ��� �Լ� : �Լ����� �ڱ� �ڽ��� ȣ���� ����
int Factorial(int number)
{
	if (number == 1)
	{
		return 1;
	}

	return number * Factorial(number - 1);
}

int main()
{
	cout << Factorial(3) << endl;

	return 0;
}