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
        cout << value << "�Ҹ��" << endl;
    }
};

// Queue
// ���Լ����� �ڷᱸ��(�����̳�) - FIFO

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
        // 1���մ��ּ� 0x04
        // 2���մ��ּ� 0x08
        
        Node* temp = start;
        result = start->value;

        // start�� ���� 1���մ��� �ּ� 0x04�� ������
        // start->next �� 2���մ��� �ּ� 0x08
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