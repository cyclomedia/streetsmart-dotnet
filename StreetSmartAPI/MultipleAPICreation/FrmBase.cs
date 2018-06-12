using System.Windows.Forms;

namespace MultipleAPICreation
{
  public partial class FrmBase : Form
  {
    public FrmBase()
    {
      InitializeComponent();
    }

    private void btnOpenNewWindow_Click(object sender, System.EventArgs e)
    {
      MultipleDemo multipleDemo = new MultipleDemo();
      multipleDemo.Show(this);
    }
  }
}
