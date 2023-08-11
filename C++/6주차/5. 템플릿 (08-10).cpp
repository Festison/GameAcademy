#include <iostream>
using namespace std;

//템플릿//
//여러가지 확장할 수 있게 해주는 틀
/*
int Add(int nA, int nB)
{
   return nA + nB;
}

float Add(float nA, float nB)
{
   return nA + nB;
}
*/
//Add라고 하는 동일한 기능을 수행하는 함수가
//쓰고자하는 데이터타입의 수만큼 똑같은게 계속 오버로딩을 해야됨.

//template<typename T> 데이터타입의 추상화 혹은 일   반화
//리턴타입 함수명(매개변수) { } //템플릿화 한 함수

struct A
{
    int value;


    int Plus(A& target)
    {
        return value + target.value;
    }

    int operator+(A& ref)
    {
        return this->value + ref.value;
    }
};

template<typename T>
int Add(T nA, T nB)
{
    return nA + nB;
}

void main()
{

    A aInstance;
    aInstance.value = 30;
    A aInstance2;
    aInstance2.value = 10;

    int a = 30;
    int b = 10;
    cout << a + b << endl;
    //cout << aInstance.Plus(aInstance2) << endl;
    cout << aInstance + aInstance2 << endl;

    //cout << Add(aInstance, aInstance2) << endl;
}
