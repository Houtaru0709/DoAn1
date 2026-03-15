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
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            DangNhap dangNhap = new DangNhap();
            dangNhap.Show(); // Mở lại form đăng nhập

        }

        private void btnXacNhan_Click_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra không để trống
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text) ||
                string.IsNullOrWhiteSpace(txtMatKhau.Text) ||
                string.IsNullOrWhiteSpace(txtXacNhanMK.Text)||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra mật khẩu xác nhận khớp
            if (txtMatKhau.Text != txtXacNhanMK.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacNhanMK.Focus();
                return;
            }

            // 3. Kiểm tra tên đăng nhập đã tồn tại chưa
            using (SqlConnection conn = new SqlConnection(KetNoi.ChuoiKetNoi))
            {
                string checkSql = "SELECT COUNT(*) FROM tblDangNhap WHERE TenDangNhap = @ten";
                SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                checkCmd.Parameters.AddWithValue("@ten", txtTenDangNhap.Text.Trim());

                conn.Open();
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!\nVui lòng chọn tên khác.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 4. Thêm tài khoản mới
                string insertSql = @"INSERT INTO tblDangNhap (TenDangNhap, MatKhau, Email) 
                                    VALUES (@ten, @mk, NULL)";   // Email để NULL vì form chưa có

                SqlCommand cmd = new SqlCommand(insertSql, conn);
                cmd.Parameters.AddWithValue("@ten", txtTenDangNhap.Text.Trim());
                cmd.Parameters.AddWithValue("@mk", txtMatKhau.Text);  // Lưu plain text (như admin123)

                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Đăng ký tài khoản thành công!\n\n" +
                                "Bạn có thể đăng nhập ngay bây giờ.",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();   // Đóng form đăng ký
                DangNhap dangNhap = new DangNhap();
                dangNhap.Show(); // Mở lại form đăng nhập
            }
        }
    }
}
