#include <iostream>
using namespace std;

struct Pencil
{
	int num;
};

// 생성자, 소멸자//
struct Student
{
	Pencil pencil; // Has a 관계

	//접근제한자 : private public
private:
	string name;
	int id;
	int grade;

public:
	void Init(string name, int id, int grade)
	{
		this->name = name;
		this->id = id;
		this->grade = grade;
	}
	void PrintInfo()
	{
		cout << "--학생정보 출력--" << endl;
		cout << name << endl;
		cout << id << endl;
		cout << grade << endl;
		cout << "---------------" << endl;
	}

	// 구조체명()   // 생성자
	Student()
	{
		cout << "할당 됨" << endl;
		// 메모리에 할당 될때 호출되는 함수
	}

	Student(string name, int id, int grade)
	{
		Init(name, id, grade);
		cout << name << "할당 됨" << endl;
	}

	// ~구조체명()   // 소멸자
	~Student()
	{
		cout << name << "해제 됨" << endl;
		// 메모리에서 해제될때 호출되는 함수
		// 소멸자를 호출한다고 메모리가 해제되는것은 아니다.
	}
};

Student stB("전역변수", 1, 1);

int main()
{
	Student stA("메인함수내에변수", 1, 1);
	Student* ptr; // 포인터 변수는 Student가 아니므로 생성자 소멸자가 회출되지 않는다.

	ptr = new Student("동적할당된변수", 1, 1);
	delete ptr;
}