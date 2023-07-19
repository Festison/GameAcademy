#include <iostream>
using namespace std;

struct Student
{
	int id;
	int age;
	bool isDead;
};

void PrintStudentInfo(Student stu)
{
	cout << "---ÇÐ»ý Á¤º¸---" << endl;
	cout << stu.age << endl;
	cout << stu.id << endl;
	cout << "---------------" << endl;
}

Student* SetStudent(Student* stuPtr)
{
	stuPtr->age = 50;

	return stuPtr;
}

int main()
{
	Student studentA;
	studentA.age = 10;
	studentA.id = 0;
	studentA.isDead = false;

	cout << SetStudent(&studentA)->isDead << endl;
	PrintStudentInfo(*SetStudent(&studentA));
}
