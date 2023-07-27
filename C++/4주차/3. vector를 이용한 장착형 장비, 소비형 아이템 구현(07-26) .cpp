#include <iostream>
#include <string>
#include <vector>
using namespace std;

//STL
//vector : ���������迭

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
        cout << "�̸� : " << name << endl;
        cout << "���� : " << price << endl;
    }
    virtual void Use()
    {
        cout << "����" << endl;

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
        cout << name << "�� ����Ѵ�" << endl;
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
        cout << name << "�� ����Ѵ�" << endl;
    }
};

struct Inventory
{
    vector<Item*> inven;

    void PrintInventory()
    {
        cout << "--�κ��丮 ���� ���--" << endl;
        for (int i = 0; i < inven.size(); i++)
        {
            cout << i << "��° ������ ����" << endl;
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
        cout << item->name << "�� �κ��丮�� �߰��մϴ�" << endl;
        inven.push_back(item);
    }
    void DeleteItem(int index)
    {
        cout << "�κ��丮����" << index << "��° �������� �����մϴ�" << endl;
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
        cout << "������ ���� 1�� ��, 2�� �������� ,   -1 �׸����" << endl;
        cin >> input;

        switch (input)
        {
        case 1:
            itemPtr = new EquipmentableItem("��", 100);
            break;
        case 2:
            itemPtr = new ConsumptableItem("��������", 10);
            break;
        }

        if (itemPtr != nullptr)
            inven.AddItem(itemPtr);
    }

    inven.PrintInventory();


    while (true)
    {
        cout << "����� ������ ��ȣ�� �����ϼ���" << endl;
        cin >> input;
        inven.Use(input);
        inven.PrintInventory();
    }
}

