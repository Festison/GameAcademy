#include <iostream>
using namespace std;

//static Ű����
//���� �� �Լ��� �����Ϳ����� �Ҵ��Ű�� Ű����

int globalNum = 10;

void Foo()
{
    static int staticNum = 0;   //�����Ϳ����� �Ҵ�Ǿ� �Լ��� ������ ������������.
    int localNum = 0;       //���ÿ����� �Ҵ�Ǿ� �Լ��� ������ ����������.
    cout << "����ƽ ���� : " << staticNum << endl;
    cout << "���� ���� : " << localNum << endl;
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

//Ŭ������ ����ü�� static Ű���尡 ���� �Ӽ�(�������)�̳� ���(����Լ�)��
//�ش� Ŭ������ ���� ��ü(�ν��Ͻ�, ����) �� �����ϰ� ���������� �����Ѵ�. 
class Character
{
protected:
    int hp;
    //staticó���� ������ ��ü�� ������ �����ϰ� �̹� �Ҵ�Ǿ��ִ�.
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

//��ü�� ������ �����ϰ� �Ҵ�Ǿ���ϱ⶧���� ������ �������� �������־����.
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
    //��ü�� �Ҵ����� �ʾ������� Ŭ������ü�� �����Ͽ� �Լ��� ȣ������ Ȯ���� �� �ִ�.
    cout << Character::GetCharacterCount() << endl;

    cout << Point::initPoint.x << endl;


    Point p1(10, 30);

    cout << p1.x << endl;
    cout << p1.y << endl;

    Point* p2PTr = new Point(50, 20);

    cout << p2PTr->x << endl;
    cout << p2PTr->y << endl;
}
