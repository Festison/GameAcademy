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
        cout << "ÇÒ´ç µÊ" << endl;
    }
    ~A()
    {
        cout << "¼Ò¸ê µÊ" << endl;
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
