using SchoolManagementSystem.Application;

namespace DesktopUI
{
    public partial class Form1 : Form
    {
        private readonly SchoolService service;
        public Form1(SchoolService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
