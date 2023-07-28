#include<iostream>
#include <string>
#include <vector>
using namespace std;


// [ ���� ���� Shallow Copy ]
// ��� �����͸� ��Ʈ�� ������ �Ȱ��� ���� (�޸� ���� ���� �״�� ����)
// �����ʹ� �ּҰ� �ٱ��� -> �ּҰ��� �Ȱ��� ���� -> ������ ��ü�� ����Ű�� ���°� �ȴ�.
// Stack : Knight1 [ hp 0x1000 ] -> Heap 0x1000 Pet[   ]
// Stack : Knight2 [ hp 0x1000 ] -> Heap 0x1000 Pet[   ]
// Stack : Knight3 [ hp 0x1000 ] -> Heap 0x1000 Pet[   ]

// [ ���� ���� Deep Copy ]
// ��� �����Ͱ� ����(�ּ�) ���̶��, �����͸� ���� ������ش� (���� ��ü�� �����ϴ� ������ ���� ���� ����)
// �����ʹ� �ּҰ� �ٱ��� -> ���ο� ��ü�� ���� -> ���� �ٸ� ��ü�� ����Ű�� ���°� �ȴ�.
// Stack : Knight1 [ hp 0x1000 ] -> Heap 0x1000 Pet[   ]
// Stack : Knight2 [ hp 0x2000 ] -> Heap 0x2000 Pet[   ]
// Stack : Knight3 [ hp 0x3000 ] -> Heap 0x3000 Pet[   ]

struct Item
{
    int valueA;

    virtual void Use()
    {
        cout << "������ ���" << endl;
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
        cout << "������ ���(�Ҹ�)" << endl;
    }

    Item* Clone() override
    {
        return new ConsumableItem(*this);
    }
};

vector<Item*> inven;

// ������ ������ �Ȱ��� ���� �����ڸ� ���
// ���� �����ۿ� ������ �Ȱ��� ���� ���縦 ���
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
