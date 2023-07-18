#include <iostream>
using namespace std;

struct Student
{
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
};

int id = 0;

Student* CreateStudent()
{

    Student* tempPtr;
    tempPtr = new Student;

    string name;
    int grade;

    cout << "학생 이름 입력하세요 : ";
    cin >> name;
    cout << "학년을 입력하세요 : ";
    cin >> grade;

    tempPtr->Init(name, id, grade);

    id++;

    return tempPtr;
}

int main()
{
    Student* stArr[2];

    for (int i = 0; i < 2; i++)
    {
        stArr[i] = CreateStudent();
    }

    for (int i = 0; i < 2; i++)
    {
        stArr[i]->PrintInfo();
        delete stArr[i];
    }
}