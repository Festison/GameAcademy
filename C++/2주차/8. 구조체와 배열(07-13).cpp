#include <iostream>
using namespace std;

struct Student
{
	int id;
	int age;
	bool isDead;
};

void InitStudentsID(Student arr[])
{
	for (int i = 0; i < 3; i++)
	{
		arr[i].id = i;
	}
}

void PrintStudentsID(Student arr[])
{
	for (int i = 0; i < 3; i++)
	{
		cout << arr[i].id << endl;
	}
}

int main()
{
	int num = 9999;
	int intArr[3];
	intArr[0] = num;
	intArr[0] = 50;

	//위와 아래는 동일함//

	Student studentA;
	studentA.id = 9999;
	Student arr[3];
	arr[0] = studentA;
	arr[0].id = 50;
}