// Decompiled with JetBrains decompiler
// Type: DZ7.Program
// Assembly: DZ7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E2E31C8-00FC-476B-AB01-AD455CA92C6A
// Assembly location: E:\Downloads\Обучение\C#\DZ_Repozitoriy\learn_C#_repozitory\DZ7\DZ7\DZ7\bin\Debug\DZ7.exe

using System;
using System.Diagnostics;
using System.Text;

namespace DZ7
{
  internal class Program
  {
    private static void Main(string[] args)
    {
            Console.WriteLine(Guid.NewGuid() + " = Guid and Length of 1 Guid = " + Guid.NewGuid().ToString().Length);
            
      string str = "";
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Restart();
      for (int index = 0; index < 10000; ++index)
        str += Guid.NewGuid().ToString();
      stopwatch.Stop();
            
            Console.WriteLine(str.Length + " = Length and  ElapsedMilliseconds = " + stopwatch.ElapsedMilliseconds);
            Console.WriteLine("stopwatch.ElapsedTicks: " + stopwatch.ElapsedTicks);
            Console.WriteLine("stopwatch.Elapsed: " + stopwatch.Elapsed);
            Console.WriteLine("stopwatch.IsRunning: " + stopwatch.IsRunning);

            long timeOne = stopwatch.ElapsedMilliseconds;

            StringBuilder stringBuilder = new StringBuilder();

            Console.WriteLine("stringBuilder.Capacity: " + stringBuilder.Capacity + " and max: "  + stringBuilder.MaxCapacity);

      stopwatch.Restart();
      for (int index = 0; index < 10000; ++index)
        stringBuilder.Append((object) Guid.NewGuid());
      stopwatch.Stop();
      Console.WriteLine(str.Length + " = Length and  ElapsedMilliseconds = " + stopwatch.ElapsedMilliseconds);
            
            long timeTwo = stopwatch.ElapsedMilliseconds;

            if(timeTwo != 0)
            Console.WriteLine(timeOne / timeTwo + " - во столько раз выйгрышней при 10000 циклов");
            
            
            Console.Read();
    }
  }
}
