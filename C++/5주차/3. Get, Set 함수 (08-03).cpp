#include <iostream>
using namespace std;

class Player
{
private:
	int hp = 100;
	int atk = 10;
public:
	// �Լ��� () �ڿ� constŰ���尡 �ڿ� ������ ��� �������� ���� �� �Լ������� ������ �� ���ٴ� ��
	// Get, Set �Լ� ���� �� �� ���� �Ӽ��� �����ϱ� ���� �Լ�
	const int& GetHp() const
	{
		return hp;
	}

	int GetHp()
	{
		// hp�� Rvalue �ӽð�
		return hp;
	}

	void SetHp(int _hp)
	{
		hp = _hp;
	}
};

int main()
{
	int num = 10;
	int& nRef = num;

	//������ �ּҰ� �����°��� Ȯ���غ���
	//���� ���� ���� ���ϴ°��� �� �� �ִ�.
	cout << &num << endl;
	cout << &nRef << endl;

	const int test = 10;
	nRef = 50;

	const int& nConstRef = test;
	// test = 30;
	// nConstRef = 60;

}