using System.Data;
using System.Xml.Linq;
using Npgsql;
namespace ResponsiJuniorProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private NpgsqlConnection conn;
        string connstring = "Host=localhost;Port=5432;Username=postgres;Password=informatika;Database=RsponsiAthaya";

        public DataTable dt;
        public static NpgsqlCommand cmd;
        private string sql = null;
        private DataGridViewRow r;

        private void EstablishConn(string connstring)
        {
            this.connstring = connstring;
            conn = new NpgsqlConnection(connstring);
        }
        private void EstablishConn()
        {
            MessageBox.Show("Connection to PostGre is underway", "Good", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            EstablishConn();
            EstablishConn(connstring);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                dgvKaryawan.DataSource = null;
                sql = "select * from select_all()";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                NpgsqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                dgvKaryawan.DataSource = dt;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "FAIL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                // Ambil ID departemen berdasarkan nama departemen yang dipilih di ComboBox
                int idDepartemen = GetIdDepartemen(cbDepartemen.Text);

                // Pastikan bahwa idDepartemen valid (lebih baik ada pengecekan jika tidak ditemukan ID)
                if (idDepartemen == -1)
                {
                    MessageBox.Show("Departemen tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Menggunakan parameter yang benar, kirim nama dan id_dep
                sql = @"SELECT * FROM insert_data(:_nama, :_id_dep)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_nama", txtName.Text);
                cmd.Parameters.AddWithValue("_id_dep", idDepartemen);  // Mengirimkan ID departemen yang valid

                // Mengeksekusi perintah dan memeriksa apakah berhasil
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Data Karyawan Berhasil Diinputkan", "Well Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLoad.PerformClick();  // Memuat ulang data
                    txtName.Clear();
                    cbDepartemen.SelectedIndex = -1;  // Reset ComboBox
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Insert FAIL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
        private int GetIdDepartemen(string departemenName)
        {
            // Cari ID departemen berdasarkan nama
            string sql = "SELECT id_dep FROM departemen WHERE nama_dep = @nama_dep";
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@nama_dep", departemenName);

                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result);  // Kembalikan ID departemen
                }
                else
                {
                    return -1;  // Jika tidak ditemukan, return -1 (error)
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Pastikan ada baris yang dipilih
            if (r == null)
            {
                MessageBox.Show("Pilih baris data dahulu!", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                conn.Open();

                // Ambil ID departemen berdasarkan nama departemen yang dipilih di ComboBox
                int idDepartemen = GetIdDepartemnn(cbDepartemen.Text);

                // Pastikan bahwa idDepartemen valid
                if (idDepartemen == -1)
                {
                    MessageBox.Show("Departemen tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ambil ID karyawan yang akan diupdate
                int idKaryawan = Convert.ToInt32(r.Cells["id_karyawan"].Value);  // ID Karyawan yang dipilih dari grid
                string nama = txtName.Text;  // Nama dari TextBox

                // Debug: Menampilkan nilai yang diambil untuk memastikan nilai tidak kosong
                Console.WriteLine($"ID Karyawan: {idKaryawan}");
                Console.WriteLine($"Nama: {nama}");
                Console.WriteLine($"ID Departemen: {idDepartemen}");

                // Cek apakah data yang ingin diupdate berbeda dengan data yang ada di database
                string sqlCheck = "SELECT COUNT(*) FROM karyawan WHERE id_karyawan = @id_karyawan AND nama = @nama AND id_dep = @id_dep";
                using (var cmdCheck = new NpgsqlCommand(sqlCheck, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@id_karyawan", idKaryawan);
                    cmdCheck.Parameters.AddWithValue("@nama", nama);
                    cmdCheck.Parameters.AddWithValue("@id_dep", idDepartemen);

                    var resultCheck = cmdCheck.ExecuteScalar();
                    if (Convert.ToInt32(resultCheck) > 0)
                    {
                        // Jika data yang ingin diupdate sama dengan yang sudah ada, tampilkan pesan bahwa tidak ada perubahan
                        MessageBox.Show("Data tidak berubah, tidak ada perubahan yang dilakukan.", "Update Gagal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                // Query untuk memanggil fungsi PostgreSQL untuk update
                sql = @"SELECT * FROM update_data(:_id_karyawan, :_nama, :_id_dep)";
                cmd = new NpgsqlCommand(sql, conn);

                // Menambahkan parameter dengan tipe data yang benar
                cmd.Parameters.AddWithValue("_id_karyawan", idKaryawan); // INTEGER
                cmd.Parameters.AddWithValue("_nama", nama); // VARCHAR
                cmd.Parameters.AddWithValue("_id_dep", idDepartemen); // INTEGER

                // Eksekusi perintah dan cek hasil
                int result = cmd.ExecuteNonQuery(); // Menggunakan ExecuteNonQuery() karena UPDATE tidak mengembalikan nilai tunggal

                // Jika ada baris yang terpengaruh, berarti update berhasil

                MessageBox.Show("Data Karyawan Berhasil Diupdate", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh data
                btnLoad.PerformClick(); // Memuat ulang data setelah update

                // Reset form setelah update
                txtName.Clear();
                cbDepartemen.SelectedIndex = -1;  // Reset ComboBox
                r = null;

            }
            catch (Exception ex)
            {
                // Tangani kesalahan yang terjadi
                MessageBox.Show("Error: " + ex.Message, "Update Gagal!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close(); // Menutup koneksi
            }

        }
        private int GetIdDepartemnn(string departemenName)
        {
            // Cari ID departemen berdasarkan nama
            string sql = "SELECT id_dep FROM departemen WHERE nama_dep = @nama_dep";
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@nama_dep", departemenName);

                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result);  // Kembalikan ID departemen
                }
                else
                {
                    return -1;  // Jika tidak ditemukan, return -1 (error)
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Pilih baris data dahulu!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Apakah Anda ingin menghapus data " + r.Cells["nama"].Value.ToString() + " ?",
                                "Hapus data terkonfirmasi", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    // Query SQL untuk menghapus data
                    sql = @"select * from delete_by_id(:id_karyawan)";
                    cmd = new NpgsqlCommand(sql, conn);

                    // Menggunakan parameter yang sesuai dengan tipe data
                    cmd.Parameters.AddWithValue("id_karyawan", Convert.ToInt32(r.Cells["id_karyawan"].Value));

                    // Mengeksekusi perintah dan memeriksa hasilnya
                    if ((int)cmd.ExecuteScalar() == 1)
                    {
                        MessageBox.Show("Data Karyawan Berhasil Dihapus", "Well Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLoad.PerformClick();
                        txtName.Text = cbDepartemen.Text = null;
                        r = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Delete FAIL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();  // Menutup koneksi dengan baik
                }
            }
        }

        private void dgvKaryawan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvKaryawan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvKaryawan.Rows[e.RowIndex];
                txtName.Text = r.Cells["nama"].Value.ToString();
                cbDepartemen.Text = r.Cells["id_dep"].Value.ToString();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
