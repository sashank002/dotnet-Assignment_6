using System;
class Program
{
    static void Main()
    {
        //1st
        Console.WriteLine("\nFirst Example : \n");
        bool eg1 = new Func<int, bool>(delegate (int int32) { return int32 > 0; })(-56);
        new Action<bool>(delegate (bool value) { Console.WriteLine("   Output -> " + value + "\n"); })(eg1);

        //2nd
        Console.WriteLine("Second Example : \n");
        bool eg2 = new Func<int, bool>(int32 => int32 > 0)(56);
        new Action<bool>(delegate (bool value) { Console.WriteLine("   Output -> " + value + "\n"); })(eg2);

        //3rd
        Console.WriteLine("Third Example : \n");
        var parse = (double x, double y) => (x > y ? x : y);
        double eg3 = parse(1.2, 8.5);
        new Action<double>(delegate (double value) { Console.WriteLine("   Output -> " + value + "\n"); })(eg3);

        //4th
        Console.WriteLine("Fourth Example : \n");
        Func<double, double, double> f = (x, y) =>
        {
            if (x > y)
                return x;
            return y;
        };
        double eg4 = f(10, 20);
        new Action<double>(delegate (double value) { Console.WriteLine("   Output -> " + value + "\n"); })(eg4);

        //5th
        Console.WriteLine("Fifth Example : \n");
        double eg5;
        Func<double, double, double> f1;

        f1 = (x, y) =>
        {
            if (x > y)
                return x;
            return y;
        };

        eg5 = f1(10, 20);
        // z holds 20.
        new Action<double>(delegate (double value) { Console.WriteLine("   Output(1) -> " + value + "\n"); })(eg5);

        f1 = (x, y) =>
        {
            if (x < y)
                return x;
            return y;
        };

        eg5 = f1(10, 20);
        new Action<double>(delegate (double value) { Console.WriteLine("   Output(2) -> " + value + "\n"); })(eg5);

    }
}
