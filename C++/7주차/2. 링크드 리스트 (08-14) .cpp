#include <iostream>

using namespace std;


template <typename T>
struct Node
{
    Node<T>* next = nullptr;
    Node<T>* prev = nullptr;
    T value;

    Node(T _value)
    {
        value = _value;
    }
};


template <typename T>
class LinkedList
{
protected:
    Node<T>* start = nullptr;
    Node<T>* end = nullptr;
    int size = 0;

    Node<T>* AtNode(const int& index)
    {
        Node<int>* currentPtr = start;
        for (int i = 0; i < index; i++)
        {
            currentPtr = currentPtr->next;
        }
        return currentPtr;
    }
public:
    const int& GetSize() const
    {
        return size;
    }

    T At(int index)
    {
        return AtNode(index)->value;
    }
    void Insert(const int& index, T value)
    {
        Node<T>* newNodePtr = new Node<T>(value);
        Node<T>* nextPtr = AtNode(index);
        Node<T>* prevPtr = nextPtr->prev;

        prevPtr->next = newNodePtr;
        newNodePtr->prev = prevPtr;

        newNodePtr->next = nextPtr;
        nextPtr->prev = newNodePtr;
        size++;
    }
    void Delete(int index)
    {
        Node<T>* currentPtr = AtNode(index);
        Node<T>* nextPtr = currentPtr->next;
        Node<T>* prevPtr = currentPtr->prev;

        prevPtr->next = nextPtr;
        nextPtr->prev = prevPtr;


        delete currentPtr;
    }
    void Push(T value)
    {
        Node<T>* newNodePtr = new Node<T>(value);

        if (size == 0)
        {
            start = newNodePtr;
            end = newNodePtr;
        }
        else
        {
            end->next = newNodePtr;
            newNodePtr->prev = end;
            end = newNodePtr;
        }
        size++;
    }
    virtual T Pop()
    {
        T result = start->value;
        Node<T>* deletePtr = start;
        start = start->next;
        delete deletePtr;
        size--;
        return result;
    }
    virtual ~LinkedList()
    {
        if (size == 0)
            return;

        Node<T>* current = start;
        Node<T>* deletePtr = start;
        while (current != nullptr)
        {
            current = current->next;
            delete deletePtr;
            deletePtr = current;
        }
    }

};

template <typename T>
class Stack : protected LinkedList<T>
{
public:
    const int& GetSize()
    {
        return LinkedList<T>::GetSize();
    }
    void Push(T value)
    {
        LinkedList<T>::Push(value);
    }
    T Pop()
    {
        T result = LinkedList<T>::end->value;
        Node<T>* deletePtr = LinkedList<T>::end;
        LinkedList<T>::end = LinkedList<T>::end->prev;
        delete deletePtr;
        LinkedList<T>::size--;
        return result;
    }
    ~Stack()
    {

    }
};

template <typename T>
class Queue : protected LinkedList<T>
{
public:
    const int& GetSize()
    {
        return LinkedList<T>::GetSize();
    }
    void Push(T value)
    {
        LinkedList<T>::Push(value);
    }
    T Pop()
    {
        return LinkedList<T>::Pop();
    }
    ~Queue()
    {

    }
};



int main()
{

    Queue<int> queue;
    queue.Push(10);
    queue.Push(20);
    queue.Push(30);

    cout << queue.Pop() << endl;
    cout << queue.Pop() << endl;
    cout << queue.Pop() << endl;

    Stack<int> stack;
    stack.Push(10);
    stack.Push(20);
    stack.Push(30);

    cout << stack.Pop() << endl;
    cout << stack.Pop() << endl;
    cout << stack.Pop() << endl;

}