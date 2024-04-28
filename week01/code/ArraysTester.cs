using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Xml;

public static class ArraysTester {
    /// <summary>
    /// Entry point for the tests
    /// </summary>
    public static void Run() {
        // Sample Test Cases (may not be comprehensive)
        Console.WriteLine("\n=========== PROBLEM 1 TESTS ===========");
        double[] multiples = MultiplesOf(7, 5);
        Console.WriteLine($"<double>{{{string.Join(',', multiples)}}}"); // <double>{7, 14, 21, 28, 35}
        multiples = MultiplesOf(1.5, 10);
        Console.WriteLine($"<double>{{{string.Join(',', multiples)}}}"); // <double>{1.5, 3.0, 4.5, 6.0, 7.5, 9.0, 10.5, 12.0, 13.5, 15.0}
        multiples = MultiplesOf(-2, 10);
        Console.WriteLine($"<double>{{{string.Join(',', multiples)}}}"); // <double>{-2, -4, -6, -8, -10, -12, -14, -16, -18, -20}

        Console.WriteLine("\n=========== PROBLEM 2 TESTS ===========");
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(numbers, 1);
        Console.WriteLine($"<List>{{{string.Join(',', numbers)}}}"); // <List>{9, 1, 2, 3, 4, 5, 6, 7, 8}
        numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(numbers, 5);
        Console.WriteLine($"<List>{{{string.Join(',', numbers)}}}"); // <List>{5, 6, 7, 8, 9, 1, 2, 3, 4}
        numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(numbers, 3);
        Console.WriteLine($"<List>{{{string.Join(',', numbers)}}}"); // <List>{7, 8, 9, 1, 2, 3, 4, 5, 6}
        numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(numbers, 9);
        Console.WriteLine($"<List>{{{string.Join(',', numbers)}}}"); // <List>{1, 2, 3, 4, 5, 6, 7, 8, 9}
        //testing for a greater shift amount than list length.
        RotateListRight(numbers, 10);
        Console.WriteLine($"<List>{{{string.Join(',', numbers)}}}"); // <List>{9, 1, 2, 3, 4, 5, 6, 7, 8}
    }

    /// <summary>
    /// This function will produce a list of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    private static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //need a result list variable that will hold all the multiples
        List<double> results = new List<double>();
        //need a var to keep track of what number we're at to add number to
        var totnumber = number;

        //need a for loop that will iterate through number length amount of times
        //adding the number to itself and into the result array and stopping once it reaches length

        for(int i = 1; i <= length; i++){
            results.Add(totnumber);
            totnumber += number;

        }

        return results.ToArray(); // replace this return statement with your own
    }
    
    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// <c>&lt;List&gt;{1, 2, 3, 4, 5, 6, 7, 8, 9}</c> and an amount is 3 then the list returned should be 
    /// <c>&lt;List&gt;{7, 8, 9, 1, 2, 3, 4, 5, 6}</c>.  The value of amount will be in the range of <c>1</c> and 
    /// <c>data.Count</c>.
    /// <br /><br />
    /// Because a list is dynamic, this function will modify the existing <c>data</c> list rather than returning a new list.
    /// </summary>
    private static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // checks if the amount of shifting to the right is greater than the amount of numbers in the list, and adjusts.
        if(amount > data.Count){
            amount = amount % data.Count;
        }
        //need a new result list variable to add the new data to
        List<int> oldData = new List<int>(data);
        List<int> newResult = new List<int>();
        int count = data.Count;
        int idex = count - amount;
        //Console.WriteLine(count);
        //Console.WriteLine(idex);

        //going to use GetRange from count - amount to count, add it to the new result list, then remove that same range from the data list, then add the remaining data list into the new result list.

        //this is the list of numbers in the range that it needs to move over to the right
        List<int> theRange = new List<int>(data.GetRange(idex, amount));

        //puts the numbers from theRange into a new result set
        foreach(int number in theRange){
            newResult.Add(number);
        }

        //removes theRange numbers from a copy of the list leaving only the numbers we still need inside
        oldData.RemoveRange(idex, amount);

        //adds the remaining needed numbers from the list to our result list
        foreach(int number in oldData){
            newResult.Add(number);
        }

        //clears the original list of numbers
        data.RemoveRange(0, count);
        // adds the number back into the original list in proper oder based on how far they should have moved over.
        data.AddRange(newResult);



        //took several tries to figure out how to edit the actual data variable, couldn't just say data = newResult;... This is definitely not the most efficient way to do it... but it works.
        

    }
}
