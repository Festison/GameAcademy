#include <iostream>
using namespace std;

//static 키워드
//변수 및 함수를 데이터영역에 할당시키는 키워드

int globalNum = 10;

void Foo()
{
    static int staticNum = 0;   //데이터영역에 할당되어 함수가 끝나도 해제되지않음.
    int localNum = 0;       //스택영역에 할당되어 함수가 끝나면 같이해제됨.
    cout << "스테틱 변수 : " << staticNum << endl;
    cout << "지역 변수 : " << localNum << endl;
    staticNum++;
    localNum++;
}

struct Point
{
    static Point initPoint;

    int x;
    int y;

    Point(int x, int y)
    {
        this->x = x;
        this->y = y;
    }
};

Point Point::initPoint = { 0,0 };

//클래스나 구조체에 static 키워드가 붙은 속성(멤버변수)이나 기능(멤버함수)은
//해당 클래스로 찍어내는 객체(인스턴스, 변수) 와 무관하게 독립적으로 존재한다. 
class Character
{
protected:
    int hp;
    //static처리된 변수는 객체의 생성과 무관하게 이미 할당되어있다.
    static int characterCount;
public:
    Character()
    {
        characterCount++;
    }
    ~Character()
    {
        characterCount--;
    }

    static int GetCharacterCount()
    {
        return characterCount;
    }
};

//객체의 생성과 무관하게 할당되어야하기때문에 전역의 영역에서 정의해주어야함.
int Character::characterCount = 10;

void main()
{
    int localNum = 30;
    cout << globalNum << endl;
    cout << localNum << endl;

    for (int i = 0; i < 10; i++)
    {
        Foo();
    }

    //Character ch; 
    //객체를 할당하지 않았음에도 클래스자체에 접근하여 함수를 호출함을 확인할 수 있다.
    cout << Character::GetCharacterCount() << endl;

    cout << Point::initPoint.x << endl;


    Point p1(10, 30);

    cout << p1.x << endl;
    cout << p1.y << endl;

    Point* p2PTr = new Point(50, 20);

    cout << p2PTr->x << endl;
    cout << p2PTr->y << endl;
}
