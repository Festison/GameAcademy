#include <iostream>
using namespace std;

struct Pencil
{
	int num;
};

// ������, �Ҹ���//
struct Student
{
	Pencil pencil; // Has a ����

	//���������� : private public
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
		cout << "--�л����� ���--" << endl;
		cout << name << endl;
		cout << id << endl;
		cout << grade << endl;
		cout << "---------------" << endl;
	}

	// ����ü��()   // ������
	Student()
	{
		cout << "�Ҵ� ��" << endl;
		// �޸𸮿� �Ҵ� �ɶ� ȣ��Ǵ� �Լ�
	}

	Student(string name, int id, int grade)
	{
		Init(name, id, grade);
		cout << name << "�Ҵ� ��" << endl;
	}

	// ~����ü��()   // �Ҹ���
	~Student()
	{
		cout << name << "���� ��" << endl;
		// �޸𸮿��� �����ɶ� ȣ��Ǵ� �Լ�
		// �Ҹ��ڸ� ȣ���Ѵٰ� �޸𸮰� �����Ǵ°��� �ƴϴ�.
	}
};

Student stB("��������", 1, 1);

int main()
{
	Student stA("�����Լ���������", 1, 1);
	Student* ptr; // ������ ������ Student�� �ƴϹǷ� ������ �Ҹ��ڰ� ȸ����� �ʴ´�.

	ptr = new Student("�����Ҵ�Ⱥ���", 1, 1);
	delete ptr;
}