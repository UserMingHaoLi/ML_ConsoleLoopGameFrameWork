using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Food
    {
        public Food() 
        {//食物的构造函数
            //初始化一个食物到正中央(此时是第一个食物)
            Food.eatBool = false;
            FoodPoint.X = Gm.width/2;
            FoodPoint.Y = Gm.height/2;
            SpawnFood();
        }
        private Random foodRandom = new Random();//随机数生成器,用于生成食物位置
        private Gm.Point FoodPoint;//保存食物位置
        public Gm.Point foodPoint { get { return FoodPoint; }  }
        public static bool eatBool = false;           //是否吃到食物
        public void EatFood(Gm.Point snakeHaed)    
        {//尝试由蛇来吃食物
            if(eatBool)
            {
                eatBool = false;
            }
            if(snakeHaed.X == FoodPoint.X && snakeHaed.Y == FoodPoint.Y)
            {//蛇头和食物是否重叠
                eatBool = true;//被吃了
               // RemoveFood();
                RandomFood();//随机一个新的食物
                SpawnFood();//显示新的食物
            }    
        }
        void RandomFood()   //随机食物位置(在地图上)
        {
            FoodPoint.X = foodRandom.Next(1, Gm.width);
            FoodPoint.Y = foodRandom.Next(1, Gm.height);
        }
        void SpawnFood()    //显示食物
        {
            Console.SetCursorPosition(FoodPoint.X, FoodPoint.Y);
            Console.Write('#');
        }
        void RemoveFood()   //消除食物 //不必消除，蛇会覆盖食物
        {
            Console.SetCursorPosition(FoodPoint.X,FoodPoint.Y);
            Console.Write(' ');
        }
    }
}
