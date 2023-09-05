#include<iostream>
using namespace std;

// 예외 처리 //
// 예외는 일반적이지 않은 것
// 예외처리는 일반적이지 않은 경우에 대한 처리를 말함

// 1. 다양한 추론이나 테스트를 통해 예외를 인지한다.
// 2. 인지된 예외에 대해서 일반적인경우와 별개의 처리를한다.

class A
{
public:
    int GetNum()
    {
        return num;
  }

private:
    int num = 10;
};

int main()
{
    const int ARR_SIZE = 3;
    int arr[ARR_SIZE];

    arr[0] = 10;
    arr[1] = 20;
    arr[2] = 30;

    int input = 5;
    A* aPtr = new A;

    try
    {
        if (aPtr == nullptr)
        {
            throw 0;
        }

        if (input >= ARR_SIZE)
        {
            throw 1;
        }

        arr[input] = 60;

        aPtr->GetNum();
    }
    // throw를 날리면 가장 가까운 catch로 간다.
    catch (int errorCode)
    {
        switch (errorCode)
        {
        case 0:
            cout << "nullptr에 접근할 수 없습니다." << endl;
            break;
        case 1:
            cout << "arr의 index범위를 초과했습니다." << endl;
            break;
        }
    }

    cout << "다른 처리가 진행됨" << endl;
    cout << "다른 처리가 진행됨" << endl;
    cout << "다른 처리가 진행됨" << endl;

    cout << "다른 처리가 진행됨" << endl;
    cout << "다른 처리가 진행됨" << endl;

}