using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace techrace
{
    public static class Calculator
    {
        public static string Calculate(string input)
        {
            var inputInts = input.Split(",").Select(int.Parse).ToArray();
            
            Trace.WriteLine("-");
            Trace.WriteLine($"{string.Join(",", inputInts)}");
            Trace.WriteLine("-");

            var helped = new HashSet<int>();
            while (true)
            {
                var targetIndex = -1;
                var targetValue = int.MaxValue;

                for (var i = 0; i < inputInts.Length; i++)
                {
                    if (helped.Contains(i))
                    {
                        continue; 
                    }

                    var v = inputInts[i];
                    if (targetValue > v)
                    {
                        targetValue = v;
                        targetIndex = i;
                    }
                    
                }

                if (targetIndex == -1)
                {
                    throw new Exception("Не найден минимальный элемент");
                }
  
                var sourceIndex = -1;
                var sourceValue = -1;
                
                for (var i = 0; i < inputInts.Length; i++)
                {
                    if (targetIndex == i)
                    {
                        continue;
                    }

                    var v = inputInts[i];
                    if (v < targetValue * 3)
                    {
                        continue;
                    }
                    
                    if (sourceValue < v)
                    {
                        sourceValue = v;
                        sourceIndex = i;
                    }
                }

                if (sourceIndex == -1)
                {
                    break;
                }

                inputInts[sourceIndex] = sourceValue - targetValue;
                inputInts[targetIndex] = targetValue * 2;
                helped.Add(targetIndex);

                Trace.WriteLine("-");
                Trace.WriteLine($"{sourceIndex}:{sourceValue} -> {inputInts[sourceIndex]}");
                Trace.WriteLine($"{targetIndex}:{targetValue} -> {inputInts[targetIndex]}");
                Trace.WriteLine($"{string.Join(",", inputInts)}");
                Trace.WriteLine("-");
            }

            return inputInts
                .Where((value, index) => !helped.Contains(index))
                .OrderBy(o => o)
                .Select(s => s.ToString())
                .Aggregate((i, i1) => string.Join(",", i, i1));
        }
    }
}