using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Collections//Вариант 14
{/*Задание
1). Создать необобщенную коллекцию ArrayList.
  a. Заполните ее 5-ю случайными целыми числами
  b. Добавьте к ней строку
  c. Удалите заданный элемент
  d. Выведите количество элементов и коллекцию на консоль.
  e. Выполните поиск в коллекции значения
2). Создать обобщенную коллекцию в соответствии с вариантом задания и
заполнить ее данными, тип которых определяется вариантом задания (колонка
– первый тип).
  a. Вывести коллекцию на консоль
  b. Удалите из коллекции n элементов
  c. Добавьте другие элементы (используйте все возможные методы
добавления для вашей коллекции).
  d. Создайте вторую коллекцию (см. таблицу) и заполните ее данными из
первой коллекции.
  e. Выведите вторую коллекцию на консоль. В случае не совпадения
количества параметров (например, LinkedList<T> и Dictionary<Tkey,
TValue>), при нехватке - генерируйте ключи, в случае избыточности –
оставляйте TValue.
  f. Найдите во-второй коллекции заданное значение.*/

    /*14) 
      Первая коллекция - HashSet<T>; 
      Первый тип - long; 
      Вторая коллекция - SortedList<TKey, TValue>*/

    /*3). Повторите задание п.2 для пользовательского типа данных (в качестве типа
    T возьмите любой свой класс из лабораторной №5 Наследование…. ). Не
    забывайте о необходимости реализации интерфейсов (IComparable,
    ICompare,….). При выводе коллекции используйте цикл foreach.
    4). Создайте объект наблюдаемой коллекции ObservableCollection<T>. Создайте
    произвольный метод и зарегистрируйте его на событие CollectionChange.
    Напишите демонстрацию с добавлением и удалением элементов. В качестве
    типа T используйте свой класс из лабораторной №5 Наследование….*/

    /*Обзор коллекций*/
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList<string> list = new ArrayList<string>() { "A", "B", "C", "D", "E", "F", "J", "H", "I", "G", "K", "L" };

            // перебор значений
            foreach (object o in list)
            {
                Console.Write($"{o} ");
            }

            //количество элементов
            Console.WriteLine($"\nколичество элементов: {list.Count}");

            Console.WriteLine($"\n - заносим в список элемент 'FF' ");
            list.Add("FF"); // заносим в список строковый массив

            // перебор значений
            foreach (object o in list)
            {
                Console.Write($"{o} ");
            }

            // удаляем первый элемент
            Console.WriteLine($"\n{list[0]} - удаляем первый элемент");
            list.RemoveAt(0);

            // перебор значений
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i]} ");
            }

            // получение элемента по индексу
            Console.WriteLine($"\n{list[0]} - получение элемента по индексу [0]");

            //поиск в коллекции значения
            if (list.Contains("E"))
            {
                // перебор значений
                foreach (object o in list)
                {
                    if (o == "E")
                    {
                        Console.Write($"\n{o} - 'E' поиск успешен");
                    }
                    else
                    {
                        Console.Write($"\n{o} - не 'E' ");
                    }
                }              
            }
            Console.WriteLine($"\n");

            var hs = new System.Collections.Generic.HashSet<long>();
            for (long i = 0; i < 10; i++)
            {
                hs.Add(i);               
            }
            
            foreach (var item in hs)
            {
                Console.Write($" {item}");
            }
            Console.WriteLine();

            for (int i = 0; i < hs.Count; i++)
            {
                hs.Remove(i+1);
            }
            
            foreach (var item in hs)
            {
                Console.Write($" {item}");
            }
            Console.WriteLine("\n");

            var sl = new System.Collections.Generic.SortedList<long, string>();

            foreach (var item in hs)
            {
                sl.Add(item, "Book");
            }         

            foreach (var item in sl)
            {
                Console.Write($" {item}");
            }
            Console.WriteLine("\n");

            foreach (var item in sl)
            {
                if (item.Key == 9)
                {
                    Console.WriteLine($"Совпадение по запросу: 9 - найдено! ({item.Key})");
                }
                else
                {
                    Console.WriteLine($"Совпадение по запросу: 9 - не найдено!!! ({item.Key})");
                }
            }
            Console.WriteLine("\n");
          
            var CrocoSortedList = new System.Collections.Generic.SortedList<float, Crocodile<string>>();
            CrocoSortedList.Add(0, new Crocodile<string>("Crocodile1", 4));
            CrocoSortedList.Add(1, new Crocodile<string>("Crocodile2", 3));
            CrocoSortedList.Add(2, new Crocodile<string>("Crocodile3", 2));
            CrocoSortedList.Add(3, new Crocodile<string>("Crocodile4", 5));
            CrocoSortedList.Add(4, new Crocodile<string>("Crocodile5", 7));
            CrocoSortedList.Add(5, new Crocodile<string>("Crocodile6", 6));
            CrocoSortedList.Add(6, new Crocodile<string>("Crocodile7", 9));
            CrocoSortedList.Add(7, new Crocodile<string>("Crocodile8", 8));
            CrocoSortedList.Add(8, new Crocodile<string>("Crocodile9", 2));
            CrocoSortedList.Add(9, new Crocodile<string>("Crocodile10", 1));

            // Вывод значения полей объектов на консоль. Используется перегруженный метод ToString() класса Crocodile<T> .                                
            foreach (object o in CrocoSortedList)
            {
                Console.Write($"\n{o} ");
            }
            Console.WriteLine("\n");

            //поиск в коллекции значения
            foreach (var item in CrocoSortedList)
            {
                if (item.Value == CrocoSortedList[3])
                {
                    Console.WriteLine($"Совпадение по запросу: Crocodile4 - найдено! ({item.Key})");
                }
                else
                {
                    Console.WriteLine($"Совпадение по запросу: Crocodile4 - не найдено!!! ({item.Key})");
                }
            }
            Console.WriteLine("\n");
                    
            var CrocoHashSet = new System.Collections.Generic.HashSet<Crocodile<string>>();
            foreach (var item in CrocoSortedList)
            {
                CrocoHashSet.Add(item.Value);
            }

            // Вывод значения полей объектов на консоль. Используется перегруженный метод ToString() класса Crocodile<T> .                                
            foreach (object o in CrocoHashSet)
            {
                Console.Write($"\n{o} ");
            }
            Console.WriteLine("\n");        

            // Удаляем элемент с идентификационным номером 3. Компаратор будет сравнивать объекты именно по идентификационному номеру соответствие имени объекта не учитывается.
            Console.WriteLine("\nУдаляем элемент с идентификатором(\"3\")");            
            CrocoHashSet.Remove(new Crocodile<string>("Crocodile4", 5));

            // Вывод значения полей объектов на консоль. Используется перегруженный метод ToString() класса Crocodile<T> .                                
            foreach (object o in CrocoHashSet)
            {
                Console.Write($"\n{o} ");
            }
            Console.WriteLine("\n");


            //-------------------------------------------------------------------------------------------------------

            ObservableCollection<Crocodile<string>> crocodiles = new ObservableCollection<Crocodile<string>>
            {
                new Crocodile<string>("Crocodile4", 5),
                new Crocodile<string>("Crocodile11", 6),
                new Crocodile<string>("Crocodile12", 7)
            };

            crocodiles.CollectionChanged += Users_CollectionChanged;

            crocodiles.Add(new Crocodile<string>("Crocodile13", 5));
            crocodiles.RemoveAt(1);
            crocodiles[0] = new Crocodile<string>("Crocodile14", 6);

            foreach (Crocodile<string> crocodile in crocodiles)
            {
                Console.WriteLine(crocodile.Name);
            }

            Console.ReadLine();
        }
        private static void Users_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    Crocodile<string> newCroco = e.NewItems[0] as Crocodile<string>;
                    Console.WriteLine($"Добавлен новый объект: {newCroco.Name}");
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    Crocodile<string> oldCroco = e.OldItems[0] as Crocodile<string>;
                    Console.WriteLine($"Удален объект: {oldCroco.Name}");
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    Crocodile<string> replacedCroco = e.OldItems[0] as Crocodile<string>;
                    Crocodile<string> replacingCroco = e.NewItems[0] as Crocodile<string>;
                    Console.WriteLine($"Объект {replacedCroco.Name} заменен объектом {replacingCroco.Name}");
                    break;
            }
        }
    }


    public class Crocodile<T> : IComparable, System.Collections.IComparer, System.Collections.IEnumerable, IEquatable<Crocodile<T>>//Крокодил
    {
        public string Name;
        public float BodyLength;
        public int Weight;
        public string crocodile { get; set; }//крокодил

        public Crocodile(string name, float bodyLength)
        {
            Name = name;
            BodyLength = bodyLength;          
        }
        public Crocodile(string name, float bodyLength, int weight)
        {
            Name = name;
            BodyLength = bodyLength;
            Weight = weight;
        }

        public Crocodile()
        {
        }

        public override string ToString()
        {
            return string.Format("Рептилия: {0} \t Длина тела = {1}; Вес = {2}.", Name, BodyLength, Weight);
        }
        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            Crocodile<T> temp = (Crocodile<T>)obj;            
            if (temp == null) return false;
            else return base.Equals(temp);
            //return Name == temp.Name &&
            //BodyLength == temp.BodyLength &&
            //Weight == temp.Weight;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        // Метод определения базового класса Object.
        public bool Equals(Crocodile<T> CR)
        {
            if (CR == null) return false;
            return (this.Name.Equals(CR.Name));
        }
        public int CompareTo(object obj)// определяет среднию длину тела крокодилов заданного вида
        {
            Crocodile<T> CR = obj as Crocodile<T>;

            if (CR != null)
            {
                if (this.BodyLength < CR.BodyLength)
                {
                    return -1;
                }
                else if (this.BodyLength > CR.BodyLength)
                {
                    return 1;
                }
                else
                    return 0;
            }
            else
            {
                throw new Exception("Параметр должен быть типа Crocodile");
            }
        }
        public static bool operator >(Crocodile<T> first, Crocodile<T> second)
        {
            if (first.floatValue > second.floatValue)
                return true;
            else
                return false;
        }
        public static bool operator <(Crocodile<T> first, Crocodile<T> second)
        {
            if (first.floatValue < second.floatValue)
                return true;
            else
                return false;
        }      
        public float floatValue { get; set; }
        public int intValue { get; set; }
        public string stringValue { get; set; }

        public int Compare(object x, object y)
        {
            throw new NotImplementedException();
        }

        string[] crocodiles = { "Crocodile_1", "Crocodile_2", "Crocodile_3", "Crocodile_4", "Crocodile_5", "Crocodile_6", "Crocodile_7", "Crocodile_8", "Crocodile_9", "Crocodile_10", };
        //public System.Collections.Generic.IEnumerator<string> GetEnumerator()
        //{
        //    throw new CrocodileEnumerator(crocodiles);
        //}

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    class CrocodileEnumerator : System.Collections.Generic.IEnumerator<string>
    {
        string[] days;
        int position = -1;
        public CrocodileEnumerator(string[] crocodiles)
        {
            this.days = crocodiles;
        }

        public string Current
        {
            get
            {
                if (position == -1 || position >= days.Length)
                    throw new InvalidOperationException();
                return days[position];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            if (position < days.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            position = -1;
        }
        public void Dispose() { }
    }

    #region Список на основе массива — динамический массив (Array List).
    /// <summary>
    /// Иногда от коллекции требуется неограниченная вместимость и простота использования списка, но при этом константное время доступа к произвольному элементу, как в массиве. 
    /// В этом случае используется список на основе массива — динамический массив(Array List).
    /// </summary>     
    #endregion
    public class ArrayList<T> : System.Collections.Generic.IList<T>
    {
        T[] _items;

        public ArrayList()
            : this(0)
        {
        }

        public ArrayList(int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("length");
            }

            _items = new T[length];
        }

        #region Метод IndexOf
        /// <summary>
        /// Поведение: возвращает индекс первого элемента, значение которого равно предоставленному, или -1, если такого значения нет.
        /// Сложность: O(n).
        /// </summary>           
        #endregion
        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        #region Метод Insert
        /// <summary>
        /// Поведение: добавляет элемент по указанному индексу. Если индекс равен количеству элементов или больше него, кидает исключение.
        /// Сложность: O(n).
        /// </summary>      
        #endregion
        public void Insert(int index, T item)
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            if (_items.Length == this.Count)
            {
                this.GrowArray();
            }

            // Shift all the items following index one slot to the right.
            Array.Copy(_items, index, _items, index + 1, Count - index);

            _items[index] = item;

            Count++;
        }

        #region Метод RemoveAt
        /// <summary>
        /// Поведение: удаляет элемент, расположенный по заданному индексу.
        /// Сложность: O(n).
        /// </summary>     
        /// <remarks>
        /// Удаление элемента по индексу — операция, обратная вставке.Указанный элемент удаляется, а остальные сдвигаются на одну позицию влево.
        /// </remarks>      
        #endregion
        public void RemoveAt(int index)
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            int shiftStart = index + 1;
            if (shiftStart < Count)
            {
                // Shift all the items following index one slot to the left.
                Array.Copy(_items, shiftStart, _items, index, Count - shiftStart);
            }

            Count--;
        }

        #region Метод Item
        /// <summary>
        /// Поведение: позволяет прочитать или изменить значение по индексу.
        /// Сложность: O(1).
        /// </summary>       
        #endregion
        public T this[int index]
        {
            get
            {
                if (index < Count)
                {
                    return _items[index];
                }

                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index < Count)
                {
                    _items[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        #region Метод Add       
        /// <summary>
        /// Поведение: добавляет элемент в конец списка.
        /// Сложность: O(1), если осталось более одного свободного места; O(n), если необходимо расширение массива.
        /// </summary>    
        /// <returns>Метод не возвращает значения</returns>       
        #endregion
        public void Add(T item)
        {
            if (_items.Length == Count)
            {
                GrowArray();
            }

            _items[Count++] = item;
        }

        #region Метод Clear
        /// <summary>
        /// Поведение: удаляет все элементы из списка.
        /// Сложность: O(1).
        /// </summary>   
        /// <remarks>
        /// Существет два варианта реализации метода Clear.В первом случае создается новый пустой массив, во втором — только обнуляется поле Count. 
        /// В данной реализации будет создаваться новый массив нулевой длины.
        /// </remarks>     
        #endregion
        public void Clear()
        {
            _items = new T[0];
            Count = 0;
        }

        #region Метод Contains
        /// <summary>
        /// Поведение: возвращает true, если значение есть в списке, и false в противном случае.
        /// Сложность: O(n).
        /// </summary>      
        #endregion
        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        #region Метод CopyTo
        /// <summary>
        /// Поведение: копирует все элементы из внутреннего массива в указанный, начиная с указанного индекса.
        /// Сложность: O(n).
        /// </summary>     
        /// <remarks>
        /// В данной реализации не используется метод CopyTo массива _items, поскольку тут задуманно скопировать только элементы с индексами от 0 до Count, а не весь массив.
        /// При использовании Array.Copy мы можем указать количество копируемых элементов. 
        /// </remarks>
        #endregion
        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(_items, 0, array, arrayIndex, Count);
        }

        #region Метод Count
        /// <summary>
        /// Поведение: возвращает текущее количество элементов в коллекции. Если список пуст, возвращает 0.
        /// Сложность: O(1).    
        /// </summary>       
        /// <remarks>
        /// Count — автоинкрементируемое поле с приватным сеттером и публичным геттером.
        /// Пользователь может только прочитать его, а изменять будут методы добавления и удаления элементов.
        /// </remarks>
        #endregion
        public int Count
        {
            get;
            private set;
        }

        #region Метод IsReadOnly
        /// <summary>
        /// Поведение: всегда возвращает false, так как наша коллекция изменяемая.
        /// Сложность: O(1).
        /// </summary>      
        #endregion
        public bool IsReadOnly
        {
            get { return false; }
        }

        #region Метод Remove
        /// <summary>
        /// Поведение: удаляет первый элемент, значение которого равно предоставленному. Возвращает true, если элемент был удален, или false в противном случае.
        /// Сложность: O(n).
        /// </summary>      
        #endregion
        public bool Remove(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        #region Перебор: Метод GetEnumerator
        /// <summary>
        /// Поведение: возвращает итератор IEnumerator<T> для прохода по всем элементам списка.
        /// Сложность: Получение итератора — O(1), обход списка — O(n).      
        /// </summary>   
        /// <remarks>
        /// Заметьте, что мы не можем просто пройтись по массиву _items, так как он содержит еще не заполненные ячейки, поэтому мы ограничиваем диапазон, 
        /// по которому будем итерироваться количеством элементов.
        /// </remarks> 
        #endregion
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _items[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #region Расширение массива: подход Mono/Rotor
        /// <summary>
        /// Данная реализация будет использовать увеличение вдвое (подход Mono/Rotor)
        /// </summary>       
        #endregion
        private void GrowArray()
        {
            int newLength = _items.Length == 0 ? 16 : _items.Length << 1;

            T[] newArray = new T[newLength];

            _items.CopyTo(newArray, 0);

            _items = newArray;
        }
    }
}
