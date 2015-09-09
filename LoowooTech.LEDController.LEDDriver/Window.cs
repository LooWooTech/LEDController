using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EQ2008_DataStruct;
using System.Configuration;

namespace LoowooTech.LEDController.LEDDriver
{
    public class Window
    {
        static int UniqueIdGenerator = 0;
        
        static object StaticSyncRoot = new object();

        /// <summary>
        /// 唯一编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 液晶屏序号
        /// </summary>
        public int LedIndex { get; set; }

        /// <summary>
        /// 显示范围信息
        /// </summary>
        public User_PartInfo Frame { get; set; }

        /// <summary>
        /// 字体信息
        /// </summary>
        public User_FontSet Font { get; set; }

        /// <summary>
        /// 显示的文字
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 移动方式
        /// </summary>
        public User_MoveSet Movement { get; set; }

        internal static Window CreateWindow(int ledIndex, int x, int y, int height, int width)
        {
            var w = new Window
            {
                LedIndex = ledIndex,
                Frame = new User_PartInfo
                {
                    FrameColor = 0,
                    iFrameMode = 0,
                    iX = x,
                    iY = y,
                    iHeight = height,
                    iWidth = width
                },
                Font = new User_FontSet
                {
                    strFontName = "宋体",
                    colorFont = (int)User_Color.White,
                    iFontSize = 16,
                    iAlignStyle = 1,
                    iVAlignerStyle = 1
                },
                Movement = new User_MoveSet
                {
                    iActionSpeed = int.Parse(ConfigurationManager.AppSettings["AnimationSpeed"]),
                    iActionType = 1,
                    iHoldTime = 20,
                    iClearActionType = 0,
                    iClearSpeed = 4,
                    iFrameTime = 20
                }
            };
            lock(StaticSyncRoot)
            {
                w.Id = UniqueIdGenerator;
                UniqueIdGenerator++;
            }
            return w;
        }
    }
}
