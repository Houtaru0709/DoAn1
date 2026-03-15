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
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(KetNoi.ChuoiKetNoi))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblHoaDon", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvHoaDon.DataSource = dt;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(KetNoi.ChuoiKetNoi))
            {
                string sql = @"INSERT INTO tblHoaDon 
                               (MaPhongTro, ThangNam, TienSinhHoat, Internet, DichVuKhac, ChuyenKhoan, GhiChu) 
                               VALUES (@mp, @thangnam, @sinhhoat, @internet, @dvkhac, @ck, @ghichu)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mp", txtMaPhongTro.Text.Trim());
                cmd.Parameters.AddWithValue("@thangnam", txt.Text.Trim());
                cmd.Parameters.AddWithValue("@sinhhoat", decimal.Parse(txtTienSinhHoat.Text));
                cmd.Parameters.AddWithValue("@internet", decimal.Parse(txtInternet.Text));
                cmd.Parameters.AddWithValue("@dvkhac", decimal.Parse(txtDichVuKhac.Text));
                cmd.Parameters.AddWithValue("@ck", txtChuyenKhoan.Text.Trim());
                cmd.Parameters.AddWithValue("@ghichu", txtGhiChu.Text.Trim());
                cmd.Parameters.AddWithValue("@tt", txtTrangThai.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm hóa đơn thành công!");
            }
            LoadData();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void HoaDon_Load(object sender, EventArgs e)
        {

        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void txtThangNam_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(KetNoi.ChuoiKetNoi))
            {
                string sql = @"UPDATE tblHoaDon SET 
                       MaPhongTro=@mp, ThangNam=@thangnam, TienSinhHoat=@sinhhoat, Internet=@internet, 
                       DichVuKhac=@dvkhac, ChuyenKhoan=@ck, GhiChu=@ghichu, TrangThai=@tt
                       WHERE MaHoaDon=@mahd";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mahd", txtMaHoaDon.Text.Trim());
                // các parameter khác giống phần thêm
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa hóa đơn thành công!");
            }
            LoadData();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(KetNoi.ChuoiKetNoi))
            {
                string sql = "DELETE FROM tblHoaDon WHERE MaHoaDon=@mahd";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mahd", txtMaHoaDon.Text.Trim());
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa hóa đơn thành công!");
            }
            LoadData();
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Close();
            f.Show();
        }
    }
}
