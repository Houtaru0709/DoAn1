using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string TenDangNhap { get; set; }

        private void hỆTHỐNGToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // ====================== MENU - QUẢN LÝ ======================
        private void phòngTrọToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhongTro_ f = new PhongTro_();
            f.ShowDialog();   // hoặc f.Show() nếu muốn mở nhiều cửa sổ
        }

        private void kháchThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhachThue f = new KhachThue();
            f.ShowDialog();
        }

        private void hợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HopDong f = new HopDong();
            f.ShowDialog();
        }

        private void điệnNướcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DienNuoc f = new DienNuoc();
            f.ShowDialog();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDon f = new HoaDon();
            f.ShowDialog();
        }

        // ====================== ĐĂNG XUẤT ======================
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                DangNhap login = new DangNhap();
                login.Show();
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            đăngXuấtToolStripMenuItem_Click(sender, e);  // gọi lại hàm trên
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            lblChao.Text = $"Chào mừng {TenDangNhap ??"" }!";
        }

        private void đăngXuấtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                this.Close();
            DangNhap dangNhap = new DangNhap();
            dangNhap.Show();
        }

        private void kháchThuêToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            KhachThue f = new KhachThue();
            this.Close();
            f.ShowDialog();

        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void phòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhongTro_ f = new PhongTro_();
            this.Close();
            f.ShowDialog();
        }

        private void hợpĐồngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            HopDong f = new HopDong();
            this.Close();
            f.ShowDialog();
        }

        private void điệnNướcToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DienNuoc f = new DienNuoc();
            this.Close();
            f.ShowDialog();
        }

        private void hóaĐơnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            HoaDon f = new HoaDon();
            this.Close();
            f.ShowDialog();
        }
    }
}
