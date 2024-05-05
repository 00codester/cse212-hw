public static class Priority {
    public static void Test() {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        var priorityQueue = new PriorityQueue();
        Console.WriteLine(priorityQueue);

        // Test Cases

        // Test 1
        // Scenario: Adding values to the queue
        // Expected Result: Jim (Pri:10), Sue (Pri:20), Bill (Pri:5)
        Console.WriteLine("Test 1");
        priorityQueue.Enqueue("Jim", 10);
        priorityQueue.Enqueue("Sue", 20);
        priorityQueue.Enqueue("Bill", 5);
        Console.WriteLine(priorityQueue);
        // Defect(s) Found: None

        Console.WriteLine("---------");

        // Test 2
        // Scenario: Removing from queue
        // Expected Result: Sue Jim Bill
        Console.WriteLine("Test 2");
        Console.WriteLine(priorityQueue.Dequeue());
        Console.WriteLine(priorityQueue.Dequeue());
        Console.WriteLine(priorityQueue.Dequeue());
        Console.WriteLine(priorityQueue);
        // Defect(s) Found: Result Sue Sue Sue, it's not removing the value, just getting the 
        // highest priority

        Console.WriteLine("---------");

        // Test 3
        // Scenario: Empty List Dequeue
        // Expected Result: The queue is empty.
        Console.WriteLine("Test 3");
        Console.WriteLine(priorityQueue.Dequeue());
        // Defects Found: None

        Console.WriteLine("---------");

        // Test 4
        // Scenario: Same level priority test
        // Expected Result: Mark Jim Bill Sue Larry
        Console.WriteLine("Test 4");
        priorityQueue.Enqueue("Larry", 5);
        priorityQueue.Enqueue("Jim", 10);
        priorityQueue.Enqueue("Mark", 15);
        priorityQueue.Enqueue("Bill", 10);
        priorityQueue.Enqueue("Sue", 10);

        //Console.WriteLine(priorityQueue.)

        Console.WriteLine(priorityQueue.Dequeue());
        Console.WriteLine(priorityQueue.Dequeue());
        Console.WriteLine(priorityQueue.Dequeue());
        Console.WriteLine(priorityQueue.Dequeue());
        Console.WriteLine(priorityQueue.Dequeue());
        // Defects: Result: Mark Bill Jim Larry Sue, larry has lower priority than Sue but is queued
        // first, bill is being queue'd before jim. 

        // Add more Test Cases As Needed Below
    }
}