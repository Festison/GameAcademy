#include<iostream>
using namespace std;

// ���� ���
// ��������, ���������� �뵵�� �°� �� �� �ִ�(�ּ����� ���� ����)
// ���� : ���������� ���ÿ����� �Ҵ�Ǿ� ������ ������ ��ȯ�˴ϴ�. ���������� ������ ������ �Ҵ�Ǿ� ���α׷��� ����ɶ� ��ȯ�˴ϴ�.
// ���� �Ҵ��Ͽ� ������ ����� �� �ִ�.
// static ������ �뵵�� �°� �� �� �ִ�.
// ������ �� ��ȯ�� ���� �� �� �ִ�.
// ��ĳ����, �ٿ�ĳ������ �Ͽ� ����� �� �ִ�. (��ĳ���� �ٿ�ĳ������ ������ �ּ����� ����)
// ���� : ��ĳ�����̶� �ڽ� Ŭ������ ��ü�� �θ� Ŭ���� Ÿ������ ����ȯ �Ǵ� ���� ���մϴ�.
// �ٿ�ĳ�����̶� �ݴ�� �θ� Ŭ������ �ڽ� Ŭ������ Ÿ������ ����ȯ �Ǵ� ���� ���մϴ�.

class Counter
{
public:
    // ������
    Counter() 
    {
        count++;  // ��ü�� ������ ������ count ����
    }

    // �Ҹ���
    ~Counter() 
    {
        count--;  // ��ü�� �Ҹ�� ������ count ����
    }

    // static ��� �Լ�
    static int GetCount()
    {
        return count;  // ������ ��ü�� �� ��ȯ
    }
    

private:
    static int count;  // ��ü�� ���� �����ϴ� static ����
};

class Shape
{
public:
    virtual void Draw()
    {
        cout << "������ �׸��ϴ�." << endl;
    }
};

// �Ļ� Ŭ����
class Circle : public Shape
{
public:
    void Draw() override 
    {
        cout << "���� �׸��ϴ�." <<endl;
    }

    void Circumference()
    {
        cout << "���� �ѷ��� ���մϴ�." << endl;
    }
};

// static ���� �ʱ�ȭ
int Counter::count = 0;

int globalcount = 0;

void GetLocalCount()
{
    int localcount = 0;
    localcount++;
}

void GetGlobalCount()
{
    globalcount++;
}

int main() 
{
    Counter c1; 
    Counter c2;  
    Counter c3;  

    cout << "������ ��ü�� ��: " << Counter::GetCount() <<endl;
    GetLocalCount();
    GetGlobalCount();

    cout << globalcount;

    // ��ĳ����: �Ļ� Ŭ���� ��ü�� �⺻ Ŭ���� �����ͷ� ����Ű��
    Circle circle;
    Shape* shapePtr = &circle;

    // �ٿ�ĳ����: �⺻ Ŭ���� �����͸� �Ļ� Ŭ���� �����ͷ� ��ȯ
    Circle* circlePtr = dynamic_cast<Circle*>(shapePtr);

    // �ٿ�ĳ������ ��ü�� ����Ͽ� �Ļ� Ŭ������ Ưȭ�� �Լ� ȣ��
    if (circlePtr) 
    {
        circlePtr->Circumference();
    }
    else 
    {
        cout << "�ٿ�ĳ���� ����" << endl;
    }

    return 0;
}
