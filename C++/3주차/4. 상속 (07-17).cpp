#include <iostream>
using namespace std;

struct SchoolMember
{
    string name;
    int id;

    //���� �Լ�// //�ڽĿ��� �����ǵ� �Լ��� ������ �ڽ��Լ� ȣ��
    virtual void PrintInfo()
    {
        cout << "--�б� ��� ���� ���--" << endl;
        cout << name << endl;
        cout << id << endl;
        cout << "---------------" << endl;
    }
};

struct Student : SchoolMember
{
    int grade;

    //�θ�� ������ �Լ��� �ڽ��� ��� ( �Լ��� �������̵� )
    void PrintInfo()
    {
        cout << "--�л� ��� ���� ���--" << endl;
        cout << name << endl;
        cout << id << endl;
        cout << grade << endl;
        cout << "---------------" << endl;
    }
};

struct Teacher : SchoolMember
{
    string className;

    void PrintInfo()
    {
        cout << "--���� ��� ���� ���--" << endl;
        cout << name << endl;
        cout << id << endl;
        cout << className << endl;
        cout << "---------------" << endl;
    }
};

int main()
{
    SchoolMember* scmPtr;
    Teacher tc;
    tc.className = "����Ƽ";
    tc.id = 0;
    tc.name = "�ӿ��";

    Student stu;
    stu.grade = 3;
    stu.id = 1;
    stu.name = "�л�A";
    stu.PrintInfo();

    scmPtr = &tc;
    scmPtr->PrintInfo();
    scmPtr = &stu;
    scmPtr->PrintInfo();
}