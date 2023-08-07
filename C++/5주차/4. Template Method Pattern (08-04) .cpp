#include <iostream>
using namespace std;

// 템플릿 메서드 패턴 //
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

    virtual void PrintImage() = 0;      // 그림에서의 primitive1()
    virtual void PostProcessDie() = 0;   // 그림에서의 primitive2()

    int GetHp()
    {
        return hp;
    }
    void Die()   // 그림에서의 templateMethod
    {
        PrintImage();
        cout << "-----------------------" << endl;
        cout << name << "이 죽었습니다" << endl;
        cout << "-----------------------" << endl;
        PostProcessDie();
    }
};

class Player : public Character
{
    int state = 0;
public:
    // primitive 부분을 재정의함
    void PrintImage() override
    {
        cout << "-----------------------" << endl;
        cout << "--------대충-----------" << endl;
        switch (state)
        {
        case 0: // 평범한 상태
            cout << "-------주인공-그림------" << endl;
            break;
        case 1: // 분노 상태
            cout << "-------화난-그림------" << endl;
            break;
        case 2: // 지친 상태
            cout << "-------지친-그림------" << endl;
            break;
        }
        cout << "-----------------------" << endl;
    }
    void PostProcessDie() override
    {
        cout << "경험치 감소" << endl;
        cout << "hp를 1로 변경" << endl;
        cout << "마을씬으로 돌아감" << endl;
    }
};

class Monster : public Character
{
public:

    void PrintImage() override
    {
        cout << "-----------------------" << endl;
        cout << "--------대충-----------" << endl;
        cout << "-------몬스터-그림------" << endl;
        cout << "-----------------------" << endl;
    }
    void PostProcessDie() override
    {
        cout << "아이템 드랍" << endl;
    }
};

int main()
{
    Character* chPtr = new Player();

}
