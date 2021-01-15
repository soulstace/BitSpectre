using System.Drawing;
using System.Windows.Forms;

namespace BitSpectre
{
    public partial class CLBox : CheckedListBox
    {
        public CLBox()
        {
            InitializeComponent();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Color foreColor = e.ForeColor;
            DrawItemState s2 = e.State;
            if (e.Index >= 0)
                foreColor = GetItemChecked(e.Index) ? Color.DarkTurquoise : Color.WhiteSmoke;

            if ((s2 & DrawItemState.Focus) == DrawItemState.Focus)
                s2 &= ~DrawItemState.NoFocusRect;

            if ((s2 & DrawItemState.Selected) == DrawItemState.Selected)
                s2 &= ~DrawItemState.Selected;

            DrawItemEventArgs e2 = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, s2, foreColor, this.BackColor);
            base.OnDrawItem(e2);
        }
    }
}
