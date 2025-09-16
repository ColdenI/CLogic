# 🧮 CLogic – Математическая и матричная библиотека для C#

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![.NET](https://img.shields.io/badge/.NET-Standard-lightgrey)
![Version](https://img.shields.io/badge/version-1.0.0-brightgreen)

> 💡 Легковесная, типобезопасная библиотека для работы с числами, массивами и матрицами в C#.  
> Подходит для игр, научных вычислений, алгоритмов и учебных проектов.

---

## 📦 Что это?

**CLogic** — это набор полезных утилит и классов для упрощения рутинных задач:

- 🔢 Перевод значений между диапазонами (`map`)
- 📊 Работа с массивами: сумма, минимум, максимум
- 🧮 Универсальные матрицы: `CMatrix<T>`, `CMatrixInt`, `CMatrixDouble`
- ✅ Операции над матрицами: сложение, умножение, транспонирование
- ⌨️ Удобный ввод данных через консоль

Идеально подходит для:
- Алгоритмических задач
- Геймдева (например, Unity)
- Обработки данных
- Образовательных проектов

---

## 🚀 Быстрый старт

### 1. Установка

Просто добавьте файлы из папки `CLogic/` в ваш проект, или скопируйте классы напрямую.

Поддерживается:
- .NET Standard 2.0+
- Unity (с C# 7.3+)
- Console / Desktop / Web приложения

---

### 2. Примеры использования

#### 🔁 Map (перевод значения из одного диапазона в другой)

```csharp
int mapped = CMath.map(50, 0, 100, 0, 255); // → 127
float brightness = CMath.map(temperature, -20f, 40f, 0.2f, 1f);
```

### ➕ Сумма элементов массива
```csharp
int sum = CMath.Sum(1, 2, 3, 4); // → 10
int[] data = { 5, 10, 15 };
int total = CMath.Sum(data); // → 30
```
### ▼ Минимум и максимум
```csharp
int min = CMath.Min(5, 3, 9, 1); // → 1
int max = CMath.Max(5, 3, 9, 1); // → 9
```
## 🧱 Классы и возможности
###🧩 CMatrix<T> — Универсальная матрица
Базовый шаблонный класс для работы с двумерными данными.

```csharp
var matrix = new CMatrix<int>(3, 3);
matrix[0, 0] = 1;
matrix[1, 1] = 5;
matrix[2, 2] = 9;

matrix.ConsoleDraw("MyMatrix");
```
### Функции:
- Индексация [i,j]
- Транспонирование .Transpose()
- Копирование .Copy(), .GetTranspose()
- Поиск элементов: .IndexOf(obj), .IndexesOf(obj)
- Получение строк/столбцов: .GetRow(i), .GetColumn(j)
- Удаление строк/столбцов: .RemoveRow(...), .RemoveColumn(...)

## 🟩 CMatrixInt — Матрица целых чисел
```csharp
var a = new CMatrixInt(new int[,] {
    { 1, 2 },
    { 3, 4 }
});

var b = new CMatrixInt(new int[,] {
    { 5, 6 },
    { 7, 8 }
});

var sum = a + b;      // Сложение
var product = a * b;  // Умножение
var transposed = a.GetTranspose();
```
### Дополнительно:
- .Sum, .Min, .Max — агрегатные свойства
- Перегрузка операторов (+, -, *, ==, !=)
- Явное приведение: (CMatrixInt)doubleMatrix

## 🔵 CMatrixDouble — Матрица дробных чисел
Аналогично CMatrixInt, но для типа double.

```csharp
var m = new CMatrixDouble(2, 2);
m[0, 0] = 1.5;
m[1, 1] = 3.14;

double total = m.Sum;
double maxVal = m.Max;
```
Поддерживает все те же операции, включая смешанную арифметику с CMatrixInt.

##🖨️ Вывод в консоль
```csharp
CMatrix.ConsoleDraw(matrix, "A"); // Статический вывод
matrix.ConsoleDraw("B");           // Через экземпляр
```
Вывод:
```
Matrix: A[3x3] T:False
1       0       0
0       5       0
0       0       9
```
## 📥 Ввод данных с консоли (EnterData)
Удобные методы для интерактивного ввода:
```csharp
int age = EnterData.GetInt("Enter your age", "years", range: new[]{1, 120});
double temp = EnterData.GetDouble("Enter temperature");

// Заполнить матрицу вручную
var mat = new CMatrixInt(2, 2);
EnterData.WriteInMatrix(ref mat, "Input");
```
💡 Полезно для тестирования и прототипирования! 

## 🧪 Исключения
Класс CMatrixException выбрасывается при:

Несоответствии размеров при сложении
Ошибке умножения матриц
```csharp
try {
    var result = a + b;
} catch (CMatrixException ex) {
    Console.WriteLine(ex.Message);
}
```
## 🛠️ Технологии
- Язык: C# 8.0+
- Платформа: .NET Standard 2.0

Особенности:
- Без внешних зависимостей
- Поддержка Generic
- Перегрузка операторов
- Чистый ООП

## 🤝 Как использовать?
1. Склонируйте репозиторий или скопируйте файлы
2. Добавьте в ваш проект
3. Используйте пространство имён:
```csharp
using CLogic;
```
## 📜 Лицензия
MIT License — можно свободно использовать в личных и коммерческих проектах.

## 📬 Автор
- Разработчик: ColdenI
- Email: andreiakulin2005044@gmail.com
- GitHub: @ColdenI

