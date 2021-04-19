using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Map
    {

        private char[,] Maps = new char[Gm.height, Gm.width];//地图的字符集, 用于表示地图上有什么,最后渲染到黑窗上
        public char[,] maps { get { return Maps; } }
        public Map()
        {//Map类的构造函数,用于初始化地图
            Console.Clear();//清屏
            string str1 = null;
            for (int i = 0; i < maps.GetLength(maps.Rank - 2); i++)
            {
                for (int j = 0; j < maps.GetLength(maps.Rank - 1); j++)
                {//两次循环遍历地图
                    maps[i, j] = ' ';//每个格子初始化为空白
                    if (i == 0 || i == maps.GetLength(maps.Rank - 2) - 1 || j == maps.GetLength(maps.Rank - 1) - 1)
                    {//对每个边特殊处理为*符号
                        maps[i, j] = '*';

                    }
                    str1 += maps[i, j];
                }
                str1 += "\n";//\n表示回车,也就是新的一行,考虑到多环境适配,可以使用 System.Environment.NewLine 来表示新的一行
            }
            Console.Write(str1);//将地图输出到屏幕
        }
        public void GG()
        {//游戏结束后,需要渲染结束提示
            Console.SetCursorPosition(Gm.width, Gm.height);//移动光标到右下角
            Console.Write("游戏结束 GameOver");//输出提示
            Console.Write("按→开始下一句");
        }
        public void Redraw(Gm.Point snake, Gm.Point point)  //一次绘图(每帧都会运行)
        {
            if(Gm.GameOver)
            {//游戏结束
                GG();
            }
            Console.SetCursorPosition(snake.X, snake.Y);  //移动光标到蛇头
            Console.Write('@');//绘制蛇头
            if (!Food.eatBool)   //没吃到就擦除蛇尾
            {
                Console.SetCursorPosition(point.X, point.Y);//同样,光标到蛇尾
                Console.Write(' ');//设置为空白
            }
            Console.SetCursorPosition(Gm.width, Gm.height);
        }
    }
}
