#include <iostream>
#include <queue>
using namespace std;

struct Node
{
    Node* next = nullptr;
    Node* prev = nullptr;
    int value;

    Node(int value)
    {
        this->value = value;
    }
    ~Node()
    {
        cout << value << "소멸됨" << endl;
    }
};

// Queue
// 선입선출의 자료구조(컨테이너) - FIFO

class Queue
{
    Node* start = nullptr;
    Node* end = nullptr;
    int size = 0;

public:
    bool IsEmpty()
    {
        return (size <= 0);
    }
    void Push(int value)
    {
        Node* newNode = new Node(value);

        if (IsEmpty())
        {
            start = newNode;
            end = newNode;
        }
        else
        {
            end->next = newNode;  
            newNode->prev = end;
            end = newNode;            
        }
        size++;
    }

    int Pop()
    {
        int result = -1;
        // 1번손님주소 0x04
        // 2번손님주소 0x08
        
        Node* temp = start;
        result = start->value;

        // start는 현재 1번손님의 주소 0x04가 들어가있음
        // start->next 는 2번손님의 주소 0x08
        start = start->next;
        delete temp;
        size--;
        return result;
    }

    ~Queue()
    {
        Node* temp = start;
        while (start != nullptr)
        {
            start = start->next;
            delete temp;
            temp = start;
        }
    }
};

int main()
{
    Queue queue;
    queue.Push(10); //new
    queue.Push(20); //new
    queue.Push(40); //new  

    

}