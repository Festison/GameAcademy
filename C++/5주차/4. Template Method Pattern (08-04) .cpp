#include <iostream>
using namespace std;

// ���ø� �޼��� ���� //
class Character
{
protected:
    int hp = 100;
    int atk;
    string name;
public:
    void SetHp(int value)
    {
        hp = value;
        if (hp <= 0)
        {
            Die();
        }
    }

    virtual void PrintImage() = 0;      // �׸������� primitive1()
    virtual void PostProcessDie() = 0;   // �׸������� primitive2()

    int GetHp()
    {
        return hp;
    }
    void Die()   // �׸������� templateMethod
    {
        PrintImage();
        cout << "-----------------------" << endl;
        cout << name << "�� �׾����ϴ�" << endl;
        cout << "-----------------------" << endl;
        PostProcessDie();
    }
};

class Player : public Character
{
    int state = 0;
public:
    // primitive �κ��� ��������
    void PrintImage() override
    {
        cout << "-----------------------" << endl;
        cout << "--------����-----------" << endl;
        switch (state)
        {
        case 0: // ����� ����
            cout << "-------���ΰ�-�׸�------" << endl;
            break;
        case 1: // �г� ����
            cout << "-------ȭ��-�׸�------" << endl;
            break;
        case 2: // ��ģ ����
            cout << "-------��ģ-�׸�------" << endl;
            break;
        }
        cout << "-----------------------" << endl;
    }
    void PostProcessDie() override
    {
        cout << "����ġ ����" << endl;
        cout << "hp�� 1�� ����" << endl;
        cout << "���������� ���ư�" << endl;
    }
};

class Monster : public Character
{
public:

    void PrintImage() override
    {
        cout << "-----------------------" << endl;
        cout << "--------����-----------" << endl;
        cout << "-------����-�׸�------" << endl;
        cout << "-----------------------" << endl;
    }
    void PostProcessDie() override
    {
        cout << "������ ���" << endl;
    }
};

int main()
{
    Character* chPtr = new Player();

}
