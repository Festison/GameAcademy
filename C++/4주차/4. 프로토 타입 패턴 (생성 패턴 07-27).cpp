#include<iostream>
#include <string>
#include <vector>
using namespace std;


// [ 얕은 복사 Shallow Copy ]
// 멤버 데이터를 비트열 단위로 똑같이 복사 (메모리 영역 값을 그대로 복사)
// 포인터는 주소값 바구니 -> 주소값을 똑같이 복사 -> 동일한 객체를 가리키는 상태가 된다.
// Stack : Knight1 [ hp 0x1000 ] -> Heap 0x1000 Pet[   ]
// Stack : Knight2 [ hp 0x1000 ] -> Heap 0x1000 Pet[   ]
// Stack : Knight3 [ hp 0x1000 ] -> Heap 0x1000 Pet[   ]

// [ 깊은 복사 Deep Copy ]
// 멤버 데이터가 참조(주소) 값이라면, 데이터를 새로 만들어준다 (원본 객체가 참조하는 대상까지 새로 만들어서 복사)
// 포인터는 주소값 바구니 -> 새로운 객체를 생성 -> 서로 다른 객체를 가리키는 상태가 된다.
// Stack : Knight1 [ hp 0x1000 ] -> Heap 0x1000 Pet[   ]
// Stack : Knight2 [ hp 0x2000 ] -> Heap 0x2000 Pet[   ]
// Stack : Knight3 [ hp 0x3000 ] -> Heap 0x3000 Pet[   ]

struct Item
{
    int valueA;

    virtual void Use()
    {
        cout << "아이템 사용" << endl;
    }
    virtual Item* Clone()
    {
        return new Item(*this);
    }
};

struct ConsumableItem : Item
{
    int valueB;

    void Use() override
    {
        cout << "아이템 사용(소모)" << endl;
    }

    Item* Clone() override
    {
        return new ConsumableItem(*this);
    }
};

vector<Item*> inven;

// 상점에 영향이 안가게 복사 생성자를 사용
// 같은 아이템에 영향이 안가게 깊은 복사를 사용
void main()
{
    Item sword;
    sword.valueA = 1;
    ConsumableItem potion;
    potion.valueA = 2;
    potion.valueB = 2;

    inven.push_back(sword.Clone());
    inven.push_back(potion.Clone());
    inven.push_back(potion.Clone());

    inven[0]->Use();
    inven[1]->Use();
    inven[2]->Use();

}
