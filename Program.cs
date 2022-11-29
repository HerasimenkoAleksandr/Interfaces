using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    interface IShape
    {
        void DrawShape();

    }
    abstract class CollectionShapes
    {
       protected List<IShape> collectionShapes;
       public  CollectionShapes()
        {
            collectionShapes = new List<IShape>();
        }
        public void Show()
        {
            Console.Clear();
            foreach (var g in collectionShapes)
            {
               
                g.DrawShape();
               
            }
            Console.ReadLine();
        }
        public abstract void CreateShape();

    }

    class Shapes: CollectionShapes
    {
       
        

        public override void CreateShape()
        {
            Console.WriteLine("Укажите какую фигуру Вы хотите создать нажав соответствующий ей номер");
            Console.WriteLine("1- прямоугольник\n2- треугольник\n3- ромб ");
            int a = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Выберите цвет, где\n1- синий\n2- зеленый\n4- красный ");
            int ShapesColor = Int32.Parse(Console.ReadLine());
            switch (a)
            {
                case 1:
                    {
                        IShape aw= new Rectangle(ShapesColor);
                        collectionShapes.Add(aw);
                        break;
                }
                case 2:
                    {
                       IShape aw = new Triangle(ShapesColor);
                        collectionShapes.Add(aw);
                        break;
                        
                    }
                case 3:
                    {
                        
                        IShape aw = new Rhombus(ShapesColor);
                        collectionShapes.Add(aw);
                        break;

                    }
                default:
                    {
                        throw new IndexOutOfRangeException();


                    }
            }
          
           
        }
    }


    class Rectangle : IShape
    {
        private int Color;
        private int Side1;
        private int Side2;
        private int x;
        private int y;
        public Rectangle(int RectangleColor)
        {
            Color = RectangleColor;
            Console.Write("Укажите длину: ");
            Side1 = int.Parse(Console.ReadLine());
            Console.Write("Укажите ширину: ");
            Side2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Также укажите координаты где разместить фигуру: ");
            Console.Write("x: ");
            x = int.Parse(Console.ReadLine());
            Console.Write("y: ");
            y = int.Parse(Console.ReadLine());
        }
        public void DrawShape()
        {
            Console.ForegroundColor = (ConsoleColor)Color;


            for (int i = 0; i < Side1; i++)
            {

                Console.SetCursorPosition(x + i, y + Side2);
                Console.WriteLine("*");
                if (i == Side1 - 1)
                {
                    Console.SetCursorPosition(x + i + 1, y + Side2);
                    Console.WriteLine("*");
                }

                Console.SetCursorPosition(x + i, y);
                Console.WriteLine("*");
            }
            for (int i = 0; i < Side2; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine("*");

                Console.SetCursorPosition(x + Side1, y + i);
                Console.WriteLine("*");




            }


        }
    }
    class Triangle : IShape
    {
        private int Color;
        private int Side1;
        private int Side2;
        private int x;
        private int y;

        public Triangle(int RectangleColor)
        {
            Color = RectangleColor;
            Console.WriteLine("Будет создан прямоугольный треугольник!");
            Console.Write("Укажите длину стороны : ");
            Side1 = int.Parse(Console.ReadLine());
            Console.Write("Укажите длину другой стороны: ");
            Side2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Также укажите координаты где разместить фигуру: ");
            Console.Write("x: ");
            x = int.Parse(Console.ReadLine());
            Console.Write("y: ");
            y = int.Parse(Console.ReadLine());
        }
        public void DrawShape()
        {
            Console.ForegroundColor = (ConsoleColor)Color;

            try { 
            for (int i = 0; i < Side1; i++)
            {

                Console.SetCursorPosition(x + i, y + Side2);
                Console.WriteLine("*");
             
            }
            for (int i = 0; i < Side2; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine("*");

              }
                if (Side1 > Side2)
                {
                    int j = (int)(Side1 / Side2);
                    for (int i = 0; i < Side2; i++)
                    {
                        if (i == 0)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.WriteLine("*");
                        }
                        else
                        {
                            Console.SetCursorPosition(x += j, y + i);
                            Console.WriteLine("*");
                        }

                    }
                }
                else
                {
                    int j = (int)(Side2 / Side1);
                    for (int i = 0; i < Side1; i++)
                    {
                        if (i == 0)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.WriteLine("*");
                            Console.SetCursorPosition(x + Side1, y+Side2);
                            Console.WriteLine("*");
                        }
                        else
                        {
                            Console.SetCursorPosition(x +i, y +=j);
                            Console.WriteLine("*");
                        }

                    }
                }
                }
            catch(Exception x)
            {
                Console.Clear();
                Console.WriteLine("Треугольник: Размеры фигуры не должны выходить за поля консоли. Возможно надо расположить фигуру по центру консоли.");
            }
}
    }
    class Rhombus : IShape
    {
        private int Color;
        private int Side1;
        private int Side2;
        private int x;
        private int y;
        public Rhombus(int RhombusColor)
        {
            Color = RhombusColor;
            Console.Write("Укажите размер диагонали по длине: ");
            Side1 = int.Parse(Console.ReadLine());
            Console.Write("Укажите размер диагонали по ширине: ");
            Side2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Также укажите координаты где разместить фигуру: ");
            Console.Write("x: ");
            x = int.Parse(Console.ReadLine());
            Console.Write("y: ");
            y = int.Parse(Console.ReadLine());
        }
        public void DrawShape()
        {
            Console.BackgroundColor = (ConsoleColor)Color;


            try
            {
                int j = (int)(Side1 / Side2);
                for (int i = 0; i < Side2; i++)
                {



                    x += j;
                    Console.SetCursorPosition(x, y + i);
                    Console.WriteLine("*");
                    Console.SetCursorPosition(x, y - i);
                    Console.WriteLine("*");

                }
                for (int i = Side2; i >= 0; i--)
                {
                    x += j;
                    Console.SetCursorPosition(x, y + i);
                    Console.WriteLine("*");
                    Console.SetCursorPosition(x, y - i);
                    Console.WriteLine("*");



                }
            }
            catch(Exception x)
            {
                Console.Clear();
                Console.WriteLine("РОМБ: Размеры фигуры не должны выходить за поля консоли.\n Возможно надо расположить фигуру по центру консоли или укажите меньше размеры");
            }
        }
    }
    
   
    class Program
    {
        
        public static void Main()
        {
            Console.WriteLine("Давайте добавим три фигуры!");
            CollectionShapes a= new Shapes();
            Console.WriteLine("Фигура 1");
            a.CreateShape();
            Console.Clear();
            Console.WriteLine("Фигура 2");
            a.CreateShape();
            Console.Clear();
            Console.WriteLine("Фигура 3");
            a.CreateShape();
            Console.Clear();
            a.Show();
           


        }
    }
}
