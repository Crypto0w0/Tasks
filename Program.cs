using System;
using System.Text.RegularExpressions;
using System.Threading;

class Programm
{
    static private Thread thr = new Thread(StopAnalyze);
    
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Text:");
            string text = Console.ReadLine();
            
            TextAnalyze(text);
            thr.Start();
            
            char ans = Convert.ToChar(Console.ReadLine());
            if (ans == 'a') continue;
            else
            {
                thr.Abort();
                break;
            }
        }
    }

    static void TextAnalyze(string text)
    {
        Task t = Task.Run(() =>
        {
            int sentences = 0;
            int words = 0;
            int asksent = 0;
            int exclsent = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '.' || text[i] == '?' || text[i] == '!') sentences++;
                else if (text[i] == ' ') words++;
                if (text[i] == '?') asksent++;
                else if (text[i] == '!') exclsent++;
            }
            Console.WriteLine("Analysing...");
            Task.Delay(5000);
            Console.WriteLine("Sentences: " + sentences);
            Console.WriteLine("Characters: " + text.Length);
            Console.WriteLine("Words: " + (words + 1));
            Console.WriteLine("Asking sentences: " + asksent);
            Console.WriteLine("Exclamatory sentences: " + exclsent);
        });
    }

    static void StopAnalyze()
    {
        char ans = Convert.ToChar(Console.ReadLine());
        if (ans == 's') Task.WaitAll();
    }
}