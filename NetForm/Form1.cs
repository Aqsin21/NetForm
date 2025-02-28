namespace NetForm
{
    public partial class Form1 : Form
    {


        private Button[] filmButtons;
        private Dictionary<Button, Point> originalLocations = new Dictionary<Button, Point>();
        public Form1()
        {
            InitializeComponent();



        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            cmbGenre.Items.Add("All Genres");
            cmbGenre.Items.Add("Action");
            cmbGenre.Items.Add("Comedy");
            cmbGenre.Items.Add("Drama");
            cmbGenre.Items.Add("Horror");
            cmbGenre.Items.Add("Romance");

            cmbGenre.SelectedIndex = 0;

            CreateFilmButtons();
            cmbGenre.SelectedIndexChanged += CmbGenre_SelectedIndexChanged;

        }


        private void CreateFilmButtons()
        {
            string[] filmNames = { "Mad Max", "Hangover", "Titanic", "The Conjuring", "Notebook", "Inception" };
            string[] genres = { "Action", "Comedy", "Drama", "Horror", "Romance", "Sci-Fi" };
            Color[] colors = { Color.Red, Color.Yellow, Color.Blue, Color.Black, Color.Pink, Color.Green };

            filmButtons = new Button[filmNames.Length];

            for (int i = 0; i < filmButtons.Length; i++)
            {
                Button btn = new Button
                {
                    Text = filmNames[i],
                    BackColor = colors[i],
                    ForeColor = Color.White,
                    Location = new Point(20, 60 + (i * 50)),
                    Size = new Size(150, 40),
                    Tag = genres[i]
                };

                filmButtons[i] = btn;
                this.Controls.Add(btn);
                originalLocations[btn] = btn.Location;
            }
        }

        private void CmbGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGenre = cmbGenre.SelectedItem.ToString();
            int yOffset = 60; 

            if (selectedGenre == "All Genres")
            {
                
                foreach (Button btn in filmButtons)
                {
                    btn.Visible = true;
                    btn.Location = originalLocations[btn]; 
                }
            }



            else
            {
                
                foreach (Button btn in filmButtons)
                {
                    if (btn.Tag.ToString() == selectedGenre)
                    {
                        btn.Visible = true;
                        btn.Location = new Point(20, yOffset);
                       
                    }
                    else
                    {
                        btn.Visible = false;
                    }
                }
            }

        }
    }
}


