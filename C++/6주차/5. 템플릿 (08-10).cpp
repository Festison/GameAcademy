#include <iostream>
using namespace std;

//���ø�//
//�������� Ȯ���� �� �ְ� ���ִ� Ʋ
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
//Add��� �ϴ� ������ ����� �����ϴ� �Լ���
//�������ϴ� ������Ÿ���� ����ŭ �Ȱ����� ��� �����ε��� �ؾߵ�.

//template<typename T> ������Ÿ���� �߻�ȭ Ȥ�� ��   ��ȭ
//����Ÿ�� �Լ���(�Ű�����) { } //���ø�ȭ �� �Լ�

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
