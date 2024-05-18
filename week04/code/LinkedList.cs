using System.Collections;
using System.Globalization;

public class LinkedList : IEnumerable<int> {
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value) {
        // Create new node
        Node newNode = new Node(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null) {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value) {
        // TODO Problem 1
        //create new node
        Node newNode = new Node(value);
        //if list is empty, new node is both head and tail.
        if (_head is null) {
            _head = newNode;
            _tail = newNode;
        } 
        //add to end of list if not null.
        else {
            newNode.Prev = _tail; // set the new node's prev to the tail
            _tail.Next = newNode; // set the tail's next to the new node
            _tail = newNode; // set the new node as the tail.
        }
        
    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead() {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail) {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null) {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail() {
        // TODO Problem 2
        //if list is empty, keep it empty; ok baby
        if (_head == _tail){
            _head = null;
            _tail = null;
        }
        //otherwise get rid of the tail.
        else if(_tail is not null){
            _tail.Prev!.Next = null; // disconnect the last node from the second to last node.
            _tail = _tail.Prev; // update the tail to the second to last node.
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue) {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null) {
            if (curr.Data == value) {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail) {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value) {
        // TODO Problem 3
        Node? curr = _head; // start at the beginning of the linked list
        while (curr is not null){
            if (curr.Data == value){
                if (curr == _head){ //if the first value to remove is at the head, call the remove head function
                    RemoveHead();
                } 
                else if (curr == _tail){ // if first value is at the tail, call the remove tail function
                    RemoveTail();
                } else {
                    curr.Next.Prev = curr.Prev; //otherwise, set the node behind current node's prev to the node in front of current
                    curr.Prev.Next = curr.Next; // set the node in front of current's next to the node behind current.
                }

                return;
            }
            
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue) {
        // TODO Problem 4
        // set curr equal to the head/beginning of the list
        Node? curr = _head;
        while (curr is not null){
            if(curr.Data == oldValue){ //if the currents data is equal to the old value,
                curr.Data = newValue; // change the data to the new value
            }

            curr = curr.Next; //move to the next node in the linked list
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator() {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator() {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null) {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse() {
        // TODO Problem 5
        //set current value as the tail of the list
        var curr = _tail;
        while (curr is not null){
            yield return curr.Data;  // return the current value's data
            curr = curr.Prev; //go backwards in the linked list
        }
        
    }

    public override string ToString() {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull() {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull() {
        return _head is not null && _tail is not null;
    }
}