using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace LoowooTech.LEDController.Client
{
    public class LedPanel:UserControl
    {
        private Bitmap bitmap;
        private Rectangle[] pixels;

        private int width;

        private int height;

        private readonly Brush brush;

        [DllImport("gdi32.dll")]
        public static extern int SetTextCharacterExtra(IntPtr hdc, int nCharExtra);

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LedPanel
            // 
            this.Name = "LedPanel";
            this.Size = new System.Drawing.Size(408, 142);
            this.ResumeLayout(false);
            this.Load += LedPanel_Load;
        }

        private void LedPanel_Load(object sender, EventArgs e)
        {
            CreateBitmap();
            DrawText();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawText();
        }

        public LedPanel(int width, int height)
        {
            brush = new SolidBrush(Color.Red);
            
            this.width = width;
            this.height = height;
            InitializeComponent();
            Text = "测试文字";
        }

        public LedPanel():this(80,32)
        {

        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                if (bitmap == null) CreateBitmap();
                else DrawBitmap();
                DrawText();
            }
        }

        public override System.Drawing.Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                DrawBitmap();
                DrawText();
            }
        }

        private ContentAlignment alignment;

        public ContentAlignment Alignment
        {
            get
            {
                return alignment;
            }
            set
            {
                alignment = value;
                DrawBitmap();
                DrawText();
            }
        }

        private int rowSpace;

        public int RowSpace
        {
            get
            {
                return rowSpace;
            }
            set
            {
                rowSpace = value;
                DrawBitmap();
                DrawText();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            CreateBitmap();
            DrawText();
        }

        /// <summary>
        /// 将文本分行
        /// </summary>
        /// <param name="graphic">绘图图面</param>
        /// <param name="font">字体</param>
        /// <param name="text">文本</param>
        /// <param name="width">行宽</param>
        /// <returns></returns>
        private static List<string> GetStringRows(Graphics graphic, Font font, string text, int width)
        {

            int RowBeginIndex = 0;
            int rowEndIndex = 0;
            int textLength = text.Length;
            List<string> textRows = new List<string>();

            for (int index = 0; index < textLength; index++)
            {
                rowEndIndex = index;
                if (index == textLength - 1)
                {
                    textRows.Add(text.Substring(RowBeginIndex));
                }

                else if (rowEndIndex + 1 < text.Length && text.Substring(rowEndIndex, 2) == "\r\n")
                {
                    textRows.Add(text.Substring(RowBeginIndex, rowEndIndex - RowBeginIndex));
                    rowEndIndex = index += 2;
                    RowBeginIndex = rowEndIndex;
                }

                else if (graphic.MeasureString(text.Substring(RowBeginIndex, rowEndIndex - RowBeginIndex + 1), font).Width > width)
                {
                    textRows.Add(text.Substring(RowBeginIndex, rowEndIndex - RowBeginIndex));
                    RowBeginIndex = rowEndIndex;
                }
            }
            return textRows;
        }

        /// <summary>
        /// 绘制文本自动换行（超出截断）
        /// </summary>
        /// <param name="graphic">绘图图面</param>
        /// <param name="font">字体</param>
        /// <param name="text">文本</param>
        /// <param name="recangle">绘制范围</param>
        private static void DrawStringWrap(Graphics graphic, Font font, string text, StringAlignment alignment, StringAlignment verticalAlignment, Rectangle recangle)
        {

            List<string> textRows = GetStringRows(graphic, font, text, recangle.Width);
            int rowHeight = (int)(Math.Ceiling(graphic.MeasureString("测试", font).Height));
            int maxRowCount = recangle.Height / rowHeight;
            int drawRowCount = (maxRowCount < textRows.Count) ? maxRowCount : textRows.Count;

            int top = verticalAlignment== StringAlignment.Center? (recangle.Height - rowHeight * drawRowCount) / 2:
                (verticalAlignment == StringAlignment.Near?0:(recangle.Height - rowHeight * drawRowCount));
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = alignment;
            for (int i = 0; i < drawRowCount; i++)
            {
                Rectangle fontRectanle = new Rectangle(recangle.Left, top + rowHeight * i, recangle.Width, rowHeight*2);
                graphic.DrawString(textRows[i], font, new SolidBrush(Color.Black), fontRectanle, sf);
            }
        }


        private void DrawStringWrap2(Graphics g, int lineDistance,StringAlignment alignment, StringAlignment verticalAlignment)
        {
            try
            {
                String drawString = this.Text;
                Font drawFont = this.Font;
                SolidBrush drawBrush = new SolidBrush(Color.Red);
                SizeF textSize = g.MeasureString(this.Text, this.Font);//文本的矩形区域大小     
                int lineCount = Convert.ToInt16(Math.Floor(textSize.Width / this.width)) + 1;//计算行数     

                var maxLine = Convert.ToInt32(this.height / textSize.Height);
                maxLine = maxLine < lineCount?maxLine:lineCount;
                var top = (this.height - textSize.Height * maxLine);
                top = verticalAlignment== StringAlignment.Center? top / 2:
                    (verticalAlignment == StringAlignment.Near?0:top);
                
                float x = 0.0F;
                var drawFormat = new StringFormat();
                int step = 1;
                lineCount = drawString.Length;//行数不超过总字符数目     
                for (int i = 0; i < maxLine; i++)
                {
                    //计算每行容纳的字符数目     
                    int charCount;
                    for (charCount = 0; charCount < drawString.Length; charCount++)
                    {
                        string subN = drawString.Substring(0, charCount);
                        string subN1 = drawString.Substring(0, charCount + 1);
                        if (g.MeasureString(subN, this.Font).Width <= this.width
                                && g.MeasureString(subN1, this.Font).Width > this.width)
                        {
                            step = charCount;
                            break;
                        }
                    }
                    string subStr;
                    if (charCount == drawString.Length)//最后一行文本     
                    {
                        subStr = drawString;
                        var w = this.width - g.MeasureString(subStr, this.Font).Width;
                        x = alignment == StringAlignment.Center ? w / 2 :
                            (alignment == StringAlignment.Near ? 0 : w);
                        g.DrawString(subStr, drawFont, drawBrush, x, top+Convert.ToInt16(textSize.Height * i) + i * lineDistance, drawFormat);
                        break;
                    }
                    else
                    {
                        subStr = drawString.Substring(0, step);//当前行文本     
                        drawString = drawString.Substring(step);//剩余文本  
                        var w = this.width - g.MeasureString(subStr, this.Font).Width;
                        x = alignment == StringAlignment.Center ? w / 2 :
                            (alignment == StringAlignment.Near ? 0 : w);

                        g.DrawString(subStr, drawFont, drawBrush, x, top+Convert.ToInt16(textSize.Height * i) + i * lineDistance, drawFormat);
                    }
                }
            }
            catch
            { }
        }

        private void DrawBitmap()
        {
            if (bitmap == null) return;
            using (var g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Black);
                var f = new StringFormat();
                switch (Alignment)
                {
                    case ContentAlignment.TopLeft:
                        f.Alignment = StringAlignment.Near;
                        f.LineAlignment = StringAlignment.Near;
                        break;
                    case ContentAlignment.TopCenter:
                        f.Alignment = StringAlignment.Center;
                        f.LineAlignment = StringAlignment.Near;
                        break;
                    case ContentAlignment.TopRight:
                        f.Alignment = StringAlignment.Far;
                        f.LineAlignment = StringAlignment.Near;
                        break;
                    case ContentAlignment.MiddleLeft:
                        f.Alignment = StringAlignment.Near;
                        f.LineAlignment = StringAlignment.Center;
                        break;
                    case ContentAlignment.MiddleCenter:
                        f.Alignment = StringAlignment.Center;
                        f.LineAlignment = StringAlignment.Center;
                        break;
                    case ContentAlignment.MiddleRight:
                        f.Alignment = StringAlignment.Far;
                        f.LineAlignment = StringAlignment.Center;
                        break;
                    case ContentAlignment.BottomLeft:
                        f.Alignment = StringAlignment.Near;
                        f.LineAlignment = StringAlignment.Far;
                        break;
                    case ContentAlignment.BottomCenter:
                        f.Alignment = StringAlignment.Center;
                        f.LineAlignment = StringAlignment.Far;
                        break;
                    case ContentAlignment.BottomRight:
                        f.Alignment = StringAlignment.Far;
                        f.LineAlignment = StringAlignment.Far;
                        break;
                }
                
                //var font = new Font("宋体", (float)9.5);
                //DrawStringWrap(g, font, this.Text, f.Alignment, f.LineAlignment, new Rectangle { X = 0, Y = 0, Height = bitmap.Height, Width = bitmap.Width });
                //g.DrawString(this.Text, font, brush, new RectangleF { X = 0, Y = 0, Height = bitmap.Height, Width = bitmap.Width }, f);
                DrawStringWrap2(g, rowSpace, f.Alignment, f.LineAlignment);
            }


            var ratio1 = this.Width / bitmap.Width;
            var ratio2 = this.Height / bitmap.Height;
            var ratio = ratio1 < ratio2 ? ratio1 : ratio2;
            var marginX = (this.Width - bitmap.Width * ratio) / 2;
            var marginY = (this.Height - bitmap.Height * ratio) / 2;

            var list = new List<Rectangle>();

            for (var y = 0; y < bitmap.Height; y++)
            {
                for (var x = 0; x < bitmap.Width; x++)
                {
                    if (bitmap.GetPixel(x, y).R > 0)
                    {
                        
                        list.Add(new Rectangle
                        {
                            X = marginX + x * ratio - ratio / 2,
                            Y = marginY + y * ratio - ratio / 2,
                            Width = ratio - 1,
                            Height = ratio - 1
                        });
                    }
                }
            }

            pixels = list.ToArray();
        }

        private void CreateBitmap()
        {
            if (bitmap != null) bitmap.Dispose();
            bitmap = new Bitmap(width, height);
            DrawBitmap();
        }

        private void DrawText()
        {
            if (pixels == null || pixels.Length == 0) return;
            
            using(var g = this.CreateGraphics())
            {
                g.Clear(this.BackColor);
                var ratio1 = this.Width / bitmap.Width;
                var ratio2 = this.Height / bitmap.Height;
                var ratio = ratio1 < ratio2 ? ratio1 : ratio2;
                var marginX = (this.Width - bitmap.Width * ratio) / 2;
                var marginY = (this.Height - bitmap.Height * ratio) / 2;

                g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(marginX-ratio, marginY-ratio, this.Width - marginX*2, this.Height - marginY*2));
                g.FillRectangles(brush, pixels);
                //g.DrawImage(bitmap, new Point { X = 0, Y = 0 });
            }
        }
    }
}
