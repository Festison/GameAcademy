#include<iostream>
using namespace std;

// 속성과 기능이 같이 있을때 객체라하며 캡슐화를 시킨것이다.
struct Student
{
	// 접근 제한자를 통한 정보은닉
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
		cout << "--정보출력--" << endl;
		cout << id << endl;
		cout << age << endl;

		if (isDead)
		{
			cout << "죽었음" << endl;
		}
		cout << "-----------" << endl;
	}
};

int main()
{
	// 인스턴스 화
	Student stuA;
	Student stuB;

	stuA.SetStudent(0, 10, true);
	stuA.PrintInfo();

	stuB.SetStudent(1, 12, false);
	stuB.PrintInfo();

	return 0;
}
