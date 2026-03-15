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
    public partial class HopDong : Form
    {
        public HopDong()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(KetNoi.ChuoiKetNoi))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblHopDong", conn);
                DataTable dt = new DataTable(); da.Fill(dt);
                dgvHopDong.DataSource = dt;
            }
        }

        private void HopDong_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(KetNoi.ChuoiKetNoi))
            {
                string sql = @"INSERT INTO tblHopDong (MaPhongTro, MaKhachThue, HinhThucThue, TienCoc, NgayKi, NgayHetHan, GhiChu)
                       VALUES (@mp, @mk, @ht, @tc, @nk, @nhh, @gc)";
                // Thêm Parameters tương ứng...
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mp", txtMaPhongTro.Text);
                cmd.Parameters.AddWithValue("@mk", txtMaKhachThue.Text);
                cmd.Parameters.AddWithValue("@ht", txtHinhThucThue.Text);
                cmd.Parameters.AddWithValue("@tc", txtTienCoc.Text);
                cmd.Parameters.AddWithValue("@nk", dtpNgayKi.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@nhh", dtpNgayHetHan.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@gc", txtGhiChu.Text);
                conn.Open(); cmd.ExecuteNonQuery();
                MessageBox.Show("✅ Thêm hợp đồng thành công!"); LoadData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvHopDong.SelectedRows.Count == 0) return;
            int ma = Convert.ToInt32(dgvHopDong.SelectedRows[0].Cells["MaPhongTro"].Value);
            using (SqlConnection conn = new SqlConnection(KetNoi.ChuoiKetNoi))
            {
                string sql = @"INSERT INTO tblHopDong (MaPhongTro, MaKhachThue, HinhThucThue, TienCoc, NgayKi, NgayHetHan, GhiChu)
                       VALUES (@mp, @mk, @ht, @tc, @nk, @nhh, @gc)";
                // Thêm Parameters tương ứng...
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mp", txtMaPhongTro.Text);
                cmd.Parameters.AddWithValue("@mk", txtMaKhachThue.Text);
                cmd.Parameters.AddWithValue("@ht", txtHinhThucThue.Text);
                cmd.Parameters.AddWithValue("@tc", txtTienCoc.Text);
                cmd.Parameters.AddWithValue("@nk", dtpNgayKi.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@nhh", dtpNgayHetHan.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@gc", txtGhiChu.Text);
                conn.Open(); cmd.ExecuteNonQuery();
                MessageBox.Show("✅ Thêm hợp đồng thành công!"); LoadData();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHopDong.SelectedRows.Count == 0) return;
            if (MessageBox.Show("Xóa hợp đồng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int ma = Convert.ToInt32(dgvHopDong.SelectedRows[0].Cells["MaPhongTro"].Value);
                using (SqlConnection conn = new SqlConnection(KetNoi.ChuoiKetNoi))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblHopDong WHERE MaPhongTro = @ma", conn);
                    cmd.Parameters.AddWithValue("@ma", ma);
                    conn.Open(); cmd.ExecuteNonQuery();
                }    
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}
