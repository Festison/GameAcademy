#include <iostream>
using namespace std;

struct SchoolMember
{
    string name;
    int id;

    //가상 함수// //자식에서 재정의된 함수가 있으면 자식함수 호출
    virtual void PrintInfo()
    {
        cout << "--학교 멤버 정보 출력--" << endl;
        cout << name << endl;
        cout << id << endl;
        cout << "---------------" << endl;
    }
};

struct Student : SchoolMember
{
    int grade;

    //부모와 동명의 함수를 자식이 덮어씀 ( 함수의 오버라이딩 )
    void PrintInfo()
    {
        cout << "--학생 멤버 정보 출력--" << endl;
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
        cout << "--선생 멤버 정보 출력--" << endl;
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
    tc.className = "유니티";
    tc.id = 0;
    tc.name = "임용규";

    Student stu;
    stu.grade = 3;
    stu.id = 1;
    stu.name = "학생A";
    stu.PrintInfo();

    scmPtr = &tc;
    scmPtr->PrintInfo();
    scmPtr = &stu;
    scmPtr->PrintInfo();
}