using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    public void InsertHead(int value)
    {
        Node newNode = new(value);

        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }

    // adiciona no final da lista
    public void InsertTail(int value)
    {
        Node newNode = new(value);

        // se estiver vazio, head e tail apontam pro mesmo nó
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            // conecta o novo nó no final
            newNode.Prev = _tail;
            _tail.Next = newNode;

            // atualiza o tail
            _tail = newNode;
        }
    }

    public void RemoveHead()
    {
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else if (_head is not null)
        {
            _head.Next!.Prev = null;
            _head = _head.Next;
        }
    }

    // remove o último elemento
    public void RemoveTail()
    {
        // lista vazia ou só um elemento
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else if (_tail is not null)
        {
            // desconecta o último
            _tail.Prev!.Next = null;

            // anda o tail pra trás
            _tail = _tail.Prev;
        }
    }

    public void InsertAfter(int value, int newValue)
    {
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == value)
            {
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                else
                {
                    Node newNode = new(newValue);

                    newNode.Prev = curr;
                    newNode.Next = curr.Next;

                    curr.Next!.Prev = newNode;
                    curr.Next = newNode;
                }

                return;
            }

            curr = curr.Next;
        }
    }

    // remove só a primeira ocorrência
    public void Remove(int value)
    {
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // se for o primeiro
                if (curr == _head)
                {
                    RemoveHead();
                }
                // se for o último
                else if (curr == _tail)
                {
                    RemoveTail();
                }
                else
                {
                    // reconecta pulando o nó atual
                    curr.Prev!.Next = curr.Next;
                    curr.Next!.Prev = curr.Prev;
                }

                // importante: para na primeira remoção
                return;
            }

            curr = curr.Next;
        }
    }

    // substitui TODOS os valores iguais
    public void Replace(int oldValue, int newValue)
    {
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == oldValue)
            {
                curr.Data = newValue;
            }

            curr = curr.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head;

        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Next;
        }
    }

    // percorre de trás pra frente
    public IEnumerable Reverse()
    {
        var curr = _tail;

        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Prev;
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}