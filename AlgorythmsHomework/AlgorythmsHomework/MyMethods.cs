using System;

public static class MyMethods
{
    public static double NumsCheck(string text)
    {
        var res = 0.0;
        try
        {
            if (Double.TryParse(text, out res) == false)
            {
                Console.WriteLine("Некорректное значение, повторите ввод пожалуйста.");
                var newdata = Console.ReadLine();
                res = Convert.ToDouble(NumsCheck(newdata));
            }
            else if (Double.TryParse(text, out res) == true && res < 0)
            {
                throw new ArgumentOutOfRangeException("Значение меньше 0 повторите ввод");
            }
            else
            {
                res = Convert.ToDouble(text);
            }
            return res;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.ParamName);
        }
        return res;
    }
    public static double NumsCheckNoRestr(string text)
    {
        var res = 0.0;
        try
        {
            if (Double.TryParse(text, out res) == false)
            {
                Console.WriteLine("Некорректное значение, повторите ввод пожалуйста.");
                var newdata = Console.ReadLine();
                res = Convert.ToDouble(NumsCheckNoRestr(newdata));
            }
            else
            {
                res = Convert.ToDouble(text);
            }
            return res;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.ParamName);
        }
        return res;
    }
    public static void SetTextPosition(string text, int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine(text);
        Console.ReadKey();
    }
}