#include<iostream>
using namespace std;

// ���� ó�� //
// ���ܴ� �Ϲ������� ���� ��
// ����ó���� �Ϲ������� ���� ��쿡 ���� ó���� ����

// 1. �پ��� �߷��̳� �׽�Ʈ�� ���� ���ܸ� �����Ѵ�.
// 2. ������ ���ܿ� ���ؼ� �Ϲ����ΰ��� ������ ó�����Ѵ�.

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
    // throw�� ������ ���� ����� catch�� ����.
    catch (int errorCode)
    {
        switch (errorCode)
        {
        case 0:
            cout << "nullptr�� ������ �� �����ϴ�." << endl;
            break;
        case 1:
            cout << "arr�� index������ �ʰ��߽��ϴ�." << endl;
            break;
        }
    }

    cout << "�ٸ� ó���� �����" << endl;
    cout << "�ٸ� ó���� �����" << endl;
    cout << "�ٸ� ó���� �����" << endl;

    cout << "�ٸ� ó���� �����" << endl;
    cout << "�ٸ� ó���� �����" << endl;

}