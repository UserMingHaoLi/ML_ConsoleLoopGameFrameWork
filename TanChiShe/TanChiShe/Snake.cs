using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    

    class Snake
    {
        public Snake()
        {//蛇的构造函数
            //初始化蛇头的位置为左上角,并额外生成一个蛇身到后面
            Gm.Point p;
            p.X = 2;
            p.Y = 1;
            SnakePoint.Add(p);
            p.X--;
            SnakePoint.Add(p);
            SnakeHaed = SnakePoint[0];
            SnakeBack.X = 0;
            SnakeBack.Y = 0;
        }
        private List<Gm.Point> SnakePoint = new List<Gm.Point>();
        public List<Gm.Point> snakePoint { get { return SnakePoint; }  }//蛇的点位,注意有多个(因为蛇可以同时占据多个格子)

        private Gm.Point SnakeHaed;//蛇头的位置
        public Gm.Point snakeHaed { get { return SnakeHaed; } set { SnakeHaed = value; } }

        private Gm.Point SnakeBack;//蛇尾
        public Gm.Point snakeBack { get { return SnakeBack; } set { SnakeBack = value; } }
        public Gm.Point this[int i]
        {//获取蛇的任意一节的位置
            get
            {
                return snakePoint[i];
            }
          
        }

        public void SnakeLong(string position ,ref string myBreak)
        {//蛇移动

            Gm.Point NewHaed; //= SnakePoint[0];
            //SnakePoint.Add(res);        
            switch (position)
            {//根据玩家按键不同,将蛇头向不同方向移动一格(所以按的越快动的越快...)
                //注意,还设置了禁止按下的键(例如此时按下`UpArrow`也就是上,则返回一个`DownArrow`也就是下,告知外界此按键下次无效)
                case "UpArrow":
                    NewHaed = SnakePoint[0];
                    NewHaed.Y--;
                    SnakePoint.Insert(0, NewHaed);
                    myBreak = "DownArrow";
                    break;
                case "DownArrow":
                    NewHaed = SnakePoint[0];
                    NewHaed.Y++;
                    SnakePoint.Insert(0, NewHaed);
                    myBreak = "UpArrow";
                    break;
                case "LeftArrow":
                    NewHaed = SnakePoint[0];
                    NewHaed.X--;
                    SnakePoint.Insert(0, NewHaed);
                    myBreak = "RightArrow";
                    break;
                case "RightArrow":
                    NewHaed = SnakePoint[0];
                    NewHaed.X++;
                    SnakePoint.Insert(0, NewHaed);
                    myBreak = "LeftArrow";
                    break;
                default:
                    break;
            }
            SnakeHaed = SnakePoint[0];//移动过后的新舌头
            //死亡判断
            if(SnakeHaed.X <=0 || SnakeHaed.X>=Gm.width-1 || SnakeHaed.Y <= 0 || SnakeHaed.Y >= Gm.height-1)
            {//撞墙死亡
                Gm.GameOver = true;
            }
            for(int i = 3; i<snakePoint.Count; i++)
            {//吃自己死亡(无论如何吃不到自己的前三节)
                if(SnakeHaed.X == SnakePoint[i].X && SnakeHaed.Y == SnakePoint[i].Y)
                {
                    Gm.GameOver = true;
                }
            }
            SnakeBack = SnakePoint[SnakePoint.Count - 1];
            if (!Food.eatBool)
            {//没吃到,删除尾巴(迟到了就不删除)
                //注意,这里是数据层,绘制还有看Map的表现层.
                SnakePoint.Remove(SnakePoint[SnakePoint.Count-1]);
            }
            

        }
    }
}
