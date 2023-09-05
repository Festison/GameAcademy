#include <iostream>
#include <float.h>
using namespace std;

//����ó���� �����ؼ�//
//������ �����Ӱ� �����ص���.
class Calculator
{
private:
    float prevResult = 0;
    float result = 0;
public:
    //���ϱ� ���� ���ϱ� ������
    void Sum(float numA, float numB)
    {
        result = numA + numB;
    }
    void Sub(float numA, float numB)
    {
        result = numA - numB;
    }
    void Mul(float numA, float numB)
    {
        result = numA * numB;
    }
    void Div(float numA, float numB)
    {
        if (numB == 0)
            throw 0;

        result = numA / numB;
    }

    void Cal(float numA, char op, float numB)
    {
        try
        {
            switch (op)
            {
            case '+':
                Sum(numA, numB);
                break;
            case '-':
                Sub(numA, numB);
                break;
            case '*':
                Mul(numA, numB);
                break;
            case '/':
                Div(numA, numB);
                break;
            }
            cout << numA << op << numB << "=" << result << endl;
            prevResult = result;
        }
        catch (int errorCode)
        {
            cout << "�߸��� �Է��� �ֽ��ϴ�." << endl;
        }

    }

    float GetPrevResult()
    {
        return prevResult;
    }
};


int main()
{
    Calculator cal;
    cal.Cal(10, '+', 60);
    cal.Cal(10, '/', 0);

    cout << cal.GetPrevResult() << endl;
}

