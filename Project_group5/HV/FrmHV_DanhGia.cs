using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_group5.HV
{
    public partial class FrmHV_DanhGia : UserControl
    {
        HV_DAO hvDAO = new HV_DAO();
        List<string> list = new List<string>() { "1. Giảng viên lên lớp đúng giờ, dạy đủ số tiết theo qui định",
        "2. Giảng viên sử dụng hiệu quả các phương tiện/ứng dụng công nghệ thông tin và truyền thông hỗ trợ giảng dạy (slides, video clips, máy chiếu, ...)",
        "3. Giảng viên áp dụng đa dạng các phương pháp dạy học tích cực nhằm khuyến khích người học phát triển năng lực tự học, tự nghiên cứu và làm việc nhóm",
        "4. Giảng viên tạo môi trường học tập thân thiện, hợp tác, khuyến khích sáng tạo trong dạy và học",
        "5. Nội dung giảng dạy bám sát đề cương chi tiết",
        "6. Giảng viên có tư thế, vị trí đứng lớp hợp lý đảm bảo bao quát lớp học",
        "7. Giảng viên nhiệt tình giải đáp thắc mắc và sẵn sàng tiếp thu ý kiến đóng góp của sinh viên",
        "8. Trong quá trình học, tôi đã được phản hồi kịp thời về kết quả đánh giá để cải tiến việc học",
        };
        List<string> list2 = new List<string>();
        string mahv;
        string malop;
        string magv;
        public FrmHV_DanhGia(string mahv, string malop)
        {
            InitializeComponent();
            this.mahv = mahv;
            this.malop = malop;
            
            for(int i = 0; i < list.Count; i++)
                {
                UC_Danhgia uc = new UC_Danhgia(list[i].ToString());
                flpDanhGia.Controls.Add(uc);
            }
            LopHoc lop= hvDAO.ThongTinLop(malop);
            if (hvDAO.CheckDanhGia(mahv, lop.maGV, lop.maLop))
            {
                btnXacNhan.Enabled = false;
                FrmMessageBox frmMessage = new FrmMessageBox("You have completed the assessment", "ANNOUNCEMENT");
                frmMessage.ShowDialog();
            }    
            magv=lop.maGV;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            list2.Clear();
            foreach (UC_Danhgia uc in flpDanhGia.Controls)
            {
                list2.Add(uc.indexCheck().ToString());
            }
            for(int i = 0; i < list2.Count; i++)
                if (list2[i] == "-1")
                {
                    FrmMessageBox frmMessage = new FrmMessageBox("The information is not valid", "ANNOUNCEMENT");
                    frmMessage.ShowDialog();
                    return;
                }                     
            hvDAO.ThemDanhGia(mahv,magv, malop, list2);
            btnXacNhan.Enabled=false;
        }
    }
}
