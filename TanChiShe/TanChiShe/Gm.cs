using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Gm
    {
        public Gm()
        {//构造函数,创建类时自动调用
            //初始化(构造函数就是用来做初始化的)
            //这里的 Gm.infoString 等同于 this.infoString
            Gm.infoString = "RightArrow";
            Gm.myBreak = "LeftArrow";
            Gm.GameOver = false;
            Gm.width = 50;
            Gm.height = 25;
        }
        public static string infoString = "RightArrow"; //初始朝向为右(之后由用户输入)
        public static string myBreak = "LeftArrow";     //初始反方向，每次按键不允许反向移动(之后由用户输入的反方向决定)
        public static bool GameOver = false;            //GG, 游戏结束

        //地图参照物是小黑窗上的每个可绘制点为1个格子
        public static int width = 50;                   //地图 宽 
        public static int height = 25;                  //地图 高
        public struct Point                             //位置(二位地图需要XY两个轴来表示物体的位置)
        {
           public int X;
           public int Y;
        }

        public enum position                            //方向(键盘 上下左右)
        {
            UpArrow,
            DownArrow,
            LeftArrow,
            RightArrow
        }
        
    }
}
