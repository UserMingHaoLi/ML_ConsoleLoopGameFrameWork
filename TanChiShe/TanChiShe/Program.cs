using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ConsoleApp1
{
    static class Program
    {
        //static void QuickSort(int[] nums, int left, int right)  //快速排序
        //{
        //    if (left >= right) return;
        //    int middle = nums[(left + right) / 2];
        //    int i = left - 1;
        //    int j = right + 1;
        //    while (true)
        //    {
        //        while (nums[++i] < middle) ;
        //        while (nums[--j] > middle) ;

        //        if (i >= j) break;

        //        int temp = nums[j];
        //        nums[j] = nums[i];
        //        nums[i] = temp;
        //    }
        //    QuickSort(nums, left, i - 1);
        //    QuickSort(nums, j + 1, right);
        //}

        
        static void Main(string[] args)
        {
            ConsoleKeyInfo info;
            //初始化
            Snake mySnake = new Snake();    //蛇
            Map map = new Map();            //地图    
            Food myFood = new Food();       //食物
            info = Console.ReadKey();
            var task = new Task(() =>
            {//创建一个多线程
                do
                {//死循环
                    if (Gm.GameOver)
                    {
                        continue;
                    }
                    Gm.infoString = info.Key.ToString();//当前读取到的用户操作
                    myFood.EatFood(mySnake[0]);//食物管理器检测食物是否被吃到(如果被吃了,食物管理器会自动刷一个新食物)
                    mySnake.SnakeLong(Gm.infoString, ref Gm.myBreak);//蛇根据用户输入移动
                    //eatBool = myFood.EatFood(mySnake[0]);
                    map.Redraw(mySnake.snakeHaed, mySnake.snakeBack);//地图画蛇
                    Thread.Sleep(100);//停止100毫秒,即0.1秒
                } while (true);
            });
            task.Start();//启动线程
            do
            {//主线程死循环
                if (Gm.GameOver)
                {//如果游戏结束了
                    ConsoleKeyInfo RanGameKey = Console.ReadKey();
                    if (RanGameKey.Key.ToString() == Gm.position.RightArrow.ToString())
                    {//等待一个新的右方向键,之后重新初始化各个单位
                        //初始化
                        mySnake = new Snake();    //蛇
                        map = new Map();            //地图    
                        myFood = new Food();       //食物
                        Gm.GameOver = false;
                    }
                    else
                    {
                        continue;
                    }
                }
                ConsoleKeyInfo info1 = Console.ReadKey();//主线程读取玩家操作
                if ((info1.Key.ToString()) == Gm.myBreak)
                {//反方向直接无视
                    continue;
                }
                info = info1;
                Gm.infoString = info.Key.ToString();//当前方向赋值,后续另一个线程可以读取
                myFood.EatFood(mySnake[0]);//和线程中同样的逻辑, 检查食物被吃,蛇移动,地图画蛇.
                mySnake.SnakeLong(Gm.infoString, ref Gm.myBreak);
                //eatBool = myFood.EatFood(mySnake[0]);
                map.Redraw(mySnake.snakeHaed, mySnake.snakeBack);
            } while (true);

            //所以分为按100毫秒渲染和按用户点击频率渲染



            Console.ReadKey();//到不了这里
        }

    }
}

