#include<iostream>
using namespace std;

// �Ӽ��� ����� ���� ������ ��ü���ϸ� ĸ��ȭ�� ��Ų���̴�.
struct Student
{
	// ���� �����ڸ� ���� ��������
	// public, private

private:
	int id;
	int age;
	bool isDead;

public:
	void SetStudent(int _id, int _age, bool _isDead)
	{
		id = _id;
		age = _age;
		isDead = _isDead;
	}

	void PrintInfo()
	{
		cout << "--�������--" << endl;
		cout << id << endl;
		cout << age << endl;

		if (isDead)
		{
			cout << "�׾���" << endl;
		}
		cout << "-----------" << endl;
	}
};

int main()
{
	// �ν��Ͻ� ȭ
	Student stuA;
	Student stuB;

	stuA.SetStudent(0, 10, true);
	stuA.PrintInfo();

	stuB.SetStudent(1, 12, false);
	stuB.PrintInfo();

	return 0;
}