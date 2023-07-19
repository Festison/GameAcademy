#include <iostream>
using namespace std;

struct Student
{
	int id;
};

void InitStudentsID(Student* arr[])
{
	for (int i = 0; i < 3; i++)
	{
		arr[i]->id = i;
	}
}

void PrintStudentsID(Student* arr[])
{
	for (int i = 0; i < 3; i++)
	{
		cout << arr[i]->id << endl;
	}
}

int main()
{
	Student stuA;
	stuA.id = 0;
	Student stuB;
	stuB.id = 0;
	Student stuC;
	stuC.id = 0;

	//주소의 배열이기때문에 원소를 변경하면 원본이 바뀜.
	Student* stuArrPtr[3];

	stuArrPtr[0] = &stuA;
	stuArrPtr[1] = &stuB;
	stuArrPtr[2] = &stuC;

	InitStudentsID(stuArrPtr);
	PrintStudentsID(stuArrPtr);

	cout << stuC.id << endl;

	return 0;
}
