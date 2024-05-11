using System.Reflection;
using System.Text;
using System.Xml;

// Random rand = new Random();
//
// string fileName = "Data.txt";
//
// string assemblyLocation = Assembly.GetExecutingAssembly().Location;
//
// string programDirectory = Path.GetDirectoryName(assemblyLocation);
//
// string filePath = Path.Combine(programDirectory, fileName);
//
// string massPath = Path.Combine(programDirectory, "mass.txt");
//
// using (StreamWriter writer = new StreamWriter(massPath))
// {
//     using (StreamWriter sr = new StreamWriter(filePath))
//     {
//         for (int i = 10; i <= 1000; i += 1)
//         {
//             List<int> massSize = new List<int>();
//
//             for (int j = 0; j < 10; ++j)
//             {
//                 List<int> arr = new List<int>();
//
//                 massSize.Add(i);
//
//                 for (int g = 0; g < i; ++g)
//                 {
//                     arr.Add(rand.Next(-i, i));
//                 }
//
//                 BasicQuickSort.Sort(arr);
//                 MedianOfThreeQuickSort.Sort(arr);
//                 ThreePivotQuickSort.Sort(arr);
//
//                 sr.Write(BasicQuickSort.compr);
//                 sr.Write(" ");
//                 sr.Write(MedianOfThreeQuickSort.compr);
//                 sr.Write(" ");
//                 sr.Write(ThreePivotQuickSort.compr);
//                 sr.Write("\n");
//             }
//
//             writer.WriteLine(string.Join(" ", massSize));
//         }
//     }
// }

try
{ 
    Console.WriteLine("Введіть назву файлу у форматі 'file_name.txt'");

    string fileName = Console.ReadLine();

    string assemblyLocation = Assembly.GetExecutingAssembly().Location;

    string programDirectory = Path.GetDirectoryName(assemblyLocation);

    string filePath = Path.Combine(programDirectory, fileName);

    List<int> array = new List<int>();
    string? line;
    
    using StreamReader sr = new StreamReader(filePath, Encoding.UTF8);
    int amount = int.Parse(sr.ReadLine());
    while ((line = sr.ReadLine()) != null)
    {
        array.Add(int.Parse(line));
    }
    
    BasicQuickSort.Sort(array);
    MedianOfThreeQuickSort.Sort(array);
    ThreePivotQuickSort.Sort(array);
    
    string fileNameOutput = fileName.Replace(".txt", "_output.txt");
    string filePathOutput = Path.Combine(programDirectory, fileNameOutput);

    using (StreamWriter sw = new StreamWriter(filePathOutput))
    {
        sw.Write(BasicQuickSort.compr);
        sw.Write(" ");
        sw.Write(MedianOfThreeQuickSort.compr);
        sw.Write(" ");
        sw.Write(ThreePivotQuickSort.compr);
        sw.Write("\n");
        // for (int i = 0; i < array.Count; ++i)
        //     sw.WriteLine(array[i]);
    }
}
catch
{
    Console.WriteLine("Помилка");
}

class BasicQuickSort
{
    public static int compr;
    static int Partition(List<int> arr, int start, int end)
    {
        int x = arr[end];
        int i = start;

        for (int j = start; j < end; ++j)
        {
            compr++;
            if (arr[j] <= x)
            {
                (arr[i], arr[j]) = (arr[j], arr[i]);
                ++i;
            }
        }
        (arr[i], arr[end]) = (arr[end], arr[i]);

        return i;
    }

    static void QuickSort(List<int> arr, int start, int end)
    {
        if (start < end)
        {
            int g = Partition(arr, start, end);
            QuickSort(arr, start, g - 1);
            QuickSort(arr, g + 1, end);
        }
    }

    public static void Sort(List<int> arr)
    {
        compr = 0;
        List<int> copy = new List<int>(arr);
        QuickSort(copy, 0, arr.Count - 1);
    }
}

class MedianOfThreeQuickSort
{
    public static int compr = 0;
    
    static void InsertionSort(List<int> arr, int start, int end)
    {
        for (int i = ++start; i <= end; ++i)
        {
            int key = arr[i];
            int j = i - 1;
            
            while (j >= 0 && arr[j] > key)
            {
                ++compr;
                arr[j + 1] = arr[j];
                --j;
            }

            arr[j + 1] = key;
        }
    }
    
    static int PartitionMedian(List<int> arr, int start, int end)
    {
        int medianIndex = MedianIndex(arr, start, (start + end) / 2, end);
        
        (arr[medianIndex], arr[end]) = (arr[end], arr[medianIndex]);

        return Partition(arr, start, end);
    }
    
    static int MedianIndex(List<int> arr, int start, int med, int end)
    {
        if (arr[start] < arr[med])
        {
            if (arr[med] < arr[end])
                return med;
            if (arr[start] < arr[end])
                return end;
            
            return start;
        }
        
        if (arr[start] < arr[end])
            return start;
        if (arr[med] < arr[end])
            return end;
        
        return med;
    }
    
    static int Partition(List<int> arr, int start, int end)
    {
        int x = arr[end];
        int i = start;

        for (int j = start; j < end; ++j)
        {
            compr++;
            if (arr[j] <= x)
            {
                (arr[i], arr[j]) = (arr[j], arr[i]);
                ++i;
            }
        }
        (arr[i], arr[end]) = (arr[end], arr[i]);

        return i;
    }

    static void QuickSort(List<int> arr, int start, int end)
    {
        if (start < end)
        {
            if (end - start > 3)
            {
                int g = PartitionMedian(arr, start, end);
                QuickSort(arr, start, g - 1);
                QuickSort(arr, g + 1, end);
            }
            else
            {
                InsertionSort(arr, start, end);
            }
        }
    }

    public static void Sort(List<int> arr)
    {
        compr = 0;
        List<int> copy = new List<int>(arr);
        QuickSort(copy, 0, arr.Count - 1);
    }
}

class ThreePivotQuickSort
{
    public static int compr;

    static (int, int, int) PartitionOfThree(List<int> arr, int start, int end)
    {
        int a = start + 2;
        int b = start + 2;
        int c = end - 1;
        int d = end - 1;
        int p = arr[start];
        int q = arr[start + 1];
        int r = arr[end];
        
        while (b <= c)
        {
            while (arr[b] < q && b <= c)
            {
                ++compr;
                ++compr;
                if (arr[b] < p)
                {
                    (arr[a], arr[b]) = (arr[b], arr[a]);
                    ++a;
                }

                ++b;
            }
            ++compr;
            
            while (arr[c] > q && b <= c)
            {
                ++compr;
                ++compr;
                if (arr[c] > r)
                {
                    (arr[c], arr[d]) = (arr[d], arr[c]);
                    --d;
                }

                --c;
            }
            ++compr;
            
            if (b <= c)
            {   
                ++compr;
                if (arr[b] > r)
                {
                    ++compr;
                    if (arr[c] < p)
                    {
                        (arr[b], arr[a]) = (arr[a], arr[b]);
                        (arr[a], arr[c]) = (arr[c], arr[a]);
                        ++a;
                    }
                    else
                    {
                        (arr[b], arr[c]) = (arr[c], arr[b]);
                    }

                    (arr[c], arr[d]) = (arr[d], arr[c]);
                    ++b;
                    --c;
                    --d;
                }
                else
                {
                    ++compr;
                    if (arr[c] < p)
                    {
                        (arr[b], arr[a]) = (arr[a], arr[b]);
                        (arr[a], arr[c]) = (arr[c], arr[a]);
                        ++a;
                    }
                    else
                    {
                        (arr[b], arr[c]) = (arr[c], arr[b]);
                    }

                    ++b;
                    --c;
                }
            }
        }

        --a;
        --b;
        ++c;
        ++d;

        (arr[start + 1], arr[a]) = (arr[a], arr[start + 1]);
        (arr[a], arr[b]) = (arr[b], arr[a]);
        --a;
        (arr[start], arr[a]) = (arr[a], arr[start]);
        (arr[end], arr[d]) = (arr[d], arr[end]);

        return (a, b, d);
    }
    
    static void InsertionSort(List<int> arr, int start, int end)
    {
        for (int i = ++start; i <= end; ++i)
        {
            int key = arr[i];
            int j = i - 1;
            
            while (j >= 0 && arr[j] > key)
            {
                ++compr;
                arr[j + 1] = arr[j];
                --j;
            }


            arr[j + 1] = key;
        }
    }
    
    static void SortFirstSecondLast(List<int> list, int start, int end)
    {
        if (start > end)
            (start, end) = (end, start);
        
        if (list[start] > list[end])
            (list[start], list[end]) = (list[end], list[start]);
        if (list[start] > list[start + 1])
            (list[start], list[start + 1]) = (list[start + 1], list[start]);
        if (list[start + 1] > list[end])
            (list[start + 1], list[end]) = (list[end], list[start + 1]);
    }

    static void QuickSort(List<int> arr, int start, int end)
    {
        if (start < end)
        {
            if (end - start > 3)
            {
                SortFirstSecondLast(arr, start, end);
                var index = PartitionOfThree(arr, start, end);
                QuickSort(arr, start, index.Item1 - 1);
                QuickSort(arr, index.Item1 + 1, index.Item2 - 1);
                QuickSort(arr, index.Item2 + 1, index.Item3 - 1);
                QuickSort(arr, index.Item3 + 1, end);
            }
            else
            {
                InsertionSort(arr, start, end);
            }
        }
    }

    public static void Sort(List<int> arr)
    {
        compr = 0;
        List<int> copy = new List<int>(arr);
        QuickSort(copy, 0, arr.Count - 1);
    }
}