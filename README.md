Міністерство освіти і науки України
Національний технічний університет України «Київський політехнічний
інститут імені Ігоря Сікорського»
Факультет інформатики та обчислювальної техніки

Кафедра інформатики та програмної інженерії


Звіт

з лабораторної роботи № 3
з дисципліни
«Алгоритми та структури даних. Частина 2. Структури даних»

«Метод швидкого сортування»





 
Виконав(ла) 


Перевірив


ІП-33 Цапурда Є. Д.
(шифр, прізвище, ім'я, по батькові)
	
Соколовський В. В
(прізвище, ім'я, по батькові)

 



Київ 2024
Постановка задачі:
Реалізувати три модифікації алгоритму швидкого сортування (Quick Sort): 
Алгоритм 1. Звичайний алгоритм швидкого сортування
Алгоритм 2. Швидке сортування з 3-медіаною в якості опорного елемента
Алгоритм 3. Швидке сортування з трьома опорними елементами
та порівняти їх швидкодію. Швидкість алгоритмів порівнюється на основі підрахунку кількості порівнянь елементів масиву під час роботи алгоритмів.
Псевдокод алгоритму:
Алгоритм 1: BasicQuickSort
Partition(arr, start, end):
1.   x ← arr[end]
2.   i ← start - 1
3.   
4.   for j from start to end - 1
5.       do if arr[j] ≤ x
6.           then i ← i + 1
7.               Swap(arr[i], arr[j])
8.   
9.   Swap(arr[i + 1], arr[end])
10.  return i + 1

QuickSort(arr, start, end):
1.   if start < end
2.       then g ← Partition(arr, start, end)
3.           QuickSort(arr, start, g - 1)
4.           QuickSort(arr, g + 1, end)



Алгоритм 2: MedianOfThreeQuickSort
PartitionMedian(arr, start, end):
1.    medianIndex ← MedianIndex(arr, start, (start + end) / 2, end)
2.    swap(arr[medianIndex], arr[end])
3.    return Partition(arr, start, end)

MedianIndex(arr, start, med, end):
1.    if arr[start] < arr[med]
2.        then if arr[med] < arr[end]
3.            then return med
4.            else if arr[start] < arr[end]
5.                then return end
6.                else return start
7.        else if arr[start] < arr[end]
8.            then return start
9.            else if arr[med] < arr[end]
10.               then return end
11.               else return med

Partition(arr, start, end):
1.    x ← arr[end]
2.    i ← start
3.    
4.    for j from start to end - 1
5.        do if arr[j] ≤ x
6.               then swap(arr[i], arr[j])
7.                    i ← i + 1
8.    
9.    swap(arr[i], arr[end])
10.   return i

QuickSort(arr, start, end):
1.    if start < end
2.        then if end - start > 3
3.            then g ← PartitionMedian(arr, start, end)
4.                 QuickSort(arr, start, g - 1)
5.                 QuickSort(arr, g + 1, end)
6.            else InsertionSort(arr, start, end)

InsertionSort(arr, start, end):
1.    for i from start + 1 to end
2.        do key ← arr[i]
3.           j ← i - 1
4.           while j ≥ 0 and arr[j] > key
5.                 do arr[j + 1] ← arr[j]
6.                    j ← j - 1
7.           arr[j + 1] ← key

Алгоритм 3: ThreePivotQuickSort
PartitionOfThree(arr, start, end):
1.    a ← start + 2
2.    b ← start + 2
3.    c ← end - 1
4.    d ← end - 1
5.    p ← arr[start]
6.    q ← arr[start + 1]
7.    r ← arr[end]
8.    
9.    while b ≤ c
10.       do while arr[b] < q and b ≤ c
11.              do if arr[b] < p
12.                     then swap(arr[a], arr[b])
13.                          a ← a + 1
14.                 b ← b + 1
15.         while arr[c] > q and b ≤ c
16.              do if arr[c] > r
17.                     then if arr[c] < p
18.                             then swap(arr[b], arr[a])
19.                                  swap(arr[a], arr[c])
20.                                  a ← a + 1
21.                             else swap(arr[b], arr[c])
22.                           swap(arr[c], arr[d])
23.                           d ← d - 1
24.                    c ← c - 1
25.         if b ≤ c
26.            then if arr[b] > r
27.                    then if arr[c] < p
28.                             then swap(arr[b], arr[a])
29.                                  swap(arr[a], arr[c])
30.                                  a ← a + 1
31.                             else swap(arr[b], arr[c])
32.                           swap(arr[c], arr[d])
33.                           b ← b + 1
34.                           c ← c - 1
35.                           d ← d - 1
36.                    else if arr[c] < p
37.                             then swap(arr[b], arr[a])
38.                                  swap(arr[a], arr[c])
39.                                  a ← a + 1
40.                             else swap(arr[b], arr[c])
41.                           b ← b + 1
42.                           c ← c - 1
43.    a ← a - 1
44.    b ← b - 1
45.    c ← c + 1
46.    d ← d + 1
47.    
48.    swap(arr[start + 1], arr[a])
49.    swap(arr[a], arr[b])
50.    a ← a - 1
51.    swap(arr[start], arr[a])
52.    swap(arr[end], arr[d])
53.    
54.    return (a, b, d)

InsertionSort(arr, start, end):
1.    for i from start + 1 to end
2.        do key ← arr[i]
3.           j ← i - 1
4.           while j ≥ 0 and arr[j] > key
5.                 do arr[j + 1] ← arr[j]
6.                    j ← j - 1
7.           arr[j + 1] ← key

SortFirstSecondLast(list, start, end):
1.    if start > end
2.        then swap(start, end)
3.    if list[start] > list[end]
4.        then swap(list[start], list[end])
5.    if list[start] > list[start + 1]
6.        then swap(list[start], list[start + 1])
7.    if list[start + 1] > list[end]
8.        then swap(list[start + 1], list[end])

QuickSort(arr, start, end):
1.    if start < end
2.        then if end - start > 3
3.                then SortFirstSecondLast(arr, start, end)
4.                     index ← PartitionOfThree(arr, start, end)
5.                     QuickSort(arr, start, index.Item1 - 1)
6.                     QuickSort(arr, index.Item1 + 1, index.Item2 - 1)
7.                     QuickSort(arr, index.Item2 + 1, index.Item3 - 1)
8.                     QuickSort(arr, index.Item3 + 1, end)
9.                else InsertionSort(arr, start, end)

Код програми (C#): 
using System.Reflection;
using System.Text;

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

Робота програми:
Вхідний файл:
 
Рис. 1. Файл з назвою «input_02_10.txt»








Консоль програми:
 
Рис. 2. Виконана програма

Вихідний файл:
 
Рис. 3. Файл з назвою «input_02_10_output.txt»



Розрахунок складності та аналіз алгоритму:

Назва алгоритму	Звичайний алгоритм швидкого сортування
Стійкість	Не стійкий
Природність	Не природній
Необхідність в додатковій памʼяті	Не потрібна

Назва алгоритму	Швидке сортування з 3-медіаною в якості опорного елемента
Стійкість	Не стійкий
Природність	Не природній
Необхідність в додатковій памʼяті	Не потрібна

Назва алгоритму	Швидке сортування з трьома опорними елементами
Стійкість	Не стійкий
Природність	Не природній
Необхідність в додатковій памʼяті	Не потрібна

Час роботи алгоритму сортування залежить від збалансованості, що характеризує розбиття. Тобто, якщо початковий масив розбивається на два однакових за кількістю елементів масиву, тобто n/2 то таке розбиття вважається найкращим і асимптотично алгоритм працює так само швидко, як і merge sort. Час роботи в такому випадку описується нерівністю:

T(n)≤2T(n/2)+ θ(n)
Тоді:

T(n)=O(n log⁡〖n)〗

У випадку, коли процедура, що виконує розбиття, породжує одну підзадачу з n-1 елементом, а другу — з 0 елементами асимптотична поведінка алгоритму настільки ж погана, як і в алгоритму Insertion Sort. Така ситуація виникатиме і для відсортованого і для зворотно відсортованого масивів, ці випадки будуть вважатися найгіршими для алгоритму Quick Sort, проте така ситуація може виникати в якомусь з під масивів і в залежності в його розміру буде зменшуватися швидкість роботи алгоритму. Рекурентне співвідношення для найгіршого випадку можна записати так:

T(n)-T(n-1)+T(0)+θ(n)=T(n-1)+θ(n)

Тоді, розвʼязком цього співвідношення є

T(n)=θ(n^2)

Математичне очікування часу роботи алгоритму на всіх можливих вхідних масивах є O(n log⁡〖n)〗 тобто середній випадок ближчий до найкращого.

Було створено два графіки на основі кількості порівнянь, що роблять наші алгоритми під час сортування. На графіках представлено три алгоритми сортування та три лінійно – логарифмічні регресії до кожного алгоритму сортування відповідно. 









Масиви для першого графіку генерувалися наступним чином:

	Було згенеровано масиви з кількістю елементів від 10 до 1000 з кроком 1.
	Кожна розмірність масиву генерується по 10 разів, тобто, наприклад, в наші данні увійде 10 масивів по 10 елементів і так далі.

 
Рис. 4. Графік часової складності алгоритмів для масиві з кількістю елементів від 10 до 1000.




















Масиви для другого графіку генерувалися наступним чином:

	Було згенеровано масиви з кількістю елементів від 10 до 20000 з кроком 1.
	Кожна розмірність масиву генерується по 10 разів.

 
Рис. 5. Графік часової складності алгоритмів для масиві з кількістю елементів від 10 до 20000.







Код для формування графіків (Python):

import numpy as np
import matplotlib.pyplot as plt
from scipy.optimize import curve_fit

data_path = '/Users/ROBIK/Desktop/С#/QSort/QSort/bin/Debug/net8.0/Data_20.txt'
mass_path = '/Users/ROBIK/Desktop/С#/QSort/QSort/bin/Debug/net8.0/mass_20.txt'

mass_data = []

BasicQuickSort = []
MedianOfThreeQuickSort = []
ThreePivotQuickSort = []

with open(mass_path, 'r') as massFile:
    for line in massFile:
        numbers = line.split()
        for i in range(10):
            mass_data.append(int(numbers[i]))

with open(data_path, 'r') as file:
    for line in file:
        numbers = line.split()
        BasicQuickSort.append(int(numbers[0]))
        MedianOfThreeQuickSort.append(int(numbers[1]))
        ThreePivotQuickSort.append(int(numbers[2]))

def log_func(x, a, b):
    return a * x * np.log(x)

plt.scatter(mass_data, BasicQuickSort, s= 0.25, label='BasicQuickSort', c= '#3CB371')
plt.scatter(mass_data, MedianOfThreeQuickSort, s= 0.25, label='MedianOfThreeQuickSort', c= '#9370DB')
plt.scatter(mass_data, ThreePivotQuickSort, s= 0.25, label='ThreePivotQuickSort', c= '#6495ED')

params, covariance = curve_fit(log_func, mass_data, BasicQuickSort)
a, b = params
plt.plot(mass_data, log_func(np.array(mass_data), a, b), color='#006400', label='Logarithmic n * log(n) Regression of BasicQuickSort')

params, covariance = curve_fit(log_func, mass_data, MedianOfThreeQuickSort)
a, b = params
plt.plot(mass_data, log_func(np.array(mass_data), a, b), color='#FF00FF', label='Logarithmic n * log(n) Regression of MedianOfThreeQuickSort')

params, covariance = curve_fit(log_func, mass_data, ThreePivotQuickSort)
a, b = params
plt.plot(mass_data, log_func(np.array(mass_data), a, b), color='#0000FF', label='Logarithmic n * log(n) Regression of ThreePivotQuickSort')

plt.xlabel('Кількість елементів в масиві')
plt.ylabel('Кількість порівнянь')
plt.legend(markerscale = 10)

# plt.xticks(np.arange(0, 1001, 200))
# plt.yticks(np.arange(0, 14001, 2000))

plt.xticks(np.arange(0, 20001, 5000))
plt.yticks(np.arange(0, 400001, 50000))
plt.grid()

plt.show()

Код для генерації масивів (С#):

Random rand = new Random();

string fileName = "Data.txt";

string assemblyLocation = Assembly.GetExecutingAssembly().Location;

string programDirectory = Path.GetDirectoryName(assemblyLocation);

string filePath = Path.Combine(programDirectory, fileName);

string massPath = Path.Combine(programDirectory, "mass.txt");

using (StreamWriter writer = new StreamWriter(massPath))
{
    using (StreamWriter sr = new StreamWriter(filePath))
    {
        for (int i = 10; i <= 1000; i += 1)
        {
            List<int> massSize = new List<int>();

            for (int j = 0; j < 10; ++j)
            {
                List<int> arr = new List<int>();

                massSize.Add(i);

                for (int g = 0; g < i; ++g)
                {
                    arr.Add(rand.Next(-i, i));
                }

                BasicQuickSort.Sort(arr);
                MedianOfThreeQuickSort.Sort(arr);
                ThreePivotQuickSort.Sort(arr);

                sr.Write(BasicQuickSort.compr);
                sr.Write(" ");
                sr.Write(MedianOfThreeQuickSort.compr);
                sr.Write(" ");
                sr.Write(ThreePivotQuickSort.compr);
                sr.Write("\n");
            }

            writer.WriteLine(string.Join(" ", massSize));
        }
    }
}





Висновок:
Під час виконання цієї лабораторної роботи ми дослідили три варіації алгоритму швидкого сортування (Quick Sort): звичайний алгоритм швидкого сортування, швидке сортування з 3-медіаною в якості опорного елемента, швидке сортування з трьома опорними елементами. Поставлена задача полягала у підрахунку кількості порівнянь під час сортування масивів цими алгоритмами. Поставлена задача була успішно виконана, а на основі кількості порівнянь, які ми отримуємо після кожного сортування масиву було побудовано два графіки. На графіках видно, що найшвидшим є алгоритм який обирає медіану з трьох, другим по швидкості є алгоритм з трьома опорними елементами, та найповільнішим з цих трьох є звичайний алгоритм сортування. З точки зору складності алгоритму та його ефективності найкращим на мою думку є сортування з 3 – медіаною в якості опорного елементу, алгоритм з трьома опорними елементами доволі складний в реалізації, проте на результат могло вплинути те, що ця варіація сортування використовує спеціальний алгоритм для знаходження трьох опорних елементів і у підрахунку порівнянь знаходження цих елементів враховувалось, в той час як знаходження медіани з трьох не йшло у підрахунок у 2 варіації quick sort. Ще одним мінусом останніх двох варіацій являється потреба у реалізації додаткового методу сортування для малих масивів. Тому для відносно не великих масивів або обмеженої кількості використання можна обмежитися стандартним алгоритмом швидкого сортування, проте для використання на постійній основі або сортування занадто великих масивів слід реалізувати метод який бере медіану з трьох. 

![image](https://github.com/R0BIK/ThreeVariantsOfQuickSort/assets/99051328/383cb4e8-e61c-466d-8984-e623713a7aed)
