using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PENJUALAN_SEPATU
{
    public partial class Form1 : Form
    {
        private string ConnectionString = "Server=localhost;port=3306;database=sistempenjualansepatu;Uid=root;Pwd=;";

        public Form1()
        {
            InitializeComponent();
            LoadData(); // Load data saat form dibuka
        }

        private void LoadData()
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM sepatu";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewBarang.DataSource = table;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) // Tambah Barang
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "INSERT INTO sepatu (nama_sepatu, ukuran, harga, jumlah) VALUES (@NamaSepatu, @Ukuran, @Harga, @Jumlah)";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@NamaSepatu", txtEditNamaSepatu.Text);
                    cmd.Parameters.AddWithValue("@Ukuran", nudEditUkuran.Value);
                    cmd.Parameters.AddWithValue("@Harga", Harga.Text);
                    cmd.Parameters.AddWithValue("@Jumlah", jumlah.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e) // Edit Barang
        {
            if (dataGridViewBarang.SelectedRows.Count > 0)
            {
                int selectedID = Convert.ToInt32(dataGridViewBarang.SelectedRows[0].Cells["ID"].Value);
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "UPDATE sepatu SET nama_sepatu = @NamaSepatu, ukuran = @Ukuran, harga = @Harga, jumlah = @Jumlah WHERE ID = @ID";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@NamaSepatu", txtEditNamaSepatu.Text);
                        cmd.Parameters.AddWithValue("@Ukuran", nudEditUkuran.Value);
                        cmd.Parameters.AddWithValue("@Harga", Harga.Text);
                        cmd.Parameters.AddWithValue("@Jumlah", jumlah.Text);
                        cmd.Parameters.AddWithValue("@ID", selectedID);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadData();
            }
            else
            {
                MessageBox.Show("Pilih barang yang ingin diubah.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e) // Hapus Barang
        {
            if (dataGridViewBarang.SelectedRows.Count > 0)
            {
                int selectedID = Convert.ToInt32(dataGridViewBarang.SelectedRows[0].Cells["ID"].Value);
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM sepatu WHERE ID = @ID";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", selectedID);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadData();
            }
            else
            {
                MessageBox.Show("Pilih barang yang ingin dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button5_Click(object sender, EventArgs e) // Bayar
        {
            if (dataGridViewBarang.SelectedRows.Count > 0)
            {
                int selectedID = Convert.ToInt32(dataGridViewBarang.SelectedRows[0].Cells["ID"].Value);
                int jumlahBeli = Convert.ToInt32(JumlahBeli.Text);

                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "UPDATE sepatu SET jumlah = jumlah - @JumlahBeli WHERE ID = @ID AND jumlah >= @JumlahBeli";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@JumlahBeli", jumlahBeli);
                        cmd.Parameters.AddWithValue("@ID", selectedID);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Pembayaran berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Stok tidak cukup!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                LoadData();
            }
        }

        private void txtEditNamaSepatu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
