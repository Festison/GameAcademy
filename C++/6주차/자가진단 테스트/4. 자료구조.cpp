#include <iostream>
using namespace std;

// ���ø�, �ڷᱸ��, ����ó�� ���
// �Լ��� ���ø�ȭ �� �� �ִ�. (���ø��� �������� �ּ����� ����) 
// ���ø��̶� �Լ��� Ŭ������ ���������� �ٽ� �ۼ����� �ʾƵ�, ���� �ڷ� ������ ����� �� �ֵ��� �ϰ� ����� ���� Ʋ�Դϴ�.
// ����ü�� Ŭ������ ���ø�ȭ�ϰ� ����� �� �ִ�.
// if������ ����Ͽ� �⺻���� ����ó���� �� �� �ִ�.
// try throw catch���� ����Ͽ� ���� ����ó���� ������ �� �ִ�.
// ��� ����ü�� ���� ���� �� �ִ�.
// ��带 �ܹ����� �ƴ� ��������� ���� �� �ִ�
// ��� ����ü�� ����Ͽ� ��带 ������ ť�� ���� �� �ִ�.
// ��� ����ü�� ����Ͽ� ��带 ������ ������ ���� �� �ִ�.
// ��� ����ü�� ����Ͽ� ��带 ������ ��ũ�帮��Ʈ�� ���� �� �ִ�.

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

class Queue
{
private:
	Node<int>* start = nullptr;
	Node<int>* end = nullptr;
	int size = 0;
	int Pop()
	{
		int result = -1;
		if (IsEmpty())
			throw 0;

		Node<int>* temp = start;
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
	//�ڿ� �ִ°�
	void Push(int _value)
	{
		Node<int>* newNode = new Node<int>(_value);
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
			cout << "������ֽ��ϴ�." << endl;
			return false;
		}
		return true;
	}


	const int& GetSize() const
	{
		return size;
	}
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
		cout << newNode->value << endl;
	}

	void Insert(T index, const T& value)
	{
		Node<int>* newNode = new Node<T>(value);
		Node<int>* current = start;

		if (index > size)
		{
			cout << "�ε����� ������� Ů�ϴ�." << endl;
		}

		// ����Ʈ�� ù �κп� ����
		if (index == 0)
		{
			newNode->next = start;

			if (start != nullptr)
			{
				start->prev = newNode;
			}

			start = newNode;

			// ����Ʈ�� ����ִ� ���
			if (end == nullptr)
			{
				end = newNode;
			}
		}

		// ����Ʈ�� �� �κп� ����
		else if (index == size)
		{
			end->next = newNode;
			newNode->prev = end;
			end = newNode;
		}
		// �߰��� ����
		else
		{
			for (size_t i = 0; i < index; i++)
			{
				current = current->next;
			}

			newNode->prev = current->prev;
			newNode->next = current;
			current->prev->next = newNode;
			current->prev = newNode;
		}

		size++;
	}

	void Delete(T index)
	{
		if (index < 0 || index >= size)
		{
			cout << "�ε����� ����Ʈ�� ũ�⺸�� ũ�ų� �۾� ����Ʈ�� ������ �� �����ϴ�." << endl;
		}
		else
		{
			Node<T>* current = start;
			for (int i = 0; i < index; i++)
			{
				current = current->next;
			}
			current->prev->next = current->next;
			current->next->prev = current->prev;
			delete current;
		}
		size--;
	}

	T At(T index)
	{
		if (index < 0 || index > size)
		{
			cout << "�ε����� ����Ʈ�� ũ�⺸�� ũ�ų� �۾� ����Ʈ�� ���� ������ �� �����ϴ�." << endl;
		}

		Node<T>* current = start;

		for (int i = 0; i < index; i++)
		{
			current = current->next;
		}

		return current->value;
	}

	bool Search(T value)
	{
		Node<T>* current = start;

		while (current != nullptr)
		{
			if (current->value == value)
			{
				return true;
			}
			current = current->next;
		}
		return false;
	}

private:
	Node<int>* start = nullptr;
	Node<int>* end = nullptr;
	T size = 0;
};

int main()
{
	Stack<int> stack;
	Queue queue;
	LinkedList<int> lList;

	lList.Push(10);
	lList.Push(20);
	lList.Push(30);

	lList.Insert(0, 50);
	lList.Delete(2);

	cout << lList.At(2) << endl;

	if (lList.Search(50))
	{
		cout << "50�� �ִ�" << endl;
	}

}