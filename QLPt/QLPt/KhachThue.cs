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
    public partial class KhachThue : Form
    {
        public KhachThue()
        {
            InitializeComponent();
        }
        private void KhachThue_Load(object sender, EventArgs e) => LoadData();
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(KetNoi.ChuoiKetNoi))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblKhachThue", conn);
                DataTable dt = new DataTable(); da.Fill(dt);
                dgvKhachThue.DataSource = dt;
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(KetNoi.ChuoiKetNoi))
            {
                string sql = @"INSERT INTO tblKhachThue (MaPhongTro, HoTen, GioiTinh, NgaySinh, QueQuan, SoDienThoai, CCCD)
                               VALUES (@mp, @ht, @gt, @ns, @qq, @sdt, @cccd)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mp", txtMaPhong.Text);
                cmd.Parameters.AddWithValue("@ht", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@gt", cbxGioiTinh.Text);
                cmd.Parameters.AddWithValue("@ns", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@qq", txtQueQuan.Text);
                cmd.Parameters.AddWithValue("@sdt", txtSoDienThoai.Text);
                cmd.Parameters.AddWithValue("@cccd", txtCCCD.Text);

                conn.Open(); cmd.ExecuteNonQuery();
                MessageBox.Show("✅ Thêm khách thuê thành công!");
                LoadData();
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvKhachThue.SelectedRows.Count == 0) return;
            int ma = Convert.ToInt32(dgvKhachThue.SelectedRows[0].Cells["MaKhachThue"].Value);

            using (SqlConnection conn = new SqlConnection(KetNoi.ChuoiKetNoi))
            {
                string sql = @"UPDATE tblKhachThue SET MaPhongTro=@mp, HoTen=@ht, GioiTinh=@gt, 
                               NgaySinh=@ns, QueQuan=@qq, SoDienThoai=@sdt, CCCD=@cccd 
                               WHERE MaKhachThue=@ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", ma);
                cmd.Parameters.AddWithValue("@mp", txtMaPhong.Text);
                cmd.Parameters.AddWithValue("@ht", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@gt", cbxGioiTinh.Text);
                cmd.Parameters.AddWithValue("@ns", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@qq", txtQueQuan.Text);
                cmd.Parameters.AddWithValue("@sdt", txtSoDienThoai.Text);
                cmd.Parameters.AddWithValue("@cccd", txtCCCD.Text);
                conn.Open(); cmd.ExecuteNonQuery();
                MessageBox.Show("✅ Sửa thành công!"); LoadData();
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachThue.SelectedRows.Count == 0) return;
            if (MessageBox.Show("Xóa khách này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int ma = Convert.ToInt32(dgvKhachThue.SelectedRows[0].Cells["MaKhachThue"].Value);
                using (SqlConnection conn = new SqlConnection(KetNoi.ChuoiKetNoi))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblKhachThue WHERE MaKhachThue=@ma", conn);
                    cmd.Parameters.AddWithValue("@ma", ma);
                    conn.Open(); cmd.ExecuteNonQuery();
                }
                LoadData();
            }
        }
        private void txtMaPhong_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvKhachThue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnLamMoi_Click(object sender, EventArgs e) => LoadData();

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData(); 
        }
    }
}
