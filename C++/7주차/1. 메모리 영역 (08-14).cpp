#include <iostream>
using namespace std;

struct A
{
    int valueA = 0;
    int valueB = 0;

    void PrintA()
    {

    }
    A()
    {
        cout << "�Ҵ� ��" << endl;
    }
    ~A()
    {
        cout << "�Ҹ� ��" << endl;
    }
};


void Foo()
{
    static A aGlobalInstance;
    aGlobalInstance.valueA++;
    cout << aGlobalInstance.valueA << endl;
}

int main()
{
    Foo();
    Foo();
    Foo();

    A aInstance;
    A* aPtr = new A;
    aPtr->valueA = 30;
    delete aPtr;
}
