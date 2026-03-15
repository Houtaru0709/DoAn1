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
    public partial class DienNuoc : Form
    {
        public DienNuoc()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(KetNoi.ChuoiKetNoi))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblDienNuoc", conn);
                DataTable dt = new DataTable(); da.Fill(dt);
                dgvDienNuoc.DataSource = dt;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtToaNha_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Close();
            f.Show();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(KetNoi.ChuoiKetNoi))
                {
                    // Tính toán tiêu thụ điện/nước và tiền
                    int dienCu = int.Parse(txtSoDienCu.Text);
                    int dienMoi = int.Parse(txtSoDienMoi.Text);
                    int nuocCu = int.Parse(txtSoNuocCu.Text);
                    int nuocMoi = int.Parse(txtSoNuocMoi.Text);

                    int tieuThuDien = dienMoi - dienCu;
                    int tieuThuNuoc = nuocMoi - nuocCu;

                    decimal donGiaDien = decimal.Parse(txtDonGiaDien.Text);
                    decimal donGiaNuoc = decimal.Parse(txtDonGiaNuoc.Text);

                    decimal tienDien = tieuThuDien * donGiaDien;
                    decimal tienNuoc = tieuThuNuoc * donGiaNuoc;

                    string sql = @"INSERT INTO tblDienNuoc 
                           (MaPhongTro, ThangNam, SoDienCu, SoDienMoi, TieuThuDien, TienDien,
                            SoNuocCu, SoNuocMoi, TieuThuNuoc, TienNuoc, DonGiaDien, DonGiaNuoc) 
                           VALUES (@mp, @thangnam, @dienCu, @dienMoi, @tieuThuDien, @tienDien,
                                   @nuocCu, @nuocMoi, @tieuThuNuoc, @tienNuoc, @giaDien, @giaNuoc)";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@mp", txtMaPhongTro.Text.Trim());
                    cmd.Parameters.AddWithValue("@thangnam", txtThangNam.Text.Trim());
                    cmd.Parameters.AddWithValue("@dienCu", dienCu);
                    cmd.Parameters.AddWithValue("@dienMoi", dienMoi);
                    cmd.Parameters.AddWithValue("@tieuThuDien", tieuThuDien);
                    cmd.Parameters.AddWithValue("@tienDien", tienDien);
                    cmd.Parameters.AddWithValue("@nuocCu", nuocCu);
                    cmd.Parameters.AddWithValue("@nuocMoi", nuocMoi);
                    cmd.Parameters.AddWithValue("@tieuThuNuoc", tieuThuNuoc);
                    cmd.Parameters.AddWithValue("@tienNuoc", tienNuoc);
                    cmd.Parameters.AddWithValue("@giaDien", donGiaDien);
                    cmd.Parameters.AddWithValue("@giaNuoc", donGiaNuoc);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm dữ liệu điện nước thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaPhong_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(KetNoi.ChuoiKetNoi))
                {
                    int dienCu = int.Parse(txtSoDienCu.Text);
                    int dienMoi = int.Parse(txtSoDienMoi.Text);
                    int nuocCu = int.Parse(txtSoNuocCu.Text);
                    int nuocMoi = int.Parse(txtSoNuocMoi.Text);

                    int tieuThuDien = dienMoi - dienCu;
                    int tieuThuNuoc = nuocMoi - nuocCu;

                    decimal donGiaDien = decimal.Parse(txtDonGiaDien.Text);
                    decimal donGiaNuoc = decimal.Parse(txtDonGiaNuoc.Text);

                    decimal tienDien = tieuThuDien * donGiaDien;
                    decimal tienNuoc = tieuThuNuoc * donGiaNuoc;

                    string sql = @"UPDATE tblDienNuoc SET 
                           SoDienCu=@dienCu, SoDienMoi=@dienMoi, TieuThuDien=@tieuThuDien, TienDien=@tienDien,
                           SoNuocCu=@nuocCu, SoNuocMoi=@nuocMoi, TieuThuNuoc=@tieuThuNuoc, TienNuoc=@tienNuoc,
                           DonGiaDien=@giaDien, DonGiaNuoc=@giaNuoc
                           WHERE MaPhongTro=@mp AND ThangNam=@thangnam";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@mp", txtMaPhongTro.Text.Trim());
                    cmd.Parameters.AddWithValue("@thangnam", txtThangNam.Text.Trim());
                    cmd.Parameters.AddWithValue("@dienCu", dienCu);
                    cmd.Parameters.AddWithValue("@dienMoi", dienMoi);
                    cmd.Parameters.AddWithValue("@tieuThuDien", tieuThuDien);
                    cmd.Parameters.AddWithValue("@tienDien", tienDien);
                    cmd.Parameters.AddWithValue("@nuocCu", nuocCu);
                    cmd.Parameters.AddWithValue("@nuocMoi", nuocMoi);
                    cmd.Parameters.AddWithValue("@tieuThuNuoc", tieuThuNuoc);
                    cmd.Parameters.AddWithValue("@tienNuoc", tienNuoc);
                    cmd.Parameters.AddWithValue("@giaDien", donGiaDien);
                    cmd.Parameters.AddWithValue("@giaNuoc", donGiaNuoc);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Sửa dữ liệu điện nước thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaPhongTro.Text) || string.IsNullOrWhiteSpace(txtThangNam.Text))
                {
                    MessageBox.Show("Vui lòng nhập Mã phòng và Tháng/Năm để xóa!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(KetNoi.ChuoiKetNoi))
                {
                    string sql = @"DELETE FROM tblDienNuoc 
                           WHERE MaPhongTro=@mp AND ThangNam=@thangnam";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@mp", txtMaPhongTro.Text.Trim());
                    cmd.Parameters.AddWithValue("@thangnam", txtThangNam.Text.Trim());

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Xóa dữ liệu điện nước thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu để xóa!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSoDienCu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
