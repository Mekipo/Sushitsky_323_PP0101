using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Sklad ///
{
    public partial class Login : Form
    {
        private readonly string apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImlpdWFvc2Fpc25scXZ5ZXVqeHJyIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NTA0MjQ3OTYsImV4cCI6MjA2NjAwMDc5Nn0.aFPermi8EI6bfc523D9Dwu6pP9SXbbtkAWMp9MJOJfk";

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("apikey", apiKey);

                var payload = new
                {
                    email = email,
                    password = password
                };

                var json = JsonSerializer.Serialize(payload);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://iiuaosaisnlqvyeujxrr.supabase.co/auth/v1/token?grant_type=password", content);

                if (response.IsSuccessStatusCode)
                {
                    this.Hide(); 

                    var mainForm = new Form1();
                    mainForm.ShowDialog(); 

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                }
            }
        }
    }
}
