using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Sklad
{
    public partial class Form1 : Form
    {
        private readonly string supabaseUrl = "https://iiuaosaisnlqvyeujxrr.supabase.co/rest/v1/products";
        private readonly string apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImlpdWFvc2Fpc25scXZ5ZXVqeHJyIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NTA0MjQ3OTYsImV4cCI6MjA2NjAwMDc5Nn0.aFPermi8EI6bfc523D9Dwu6pP9SXbbtkAWMp9MJOJfk";

        private List<Product> products = new List<Product>();
        private bool _initialLoad = true;

        public Form1()
        {
            InitializeComponent();

            panelAddProduct.Visible = false;

            dataGridViewProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProducts.MultiSelect = false;
            dataGridViewProducts.AutoGenerateColumns = false;

            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id", Visible = false });
            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Название", DataPropertyName = "Name" });
            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Количество", DataPropertyName = "Quantity" });
            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Критический уровень", DataPropertyName = "CriticalLevel" });

            Load += async (s, e) => await LoadProductsAsync();

            checkBoxShowCritical.CheckedChanged += CheckBoxShowCritical_CheckedChanged;
            buttonAdd.Click += buttonAdd_Click;
            buttonConfirmAdd.Click += buttonConfirmAdd_Click;
            buttonCancelAdd.Click += buttonCancelAdd_Click;
            buttonUpdate.Click += async (s, e) => await UpdateProductAsync();
            buttonDelete.Click += async (s, e) => await DeleteProductAsync();
            buttonExportExcel.Click += buttonExportExcel_Click;

            dataGridViewProducts.SelectionChanged += DataGridViewProducts_SelectionChanged;
        }

        private bool ValidateProductInput(string name, string quantityStr, string criticalLevelStr, out int quantity, out int criticalLevel)
        {
            quantity = 0;
            criticalLevel = 0;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Введите название товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(quantityStr, out quantity))
            {
                MessageBox.Show("Введите корректное количество (целое число)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (quantity < 0)
            {
                MessageBox.Show("Количество не может быть отрицательным", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(criticalLevelStr, out criticalLevel))
            {
                MessageBox.Show("Введите корректный критический уровень (целое число)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (criticalLevel < 0)
            {
                MessageBox.Show("Критический уровень не может быть отрицательным", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            panelAddProduct.Visible = true;
            textBoxAddName.Clear();
            textBoxAddQuantity.Clear();
            textBoxAddCriticalLevel.Clear();
        }

        private async void buttonConfirmAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateProductInput(textBoxAddName.Text, textBoxAddQuantity.Text, textBoxAddCriticalLevel.Text,
                    out int quantity, out int criticalLevel))
                {
                    return;
                }

                var newProduct = new Product
                {
                    Name = textBoxAddName.Text.Trim(),
                    Quantity = quantity,
                    CriticalLevel = criticalLevel
                };

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("apikey", apiKey);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                    var json = JsonSerializer.Serialize(newProduct);
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(supabaseUrl, content);
                    response.EnsureSuccessStatusCode();
                }

                await LoadProductsAsync();

                MessageBox.Show($"Товар \"{newProduct.Name}\" добавлен в таблицу!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panelAddProduct.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelAdd_Click(object sender, EventArgs e)
        {
            panelAddProduct.Visible = false;
        }

        private async Task LoadProductsAsync()
        {
            try
            {
                products = await GetProductsAsync();

                dataGridViewProducts.DataSource = null;
                dataGridViewProducts.DataSource = products;

                HighlightLowStockRows();

                if (_initialLoad)
                {
                    ShowLowStockAlert();
                    _initialLoad = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки товаров: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowLowStockAlert()
        {
            var lowStockProducts = products.FindAll(p => p.Quantity <= p.CriticalLevel);
            if (lowStockProducts.Count > 0)
            {
                string message = "Внимание! У следующих товаров низкий уровень:\n" +
                                 string.Join("\n", lowStockProducts.ConvertAll(p => $"- {p.Name} ({p.Quantity})"));
                MessageBox.Show(message, "Низкий остаток", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HighlightLowStockRows()
        {
            foreach (DataGridViewRow row in dataGridViewProducts.Rows)
            {
                var product = row.DataBoundItem as Product;
                if (product != null && product.Quantity <= product.CriticalLevel)
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void DataGridViewProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 0) return;

            var p = dataGridViewProducts.SelectedRows[0].DataBoundItem as Product;
            if (p == null) return;

            textBoxName.Text = p.Name;
            textBoxQuantity.Text = p.Quantity.ToString();
            textBoxCriticalLevel.Text = p.CriticalLevel.ToString();
        }

        private async Task<List<Product>> GetProductsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("apikey", apiKey);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                var response = await client.GetAsync(supabaseUrl + "?select=*");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
        }

        private async Task UpdateProductAsync()
        {
            if (dataGridViewProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар для обновления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var p = dataGridViewProducts.SelectedRows[0].DataBoundItem as Product;
            if (p == null) return;

            try
            {
                if (!ValidateProductInput(textBoxName.Text, textBoxQuantity.Text, textBoxCriticalLevel.Text,
                    out int quantity, out int criticalLevel))
                {
                    return;
                }

                var updatedProduct = new Product
                {
                    Name = textBoxName.Text.Trim(),
                    Quantity = quantity,
                    CriticalLevel = criticalLevel
                };

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("apikey", apiKey);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                    client.DefaultRequestHeaders.Add("Prefer", "return=representation");

                    var json = JsonSerializer.Serialize(updatedProduct);
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var method = new HttpMethod("PATCH");
                    var request = new HttpRequestMessage(method, $"{supabaseUrl}?id=eq.{p.Id}") { Content = content };

                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                }

                await LoadProductsAsync();
                MessageBox.Show($"Товар \"{updatedProduct.Name}\" успешно обновлён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DeleteProductAsync()
        {
            if (dataGridViewProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var p = dataGridViewProducts.SelectedRows[0].DataBoundItem as Product;
            if (p == null) return;

            if (MessageBox.Show($"Удалить товар \"{p.Name}\"?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("apikey", apiKey);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                    var response = await client.DeleteAsync($"{supabaseUrl}?id=eq.{p.Id}");
                    response.EnsureSuccessStatusCode();
                }

                await LoadProductsAsync();
                MessageBox.Show($"Товар \"{p.Name}\" удалён из таблицы!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            textBoxName.Clear();
            textBoxQuantity.Clear();
            textBoxCriticalLevel.Clear();
        }

        private void CheckBoxShowCritical_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowCritical.Checked)
            {
                var lowStockProducts = products.FindAll(p => p.Quantity <= p.CriticalLevel);
                dataGridViewProducts.DataSource = null;
                dataGridViewProducts.DataSource = lowStockProducts;
            }
            else
            {
                dataGridViewProducts.DataSource = null;
                dataGridViewProducts.DataSource = products;
            }

            HighlightLowStockRows();
        }

        private void buttonExportExcel_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new ClosedXML.Excel.XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Products");

                        worksheet.Cell(1, 1).Value = "Название";
                        worksheet.Cell(1, 2).Value = "Количество";
                        worksheet.Cell(1, 3).Value = "Критический уровень";

                        var currentData = (List<Product>)dataGridViewProducts.DataSource;

                        for (int i = 0; i < currentData.Count; i++)
                        {
                            worksheet.Cell(i + 2, 1).Value = currentData[i].Name;
                            worksheet.Cell(i + 2, 2).Value = currentData[i].Quantity;
                            worksheet.Cell(i + 2, 3).Value = currentData[i].CriticalLevel;
                        }

                        workbook.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Экспорт завершён!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }

    public class Product
    {
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("critical_level")]
        public int CriticalLevel { get; set; }
    }
}