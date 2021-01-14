using System.Windows.Forms;

namespace BitSpectre
{
    public partial class TPanel : Panel
    {
        public TPanel()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
            //Don't paint the background
        }
    }
}
