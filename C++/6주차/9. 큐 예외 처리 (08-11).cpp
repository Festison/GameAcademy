#include <iostream>

using namespace std;


//Queue
//줄서기 먼저들어온놈이 먼저 처리되는 것
//선입선출

struct Node
{
    Node* next = nullptr;
    int value;

    Node(int value)
    {
        this->value = value;
    }
};


class Queue
{
private:
    Node* start = nullptr;
    Node* end = nullptr;
    int size = 0;

    int Pop()
    {
        int result = -1;
        if (IsEmpty())
        {
            throw 0;
        }
            
        Node* temp = start;
        result = start->value;
        start = start->next;

        delete temp;
        size--;
        return result;
    }

public:
    bool IsEmpty()
    {
        return (bool)(size <= 0);
    }
    //뒤에 넣는거
    void Push(int _value)
    {
        Node* newNode = new Node(_value);
        if (IsEmpty())
        {
            start = newNode;
            end = newNode;
        }
        else
        {
            end->next = newNode;
            end = newNode;
        }
        size++;
    }

    bool Pop(int& input)
    {
        try
        {
            input = Pop();
        }
        catch (...)
        {
            cout << "비어져있습니다." << endl;
            return false;
        }
        return true;
    }


    const int& GetSize() const
    {
        return size;
    }
};


void main()
{
    Queue queue;
    queue.Push(10);
    queue.Push(20);
    queue.Push(30);

    int temp;
    for (int i = 0; i < 10; i++)
    {
        if (queue.Pop(temp))
        {
            cout << temp << endl;
        }        
    }

    cout << "DD" << endl;
}