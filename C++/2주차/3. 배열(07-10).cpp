#include<iostream>
using namespace std;

int main()
{
	// �迭 
	// �迭 : ������ ������Ÿ���� ����
	int scores[3];
	scores[0] = 80;
	scores[1] = 70;
	scores[2] = 50;

	// �迭�� ���� �ּ�
	cout << scores << endl;

	// �迭�� �޸𸮳����� �������� �帧�� ������ �ִ�.
	for (int i = 0; i < 3; i++)
	{
		cout << i << "��°�� �� : " << scores[i] << endl;
		cout << i << "��°�� �ּ� : " << &scores[i] << endl;
	}
	cout << endl;

	cout << &scores[0] << endl;
	cout << &scores[0] + 1 << endl; // ù��° ������ �ּ�
	cout << &scores[0] + 2 << endl; // �ι�° ������ �ּ�
	cout << endl;

	cout << *(&scores[0]) << endl;
	cout << *(&scores[0] + 1) << endl;
	cout << *(&scores[0] + 2) << endl;
	cout << endl;

	int num = 1784;
	int array[10];
	int tempArr[10];

	for (int i = 0; i < 10; i++)
	{
		array[i] = -1;
	}

	int count = 0;
	while (num > 0)
	{
		tempArr[count] = num % 10;
		num = num / 10;
		count++;
	}

	for (int i = 0; i < count; i++)
	{
		array[count - 1 - i] = tempArr[i];
	}

	for (int i = 0; i < 10; i++)
	{
		cout << array[i] << endl;
	}

	return 0;
}