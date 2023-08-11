#include <iostream>
using namespace std;

template <typename T>
class Node
{
public:
	Node(T value)
	{
		this->value = value;
	}

public:
	Node* next = nullptr;
	Node* prev = nullptr;
	T value;

};

template <typename T>
class Queue
{
public:
	bool Empty()
	{
		return (size <= 0);
	}

	void Push(T value)
	{
		Node<int>* newNode = new Node<T>(value);

		if (Empty())
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

	bool Pop()
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

	const T& GetSize() const
	{
		return size;
	}


private:
	Node<int>* start = nullptr;
	Node<int>* end = nullptr;
	T size = 0;
	T Pop()
	{
		int result = -1;

		if (Empty())
		{
			throw 0;
		}

		Node<int>* temp = start;
		result = start->value;
		start = start->next;

		delete temp;
		size--;
		return result;
	}

};

template <typename T>
class Stack
{
public:
	bool Empty()
	{
		return (size <= 0);
	}

	void Push(T value)
	{
		Node<int>* newNode = new Node<T>(value);

		if (Empty())
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

	T Pop()
	{
		T result = -1;

		Node<int>* temp = end;
		result = end->value;
		end = end->prev;

		delete temp;
		size--;
		return result;
	}

	const T& GetSize() const
	{
		return size;
	}

private:
	Node<int>* start = nullptr;
	Node<int>* end = nullptr;
	T size = 0;
};

template <typename T>
class LinkedList
{
public:
	bool Empty()
	{
		return (size <= 0);
	}

	void Push(T value)
	{
		Node<int>* newNode = new Node<T>(value);

		if (Empty())
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

	void Insert(T index, T value)
	{
		Node<int>* newNode = new Node<T>(value);
		Node<int>* current = new Node<T>(value);

		for (int i = 0; i < index; i++)
		{
			current = current->next;
		}

		current->value = value;

		size++;
	}

	void Delete(T index)
	{

	}

	T At(T index)
	{

	}

	bool Search(T value)
	{

	}

	const T& GetSize() const
	{
		return size;
	}

private:
	Node<int>* start = nullptr;
	Node<int>* end = nullptr;
	T size = 0;
};



int main()
{
	Queue<int> queue;
	Stack<int> stack;
	LinkedList<int> lList;


}
