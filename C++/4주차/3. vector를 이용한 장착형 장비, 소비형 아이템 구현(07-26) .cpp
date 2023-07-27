#include <iostream>
#include <string>
#include <vector>
using namespace std;

//STL
//vector : 동적가변배열

struct Item
{
    string name;
    int price;

    Item()
    {

    }
    Item(string _name, int _price)
    {
        name = _name;
        price = _price;
    }

    void PrintInfo()
    {
        cout << "이름 : " << name << endl;
        cout << "가격 : " << price << endl;
    }
    virtual void Use()
    {
        cout << "대충" << endl;

    }
};

struct ConsumptableItem : Item
{
    ConsumptableItem(string _name, int _price)
    {
        name = _name;
        price = _price;
    }
    void Use()
    {
        cout << name << "을 사용한다" << endl;
    }
};

struct EquipmentableItem : Item
{
    EquipmentableItem(string _name, int _price)
    {
        name = _name;
        price = _price;
    }
    void Use()
    {
        cout << name << "을 장비한다" << endl;
    }
};

struct Inventory
{
    vector<Item*> inven;

    void PrintInventory()
    {
        cout << "--인벤토리 정보 출력--" << endl;
        for (int i = 0; i < inven.size(); i++)
        {
            cout << i << "번째 아이템 정보" << endl;
            inven.at(i)->PrintInfo();
        }
        cout << "--------------------" << endl;
    }
    void Use(int index)
    {
        inven[index]->Use();
    }
    void AddItem(Item* item)
    {
        Item* newItem = new Item();
        (ConsumptableItem*)item;
        cout << item->name << "을 인벤토리에 추가합니다" << endl;
        inven.push_back(item);
    }
    void DeleteItem(int index)
    {
        cout << "인벤토리에서" << index << "번째 아이템을 삭제합니다" << endl;
        inven.erase(inven.begin() + index);
    }
};

struct Player
{
public:
    vector<Inventory*> inventory;
    int hp;
    int mp;
    int atk;

public:
    void PrintItem()
    {

    }

};

void main()
{
    Inventory inven;

    Item* itemPtr = nullptr;
    int input = 0;

    while (input != -1)
    {
        cout << "아이템 구매 1은 검, 2는 빨강포션 ,   -1 그만사기" << endl;
        cin >> input;

        switch (input)
        {
        case 1:
            itemPtr = new EquipmentableItem("검", 100);
            break;
        case 2:
            itemPtr = new ConsumptableItem("빨강포션", 10);
            break;
        }

        if (itemPtr != nullptr)
            inven.AddItem(itemPtr);
    }

    inven.PrintInventory();


    while (true)
    {
        cout << "사용할 아이템 번호를 선택하세요" << endl;
        cin >> input;
        inven.Use(input);
        inven.PrintInventory();
    }
}

