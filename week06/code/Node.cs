using System.Security.Cryptography;

public class Node {
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data) {
        this.Data = data;
    }

    public void Insert(int value) {
        if( value == Data){
            return;
        }
        else if (value < Data) {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value) {
        // TODO Start Problem 2
        //Console.WriteLine(Data);
        //Console.WriteLine(value);
        if (value < Data && Left is not null){
            //Console.WriteLine("left");
            return Left.Contains(value);
        } 
        
        else if (value > Data && Right is not null){
            //Console.WriteLine("right");
            return Right.Contains(value);
        } 
        else if (value == Data){
            //Console.WriteLine("they equal");
            return true;
        } else {
            //Console.WriteLine("not equal");
            return false;
        }
        //return false;
    }

    public int GetHeight() {
        // TODO Start Problem 4
        int height = 1;
        int leftS = 0;
        int rightS = 0;
        if (Left is not null) {
            leftS = Left.GetHeight();
            //GetHeight();
        }
        if (Right is not null) {
            //rightS += 1;
            rightS = Right.GetHeight();
        } 

        if (rightS >= leftS){
            return height + rightS;
        } else {
            return height + leftS;
        }
        //return height + leftS;


        //return 0; // Replace this line with the correct return statement(s)

        
    }
}