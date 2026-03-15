using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPt
{
    public partial class PhongTro_ : Form
    {
        public PhongTro_()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void frmPhongTro_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(KetNoi.ChuoiKetNoi))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblPhongTro", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPhongTro.DataSource = dt;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(KetNoi.ChuoiKetNoi))
            {
                string sql = @"INSERT INTO tblPhongTro (ToaNha, Tang, SoPhong, GiaPhong, MoTa) 
                           VALUES (@toaNha, @tang, @soPhong, @gia, @moTa)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@toaNha", txtToaNha.Text);
                cmd.Parameters.AddWithValue("@tang", txtTang.Text);
                cmd.Parameters.AddWithValue("@soPhong", txtSoPhong.Text);
                cmd.Parameters.AddWithValue("@gia", txtGiaPhong.Text);
                cmd.Parameters.AddWithValue("@moTa", txtMoTa.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("✅ Thêm phòng thành công!");
                LoadData();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvPhongTro.SelectedRows.Count == 0) return;
            int ma = Convert.ToInt32(dgvPhongTro.SelectedRows[0].Cells["MaPhongTro"].Value);

            using (SqlConnection conn = new SqlConnection(KetNoi.ChuoiKetNoi))
            {
                string sql = @"UPDATE tblPhongTro SET ToaNha = @toaNha, Tang = @tang, SoPhong = @soPhong, GiaPhong = @gia, MoTa = @moTa 
                           WHERE MaPhongTro = @ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@toaNha", txtToaNha.Text);
                cmd.Parameters.AddWithValue("@tang", txtTang.Text);
                cmd.Parameters.AddWithValue("@soPhong", txtSoPhong.Text);
                cmd.Parameters.AddWithValue("@gia", txtGiaPhong.Text);
                cmd.Parameters.AddWithValue("@moTa", txtMoTa.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("✅ Thêm phòng thành công!");
                LoadData();
            }  
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(dgvPhongTro.SelectedRows.Count == 0) return;
            if(MessageBox.Show("Xóa Phòng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int ma = Convert.ToInt32(dgvPhongTro.SelectedRows[0].Cells["MaPhongTro"].Value);
                using (SqlConnection conn = new SqlConnection(KetNoi.ChuoiKetNoi))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblPhongTro WHERE MaPhongTro = @ma", conn);
                    cmd.Parameters.AddWithValue("@ma", ma);
                    conn.Open();cmd.ExecuteNonQuery();
                }
                LoadData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
