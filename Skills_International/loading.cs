namespace Skills_International
{
    public partial class loading : Form
    {
        public loading()
        {
            InitializeComponent();
        }

        int startpos = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpos += 1;
            Myprogress.Value = startpos;
            percentage.Text = startpos + "%";
            if(Myprogress.Value == 100)
            {
                Myprogress.Value = 0;
                timer1.Stop();
                login log = new login();
                log.Show();
                this.Hide();
                
            }
        }

        private void loading_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}