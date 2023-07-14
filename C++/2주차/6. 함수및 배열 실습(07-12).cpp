#include <iostream>
using namespace std;

#pragma region 계산기 실습
float resultRecord[100][4][100];

int PLUS = 0;
int MINUS = 1;
int MUL = 2;
int DIV = 3;

float WRONG_VALUE = -99999;
float INIT_VALUE = 0;

float Sum(int numA, int numB)
{
    resultRecord[numA][PLUS][numB] = numA + numB;
    return resultRecord[numA][PLUS][numB];
}
float Sub(int numA, int numB)
{
    resultRecord[numA][MINUS][numB] = numA - numB;
    return resultRecord[numA][MINUS][numB];
}
float Mul(int numA, int numB)
{
    resultRecord[numA][MUL][numB] = numA * numB;
    return resultRecord[numA][MUL][numB];
}
float Div(int numA, int numB)
{
    resultRecord[numA][DIV][numB] = (float)numA / (float)numB;
    return resultRecord[numA][DIV][numB];
}
float Calculator(int numA, int op, int numB)
{
    float result = WRONG_VALUE;

    //numA = 5
    //op = 0 // '+'
    //numB = 3
    //resultRecord[5][0][3] == 0
    if (resultRecord[numA][op][numB] != INIT_VALUE)
    {
        cout << "한번 이상 계산되어 연산 안합니다." << endl;
        return resultRecord[numA][op][numB];
    }

    if (op == PLUS)
        result = Sum(numA, numB);
    else if (op == MINUS)
        result = Sub(numA, numB);
    else if (op == MUL)
        result = Mul(numA, numB);
    else if (op == DIV)
        result = Div(numA, numB);

    return result;
}

void ExcuteCaculator()
{
    int a;
    int b;
    char op;

    while (true)
    {
        cout << "식을 입력하세요 : ";
        cin >> a;
        cin >> op;
        cin >> b;

        if (op == '+')
            op = PLUS;
        else if (op == '-')
            op = MINUS;
        else if (op == '*')
            op = MUL;
        else if (op == '/')
            op = DIV;
        else
            break;

        cout << Calculator(a, (int)op, b) << endl;
    }
}
#pragma endregion

#pragma region 구구단 실습
int gugudan[10][10];

void GugudanInit() 
{
    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 10; j++)
        {
            gugudan[i][j] = i * j;
        }
    }
}
#pragma endregion

int main()
{
    GugudanInit();

    cout << gugudan[8][8] << endl;
}