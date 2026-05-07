using System;
using System.ComponentModel;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace SharpAlert.WinFormsControls
{
    public static class ToolboxStuff
    {
        public class MarqueeLabel : Label
        {
            private readonly System.Timers.Timer scrollTimer;
            private float textPosition = 0;

            [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
            public float ScrollSpeed { get; set; } = 1.5f;
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
            public double ScrollInterval { get; set; } = 16;

            public MarqueeLabel()
            {
                scrollTimer = new System.Timers.Timer()
                {
                    Interval = ScrollInterval
                };
                scrollTimer.Elapsed += new ElapsedEventHandler(OnScrollTick);
            }

            private bool Started = false;

            private SolidBrush sb = new(Color.Black);

            private SizeF PreviousTextSize = new();
            private string PreviousText = "";

            protected override void OnPaint(PaintEventArgs e)
            {
                if (!Started)
                {
                    textPosition = Width;
                    Started = true;
                    return;
                }

                if (Text.Length == 0) return;

                //float localTextPosition = textPosition;
                //if (UseCustomPixelCount) localTextPosition += PixelCount;

                if (PreviousText != Text)
                {
                    PreviousTextSize = e.Graphics.MeasureString(Text, Font);
                    PreviousText = Text;
                }

                RectangleF textRect;

                switch (base.TextAlign)
                {
                    case ContentAlignment.TopLeft:
                        textRect = new RectangleF((ScrollSpeed == 0) ? 0 : textPosition, 0, PreviousTextSize.Width, this.Height);
                        e.Graphics.DrawString(this.Text, this.Font, sb, textRect);
                        break;
                    case ContentAlignment.MiddleLeft:
                        textRect = new RectangleF((ScrollSpeed == 0) ? 0 : textPosition, (this.Height - PreviousTextSize.Height) / 2, PreviousTextSize.Width, this.Height);
                        e.Graphics.DrawString(this.Text, this.Font, sb, textRect);
                        break;
                    case ContentAlignment.BottomLeft:
                        textRect = new RectangleF((ScrollSpeed == 0) ? 0 : textPosition, this.Height - PreviousTextSize.Height, PreviousTextSize.Width, this.Height);
                        e.Graphics.DrawString(this.Text, this.Font, sb, textRect);
                        break;
                    default:
                        textRect = new RectangleF((ScrollSpeed == 0) ? 0 : textPosition, 0, PreviousTextSize.Width, this.Height);
                        e.Graphics.DrawString(this.Text, this.Font, sb, textRect);
                        break;
                }

                if (ScrollSpeed >= 0)
                {
                    if (textPosition < -PreviousTextSize.Width)
                    {
                        // TODO
                        // Raise event here when the scroll finishes
                        textPosition = this.Width;
                    }
                }
                else
                {
                    if (textPosition > this.Width)
                    {
                        // TODO
                        // Raise event here when the scroll finishes
                        textPosition = -PreviousTextSize.Width;
                    }
                }
            }

            protected override void OnForeColorChanged(EventArgs e)
            {
                base.OnForeColorChanged(e);
                sb?.Dispose();
                sb = new(ForeColor);
            }

            [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
            public new string Text
            {
                get
                {
                    return base.Text;
                }
                set
                {
                    SetText(value);
                }
            }

            public void SetText(string text)
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(() => SetText(text));
                    return;
                }

                if (text.Length == base.Text.Length)
                {
                    base.Text = text;
                }
                else
                {
                    base.Text = text;
                    Started = false;
                    this.Invalidate();
                }
            }

            protected override void OnTextChanged(EventArgs e)
            {
                base.OnTextChanged(e);
                //Started = false;
                //this.Invalidate();
                //base.OnTextChanged(e);
            }

            protected override void OnSizeChanged(EventArgs e)
            {
                Started = false;
                Invalidate();
                base.OnSizeChanged(e);
            }

            protected override void OnHandleCreated(EventArgs e)
            {
                base.OnHandleCreated(e);
                scrollTimer.Start();
            }

            private void OnScrollTick(object sender, ElapsedEventArgs e)
            {
                if (DesignMode) return;
                textPosition -= ScrollSpeed;
                if (!IsDisposed) if (Visible && Width > 0) BeginInvoke(Invalidate);
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (scrollTimer != null)
                    {
                        scrollTimer.Stop();
                        scrollTimer.Dispose();
                    }

                    sb?.Dispose();
                }

                base.Dispose(disposing);
            }
        }

        public class BorderPanel : Panel
        {
            private Color _BorderColor = Color.Black;

            [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
            public Color BorderColor
            {
                get
                {
                    return _BorderColor;
                }
                set
                {
                    _BorderColor = value;
                    this.Invalidate();
                }
            }

            [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
            public int BorderThickness { get; set; } = 2;

            public BorderPanel()
            {
                // Redraw when resized or repainted
                this.DoubleBuffered = true;
                this.ResizeRedraw = true;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                using var pen = new Pen(_BorderColor, BorderThickness);
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Outset;
                int offset = BorderThickness / 2;
                var rect = new Rectangle(
                    offset,
                    offset,
                    this.Width - BorderThickness,
                    this.Height - BorderThickness);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
    }
}

