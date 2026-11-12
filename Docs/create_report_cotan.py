# -*- coding: utf-8 -*-
"""
Tạo Báo cáo Chuyên đề Lập trình .NET chuẩn 100% mẫu cô Tân (coTan.pdf)
Đề tài: Hệ thống Giao dịch Ngân hàng & Mạng lưới ATM Phân tán
Khoa CNTT - Đại học Điện Lực (EPU)
"""

import docx
from docx.shared import Pt, Inches, RGBColor
from docx.enum.text import WD_ALIGN_PARAGRAPH, WD_LINE_SPACING
from docx.enum.table import WD_TABLE_ALIGNMENT, WD_ALIGN_VERTICAL
from docx.oxml import OxmlElement, parse_xml
from docx.oxml.ns import nsdecls, qn
import os

doc = docx.Document()

# -------------------------------------------------------------
# 1. PAGE SETUP (Chuẩn quy định ĐH Điện Lực: Trái 3cm, Trên 2cm, Dưới 2cm, Phải 2cm)
# -------------------------------------------------------------
sec_cover = doc.sections[0]
sec_cover.top_margin = Inches(0.79)     # 2 cm
sec_cover.bottom_margin = Inches(0.79)  # 2 cm
sec_cover.left_margin = Inches(1.18)    # 3 cm
sec_cover.right_margin = Inches(0.79)   # 2 cm

# Thiết lập đường viền khung đôi cho trang bìa (giống hệt bìa cô Tân)
def set_cover_page_border(section):
    sectPr = section._sectPr
    borders_xml = parse_xml(r'''
        <w:pgBorders %s w:offsetFrom="page">
            <w:top w:val="double" w:sz="12" w:space="24" w:color="000000"/>
            <w:left w:val="double" w:sz="12" w:space="24" w:color="000000"/>
            <w:bottom w:val="double" w:sz="12" w:space="24" w:color="000000"/>
            <w:right w:val="double" w:sz="12" w:space="24" w:color="000000"/>
        </w:pgBorders>
    ''' % nsdecls('w'))
    sectPr.append(borders_xml)

set_cover_page_border(sec_cover)

# Font chuẩn: Times New Roman, đen 100%, không màu mè hoa lá
style_normal = doc.styles['Normal']
style_normal.font.name = 'Times New Roman'
style_normal.font.size = Pt(13)
style_normal.font.color.rgb = RGBColor(0, 0, 0)

# Hàm thêm đoạn văn bản chuẩn
def add_p(text='', align=WD_ALIGN_PARAGRAPH.LEFT, bold=False, italic=False, size=13, space_before=0, space_after=4, line_spacing=1.3, indent=False):
    p = doc.add_paragraph()
    p.alignment = align
    p.paragraph_format.space_before = Pt(space_before)
    p.paragraph_format.space_after = Pt(space_after)
    p.paragraph_format.line_spacing = line_spacing
    if indent:
        p.paragraph_format.first_line_indent = Inches(0.5) # 1.27 cm chuẩn
    if text:
        run = p.add_run(text)
        run.font.name = 'Times New Roman'
        run.font.size = Pt(size)
        run.font.bold = bold
        run.font.italic = italic
        run.font.color.rgb = RGBColor(0, 0, 0)
    return p

def set_cell_border(cell, top='single', bottom='single', left='single', right='single', sz='4', color='000000'):
    tcPr = cell._tc.get_or_add_tcPr()
    xml = f'''
        <w:tcBorders {nsdecls("w")}>
            <w:top w:val="{top}" w:sz="{sz}" w:space="0" w:color="{color}"/>
            <w:left w:val="{left}" w:sz="{sz}" w:space="0" w:color="{color}"/>
            <w:bottom w:val="{bottom}" w:sz="{sz}" w:space="0" w:color="{color}"/>
            <w:right w:val="{right}" w:sz="{sz}" w:space="0" w:color="{color}"/>
        </w:tcBorders>
    '''
    tcPr.append(parse_xml(xml))

# =============================================================
# TRANG 1: TRANG BÌA (GIỐNG HỆT FILE CÔ TÂN)
# =============================================================
add_p('BỘ CÔNG THƯƠNG', align=WD_ALIGN_PARAGRAPH.CENTER, bold=True, size=13, space_after=2)
add_p('TRƯỜNG ĐẠI HỌC ĐIỆN LỰC', align=WD_ALIGN_PARAGRAPH.CENTER, bold=True, size=14, space_after=2)
add_p('KHOA CÔNG NGHỆ THÔNG TIN', align=WD_ALIGN_PARAGRAPH.CENTER, bold=True, size=14, space_after=12)

# Logo EPU
logo_path = r'D:\BCNET\EPU_BankSystem\Docs\epu_logo.bmp'
if os.path.exists(logo_path):
    p_logo = doc.add_paragraph()
    p_logo.alignment = WD_ALIGN_PARAGRAPH.CENTER
    p_logo.paragraph_format.space_after = Pt(12)
    p_logo.add_run().add_picture(logo_path, width=Inches(1.6))

add_p('BÁO CÁO CHUYÊN ĐỀ HỌC PHẦN', align=WD_ALIGN_PARAGRAPH.CENTER, bold=True, size=14, space_after=4)
add_p('LẬP TRÌNH .NET', align=WD_ALIGN_PARAGRAPH.CENTER, bold=True, size=14, space_after=10)

add_p('PHÁT TRIỂN PHẦN MỀM DESKTOP APPLICATION', align=WD_ALIGN_PARAGRAPH.CENTER, bold=True, size=14, space_after=4)
add_p('ĐỂ QUẢN LÝ HỆ THỐNG GIAO DỊCH NGÂN HÀNG VÀ', align=WD_ALIGN_PARAGRAPH.CENTER, bold=True, size=14, space_after=4)
add_p('MẠNG LƯỚI ATM PHÂN TÁN', align=WD_ALIGN_PARAGRAPH.CENTER, bold=True, size=14, space_after=28)

# Bảng thông tin sinh viên & giảng viên (không viền, căn lề như mẫu cô Tân)
tbl_info = doc.add_table(rows=7, cols=2)
tbl_info.alignment = WD_TABLE_ALIGNMENT.CENTER
tbl_info.autofit = True

info_data = [
    ("Giảng viên hướng dẫn", ": TS. TRẦN TRUNG\n  ThS. VŨ THỊ TÂN"),
    ("Sinh viên thực hiện", ": LÊ THỊ THÚY HIỀN (24810310243)\n  NGUYỄN HOÀI ĐỨC (24810310...)\n  ĐỖ DUY AN (24810310...)"),
    ("Ngành", ": CÔNG NGHỆ THÔNG TIN"),
    ("Chuyên ngành", ": CÔNG NGHỆ PHẦN MỀM"),
    ("Lớp", ": D18CNPM2"),
    ("Khóa", ": 2023-2028"),
    ("", "")
]

for idx, (label, val) in enumerate(info_data):
    row = tbl_info.rows[idx]
    
    cell_lbl = row.cells[0]
    cell_lbl.width = Inches(2.2)
    p_l = cell_lbl.paragraphs[0]
    p_l.paragraph_format.space_after = Pt(3)
    p_l.paragraph_format.space_before = Pt(0)
    run_l = p_l.add_run(label)
    run_l.font.name = 'Times New Roman'
    run_l.font.size = Pt(13)
    run_l.font.bold = True if "Giảng viên" in label or "Sinh viên" in label or "Ngành" in label else False
    
    cell_val = row.cells[1]
    cell_val.width = Inches(4.2)
    p_v = cell_val.paragraphs[0]
    p_v.paragraph_format.space_after = Pt(3)
    p_v.paragraph_format.space_before = Pt(0)
    run_v = p_v.add_run(val)
    run_v.font.name = 'Times New Roman'
    run_v.font.size = Pt(13)
    run_v.font.bold = True if "TS." in val or "LÊ THỊ" in val or "CÔNG NGHỆ" in val or "D18CNPM2" in val else False

add_p('Hà Nội, tháng 11 năm 2026', align=WD_ALIGN_PARAGRAPH.CENTER, italic=True, size=13, space_before=36)

# Ngắt sang phần nội dung chính (bỏ viền đôi trang bìa cho các trang sau)
sec_body = doc.add_section()
sec_body.top_margin = Inches(0.79)
sec_body.bottom_margin = Inches(0.79)
sec_body.left_margin = Inches(1.18)
sec_body.right_margin = Inches(0.79)

# Bỏ viền đôi cho section thân bài
sectPr_body = sec_body._sectPr
borders_empty = parse_xml(r'''
    <w:pgBorders %s w:offsetFrom="page">
        <w:top w:val="none"/>
        <w:left w:val="none"/>
        <w:bottom w:val="none"/>
        <w:right w:val="none"/>
    </w:pgBorders>
''' % nsdecls('w'))
sectPr_body.append(borders_empty)

# =============================================================
# TRANG 2: PHIẾU CHẤM ĐIỂM (Y HỆT MẪU TRANG 2 CÔ TÂN)
# =============================================================
add_p('PHIẾU CHẤM ĐIỂM', align=WD_ALIGN_PARAGRAPH.CENTER, bold=True, size=14, space_after=14)

tbl_score1 = doc.add_table(rows=4, cols=5)
tbl_score1.alignment = WD_TABLE_ALIGNMENT.CENTER

headers1 = ['STT', 'Họ và tên sinh viên', 'Nội dung thực hiện', 'Điểm', 'Chữ\nký']
for c_idx, h in enumerate(headers1):
    cell = tbl_score1.cell(0, c_idx)
    cell.text = h
    set_cell_border(cell)
    p = cell.paragraphs[0]
    p.alignment = WD_ALIGN_PARAGRAPH.CENTER
    p.runs[0].font.name = 'Times New Roman'
    p.runs[0].font.size = Pt(12)
    p.runs[0].font.bold = True

rows_sv = [
    ("1", "Lê Thị Thúy Hiền\n24810310243", "Trưởng nhóm, Thiết kế CSDL SQL Server 8 bảng, Viết tầng DatabaseHelper (DAO), Kết nối Socket C#"),
    ("2", "Nguyễn Hoài Đức\n24810310...", "Phát triển máy chủ Core Server Socket, Xử lý Đa luồng Concurrency Lock chống rút tiền trùng (Race Condition)"),
    ("3", "Đỗ Duy An\n24810310...", "Thiết kế Giao diện Client WinForms ATM, Bắt sự kiện giao dịch Rút tiền, Chuyển khoản, Đổi PIN")
]

for r_idx, (stt, ten, nd) in enumerate(rows_sv, start=1):
    for c_idx, val in enumerate([stt, ten, nd, "", ""]):
        cell = tbl_score1.cell(r_idx, c_idx)
        cell.text = val
        set_cell_border(cell)
        p = cell.paragraphs[0]
        p.alignment = WD_ALIGN_PARAGRAPH.CENTER if c_idx in [0, 3, 4] else WD_ALIGN_PARAGRAPH.LEFT
        for run in p.runs:
            run.font.name = 'Times New Roman'
            run.font.size = Pt(11)

add_p('', space_after=14)

# Bảng chữ ký giảng viên
tbl_score2 = doc.add_table(rows=3, cols=3)
tbl_score2.alignment = WD_TABLE_ALIGNMENT.CENTER
headers2 = ['Họ và tên giảng viên', 'Chữ ký', 'Ghi chú']
for c_idx, h in enumerate(headers2):
    cell = tbl_score2.cell(0, c_idx)
    cell.text = h
    set_cell_border(cell)
    p = cell.paragraphs[0]
    p.alignment = WD_ALIGN_PARAGRAPH.CENTER
    p.runs[0].font.name = 'Times New Roman'
    p.runs[0].font.size = Pt(12)
    p.runs[0].font.bold = True

for r_idx, gv in enumerate(["Giảng viên chấm 1:", "Giảng viên chấm 2:"], start=1):
    for c_idx, val in enumerate([gv, "", ""]):
        cell = tbl_score2.cell(r_idx, c_idx)
        cell.text = val
        set_cell_border(cell)
        p = cell.paragraphs[0]
        p.alignment = WD_ALIGN_PARAGRAPH.LEFT if c_idx == 0 else WD_ALIGN_PARAGRAPH.CENTER
        for run in p.runs:
            run.font.name = 'Times New Roman'
            run.font.size = Pt(11)

doc.add_page_break()

# =============================================================
# TRANG 3, 4: MỤC LỤC (Y HỆT FILE CÔ TÂN)
# =============================================================
add_p('MỤC LỤC', align=WD_ALIGN_PARAGRAPH.CENTER, bold=True, size=14, space_after=12)

muc_luc_data = [
    ("LỜI MỞ ĐẦU", ""),
    ("CHƯƠNG 1: KHẢO SÁT HIỆN TRẠNG VÀ XÁC LẬP DỰ ÁN", "1"),
    ("  1.1. Khảo sát hiện trạng", "1"),
    ("    1.1.1. Giới thiệu về Ngân hàng TMCP Điện Lực (EPU Bank)", "1"),
    ("    1.1.2. Quy trình hoạt động", "2"),
    ("    1.1.3. Ưu nhược điểm của hệ thống hiện tại", "4"),
    ("  1.2. Xác lập dự án", "6"),
    ("    1.2.1. Mục tiêu của dự án mới", "6"),
    ("    1.2.2. Yêu cầu hệ thống mới", "8"),
    ("      a. Yêu cầu về phần mềm", "8"),
    ("      b. Yêu cầu phi chức năng", "9"),
    ("    1.2.3. Phạm vi thực hiện dự án", "9"),
    ("    1.2.4. Ước tính chi phí", "10"),
    ("CHƯƠNG 2: PHÂN TÍCH THIẾT KẾ HỆ THỐNG", "11"),
    ("  2.1. Xác định các Actor và Usecase tổng quát của hệ thống", "11"),
    ("    2.1.1. Actor và Usecase tổng quát", "11"),
    ("  2.2. Phân tích, thiết kế từng chức năng của hệ thống", "13"),
    ("    2.2.1. Chức năng Đăng nhập", "13"),
    ("    2.2.2. Chức năng Vấn tin số dư", "15"),
    ("    2.2.3. Chức năng Rút tiền mặt", "18"),
    ("    2.2.4. Chức năng Chuyển khoản", "21"),
    ("    2.2.5. Chức năng Đổi mã PIN", "26"),
    ("    2.2.6. Chức năng Xem lịch sử giao dịch", "28"),
    ("    2.2.7. Chức năng Khóa thẻ tự động", "30"),
    ("    2.2.8. Chức năng Quản lý máy ATM & Tiếp quỹ tiền mặt", "32"),
    ("  2.3. Biểu đồ lớp của hệ thống", "43"),
    ("CHƯƠNG 3: GIAO DIỆN SẢN PHẨM", "44"),
    ("  3.1. Giao diện trang đăng nhập", "44"),
    ("  3.2. Giao diện trang Menu chính", "44"),
    ("  3.3. Giao diện trang vấn tin số dư", "45"),
    ("  3.4. Giao diện trang rút tiền mặt", "45"),
    ("  3.5. Giao diện trang chuyển khoản", "46"),
    ("  3.6. Giao diện trang đổi mã PIN", "47"),
    ("  3.7. Giao diện trang xem lịch sử giao dịch", "48"),
    ("  3.8. Giao diện trang quản trị máy chủ Server Monitor", "49"),
    ("KẾT LUẬN", "51"),
    ("DANH MỤC TÀI LIỆU THAM KHẢO", "52")
]

for title, page in muc_luc_data:
    p = doc.add_paragraph()
    p.paragraph_format.space_before = Pt(1)
    p.paragraph_format.space_after = Pt(2)
    p.paragraph_format.line_spacing = 1.15
    is_main = title.startswith("CHƯƠNG") or title in ["LỜI MỞ ĐẦU", "KẾT LUẬN", "DANH MỤC TÀI LIỆU THAM KHẢO"]
    
    dots_count = max(5, 75 - len(title))
    dots = " ." * (dots_count // 2)
    line_text = f"{title}{dots} {page}"
    
    run = p.add_run(line_text)
    run.font.name = 'Times New Roman'
    run.font.size = Pt(12)
    run.font.bold = is_main

doc.add_page_break()

# =============================================================
# TRANG 5, 6, 7: DANH MỤC HÌNH ẢNH & DANH MỤC BẢNG BIỂU
# =============================================================
add_p('DANH MỤC HÌNH ẢNH', align=WD_ALIGN_PARAGRAPH.CENTER, bold=True, size=14, space_after=12)

hinh_anh_data = [
    ("Hình 1.1: Trạm ATM Ngân hàng TMCP Điện Lực (EPU Bank)", "1"),
    ("Hình 2.1.1: Biểu đồ Use case tổng quát", "12"),
    ("Hình 2.2.1: Biểu đồ Use case chức năng Đăng nhập", "13"),
    ("Hình 2.2.2: Biểu đồ trình tự cho chức năng Đăng nhập", "14"),
    ("Hình 2.2.3: Biểu đồ Usecase Vấn tin số dư", "15"),
    ("Hình 2.2.4: Biểu đồ trình tự chức năng Vấn tin số dư", "16"),
    ("Hình 2.2.5: Use case chức năng Rút tiền mặt", "18"),
    ("Hình 2.2.6: Biểu đồ trình tự cho chức năng Rút tiền mặt", "20"),
    ("Hình 2.2.7: Use case chức năng Chuyển khoản", "21"),
    ("Hình 2.2.8: Biểu đồ trình tự cho chức năng Chuyển khoản", "24"),
    ("Hình 2.2.9: Biểu đồ Use case chức năng Đổi mã PIN", "26"),
    ("Hình 2.2.10: Biểu đồ trình tự chức năng Đổi mã PIN", "27"),
    ("Hình 2.2.11: Biểu đồ use case chức năng Xem lịch sử giao dịch", "28"),
    ("Hình 2.2.12: Biểu đồ trình tự chức năng Xem lịch sử giao dịch", "29"),
    ("Hình 2.2.13: Biểu đồ use case chức năng Khóa thẻ tự động", "30"),
    ("Hình 2.2.14: Biểu đồ trình tự chức năng Khóa thẻ tự động", "31"),
    ("Hình 2.2.15: Biểu đồ use case chức năng Tiếp quỹ máy ATM", "32"),
    ("Hình 2.2.16: Biểu đồ trình tự chức năng Tiếp quỹ máy ATM", "34"),
    ("Hình 2.2.17: Biểu đồ lớp của hệ thống", "43"),
    ("Hình 3.1: Giao diện trang đăng nhập", "44"),
    ("Hình 3.2: Giao diện trang Menu chính", "44"),
    ("Hình 3.3: Giao diện trang vấn tin số dư", "45"),
    ("Hình 3.4: Giao diện trang rút tiền mặt", "45"),
    ("Hình 3.5: Giao diện trang chuyển khoản", "46"),
    ("Hình 3.6: Giao diện trang đổi mã PIN", "47"),
    ("Hình 3.7: Giao diện trang xem lịch sử giao dịch", "48"),
    ("Hình 3.8: Giao diện trang quản trị máy chủ Server Monitor", "49")
]

for title, page in hinh_anh_data:
    p = doc.add_paragraph()
    p.paragraph_format.space_after = Pt(2)
    p.paragraph_format.line_spacing = 1.15
    dots = " ." * ((75 - len(title)) // 2)
    run = p.add_run(f"{title}{dots} {page}")
    run.font.name = 'Times New Roman'
    run.font.size = Pt(12)

add_p('', space_after=12)
add_p('DANH MỤC BẢNG BIỂU', align=WD_ALIGN_PARAGRAPH.CENTER, bold=True, size=14, space_after=8)
p_b = doc.add_paragraph()
p_b.paragraph_format.line_spacing = 1.15
dots_b = " ." * ((75 - len("Bảng 2.1.1: Các Actor và Usecase tổng quát của hệ thống")) // 2)
run_b = p_b.add_run(f"Bảng 2.1.1: Các Actor và Usecase tổng quát của hệ thống{dots_b} 11")
run_b.font.name = 'Times New Roman'
run_b.font.size = Pt(12)

doc.add_page_break()

# =============================================================
# TRANG 8: LỜI MỞ ĐẦU (ĐÚNG PHONG CÁCH TRANG 8 CỦA CÔ TÂN)
# =============================================================
add_p('LỜI MỞ ĐẦU', align=WD_ALIGN_PARAGRAPH.CENTER, bold=True, size=14, space_after=12)

add_p('Thành công không bao giờ đến một cách đơn độc mà luôn gắn liền với sự hỗ trợ, giúp đỡ từ nhiều phía, dù ít hay nhiều, trực tiếp hay gián đoạn. Trong suốt thời gian học tập tại Trường Đại học Điện Lực, chúng tôi đã nhận được vô vàn sự quan tâm và giúp đỡ từ thầy cô, gia đình và bạn bè. Với lòng biết ơn sâu sắc nhất, chúng em xin gửi lời cảm ơn chân thành đến các thầy cô tại Khoa Công nghệ thông tin – Trường Đại học Điện Lực. Nhờ vào kiến thức sâu rộng và tâm huyết của thầy cô, chúng tôi đã đạt được tri thức quý báu trong suốt thời gian học tập tại trường.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=6, indent=True)

add_p('Đặc biệt, chúng em rất cảm kích khi được học môn "Lập trình .NET", một môn học vô cùng hữu ích đối với sinh viên ngành Công nghệ Thông Tin. Chúng em xin gửi lời cảm ơn đặc biệt đến TS. Trần Trung và ThS. Vũ Thị Tân, những người đã tận tâm hướng dẫn chúng tôi qua từng buổi học, cũng như trong những buổi thảo luận về môn học. Nhờ sự hướng dẫn và động viên của thầy cô, chúng em không chỉ thu được nhiều kiến thức bổ sung hữu ích mà còn cảm thấy đam mê và thích thú hơn với môn học này. Nếu không có những lời dạy bảo quý báu của thầy cô, chúng em nghĩ rằng đề tài "Phát triển phần mềm DESKTOP APPLICATION để quản lý hệ thống giao dịch ngân hàng và mạng lưới ATM phân tán" khó có thể hoàn thành tốt được.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=6, indent=True)

add_p('Mặc dù đã nỗ lực hết mình để hoàn thiện báo cáo này, nhưng do là bước đầu tiếp cận với thực tế và còn nhiều hạn chế về thời gian, chắc chắn nội dung vẫn còn thiếu sót. Chúng em rất mong nhận được sự quan tâm, thông cảm và những lời khuyên quý giá từ thầy cô và các bạn để đề tài này được hoàn thiện hơn. Chúng em xin chân thành cảm ơn và luôn mong nhận được sự đóng góp của mọi người.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=12, indent=True)

doc.add_page_break()

# =============================================================
# CHƯƠNG 1: KHẢO SÁT HIỆN TRẠNG VÀ XÁC LẬP DỰ ÁN
# =============================================================
add_p('CHƯƠNG 1: KHẢO SÁT HIỆN TRẠNG VÀ XÁC LẬP DỰ ÁN', align=WD_ALIGN_PARAGRAPH.CENTER, bold=True, size=14, space_after=12)

add_p('1.1. Khảo sát hiện trạng.', bold=True, size=13, space_after=4)
add_p('1.1.1. Giới thiệu về Ngân hàng TMCP Điện Lực (EPU Bank).', bold=True, size=13, space_after=4)
add_p('Từ khởi đầu mục tiêu cung cấp các dịch vụ tài chính hiện đại cho cán bộ, giảng viên và sinh viên, Ngân hàng TMCP Điện Lực (EPU Bank) với phương châm “Chất lượng hàng đầu - Dịch vụ tận tâm” đã và đang không ngừng nỗ lực cải thiện, mở rộng mạng lưới máy rút tiền tự động (ATM) để đáp ứng nhu cầu giao dịch tiền mặt và chuyển khoản ngày càng cao.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=6, indent=True)

add_p('- Thông tin chung:', bold=False, size=13, space_after=2)
add_p('  Tên tổ chức: Ngân hàng Thương mại Cổ phần Điện Lực (EPU Bank).', size=13, space_after=2)
add_p('  Thời gian phục vụ: Phục vụ 24/7 đối với hệ thống trạm máy ATM.', size=13, space_after=2)
add_p('- Địa chỉ hội sở: Số 235 đường Hoàng Quốc Việt, phường Cổ Nhuế 1, quận Bắc Từ Liêm, thành phố Hà Nội.', size=13, space_after=2)
add_p('  Hotline hỗ trợ: 1900 1234 - Quản lý kỹ thuật: 0912 345 678.', size=13, space_after=2)
add_p('  Email: contact@epubank.edu.vn.', size=13, space_after=6)
add_p('Hình 1.1: Trạm ATM Ngân hàng TMCP Điện Lực (EPU Bank).', align=WD_ALIGN_PARAGRAPH.CENTER, italic=True, size=12, space_after=8)

add_p('- Cơ cấu tổ chức:', bold=False, size=13, space_after=2)
add_p('+ Ban quản trị hệ thống (Admin): Chịu trách nhiệm quản lý, điều hành hạ tầng máy chủ trung tâm (Core Server), tài chính, an ninh mạng, phân quyền và giám sát hoạt động của các cây ATM trong toàn mạng lưới.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=4)
add_p('+ Khách hàng: Sử dụng thẻ ATM được cấp để thực hiện các giao dịch rút tiền mặt, chuyển khoản, đổi mã PIN và kiểm tra số dư theo đúng quy định bảo mật.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=6)

add_p('1.1.2. Quy trình hoạt động.', bold=True, size=13, space_after=4)

add_p('Bước 1: Tiếp nhận thẻ và xác thực mã PIN.', bold=True, size=13, space_after=2)
add_p('Khách hàng đưa thẻ ATM vào khe nhận thẻ của cây ATM. Màn hình yêu cầu khách hàng nhập mã bí mật cá nhân (mã PIN gồm 6 số) để xác minh danh tính chủ tài khoản.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=4)

add_p('Bước 2: Xác minh danh tính và kiểm tra bảo mật.', bold=True, size=13, space_after=2)
add_p('- Cây ATM đóng gói thông tin gửi về máy chủ trung tâm qua giao thức mạng TCP Socket.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=2)
add_p('- Máy chủ kiểm tra trạng thái thẻ trong cơ sở dữ liệu: nếu thẻ bị khóa thì từ chối; nếu nhập sai mã PIN quá 3 lần liên tiếp thì hệ thống tự động khóa thẻ ngay lập tức để bảo vệ tài khoản; nếu mã PIN chính xác thì chuyển sang màn hình Menu chính.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=4)

add_p('Bước 3: Lựa chọn dịch vụ.', bold=True, size=13, space_after=2)
add_p('Khách hàng lựa chọn một trong các dịch vụ: Vấn tin số dư, Rút tiền mặt, Chuyển khoản, Đổi mã PIN hoặc Xem lịch sử giao dịch.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=4)

add_p('Bước 4: Kiểm tra điều kiện thực hiện giao dịch.', bold=True, size=13, space_after=2)
add_p('Khi khách hàng yêu cầu rút tiền hoặc chuyển khoản, máy chủ kiểm tra số dư khả dụng trong tài khoản và kiểm tra lượng tiền mặt tồn trong các khay tiền của cây ATM tương ứng.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=4)

add_p('Bước 5: Xử lý giao dịch tại Server (Khóa luồng Concurrency).', bold=True, size=13, space_after=2)
add_p('Máy chủ kích hoạt cơ chế khóa tài khoản đồng thời (Concurrency Lock) để tránh hiện tượng rút tiền trùng lặp (Race Condition), thực hiện trừ tiền trong tài khoản và ghi nhận vào bảng nhật ký giao dịch.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=4)

add_p('Bước 6: Nhả tiền mặt và cập nhật khay tiền.', bold=True, size=13, space_after=2)
add_p('Cây ATM kích hoạt động cơ nhả tiền theo các mệnh giá tiền mặt tương ứng (500k, 200k, 100k, 50k), cập nhật trừ số lượng tờ trong khay tiền của máy.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=4)

add_p('Bước 7: Trả thẻ và in biên lai sao kê.', bold=True, size=13, space_after=2)
add_p('Hệ thống nhả thẻ ATM ra trước để đảm bảo khách hàng không bỏ quên thẻ, sau đó nhả hóa đơn sao kê và phát âm thanh kết thúc giao dịch.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=6)

add_p('1.1.3. Ưu nhược điểm của hệ thống hiện tại.', bold=True, size=13, space_after=4)
add_p('- Ưu điểm:', bold=True, size=13, space_after=2)
add_p('+ Chi phí vận hành thấp hơn việc mở nhiều chi nhánh quầy giao dịch truyền thống.', size=13, space_after=2)
add_p('+ Tính sẵn sàng cao: Khách hàng có thể rút tiền và chuyển tiền mọi lúc 24/7.', size=13, space_after=4)

add_p('- Nhược điểm:', bold=True, size=13, space_after=2)
add_p('+ Nguy cơ xung đột dữ liệu (Race Condition): Khi nhiều trạm cùng truy xuất và rút tiền trên một tài khoản đồng thời, nếu máy chủ không có cơ chế khóa luồng chặt chẽ sẽ gây sai lệch số dư nghiêm trọng.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=2)
add_p('+ Khó kiểm soát tồn quỹ tiền mặt: Việc ghi chép và kiểm đếm tiền thủ công dễ dẫn đến thiếu tiền mặt cục bộ tại các cây ATM đông khách.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=2)
add_p('+ Dễ mất mát hoặc thất lạc thông tin giao dịch nếu cơ sở dữ liệu không được quản lý tập trung và sao lưu định kỳ.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=6)

add_p('1.2. Xác lập dự án.', bold=True, size=13, space_after=4)
add_p('1.2.1. Mục tiêu của dự án mới.', bold=True, size=13, space_after=4)
add_p('Dự án nhằm xây dựng một hệ thống phần mềm Desktop Application kết nối mạng phân tán Client - Server chuyên nghiệp cho Ngân hàng TMCP Điện Lực (EPU Bank), giúp tự động hóa toàn bộ quy trình giao dịch rút tiền mặt, chuyển khoản và quản trị thẻ ATM an toàn, tin cậy.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=6, indent=True)

add_p('1.2.2. Yêu cầu hệ thống mới.', bold=True, size=13, space_after=4)
add_p('a. Yêu cầu về phần mềm.', bold=True, size=13, space_after=2)
add_p('- Phần mềm đảm bảo đáp ứng các chức năng chính của hệ thống giao dịch ngân hàng và mạng lưới ATM:', size=13, space_after=2)
funcs = [
    "Đăng nhập thẻ ATM và mã PIN",
    "Vấn tin số dư tài khoản",
    "Rút tiền mặt tại ATM",
    "Chuyển khoản nội bộ ngân hàng",
    "Đổi mã PIN thẻ",
    "Xem lịch sử giao dịch và in sao kê",
    "Khóa thẻ tự động khi nhập sai PIN 3 lần",
    "Quản lý máy ATM và tiếp quỹ tiền mặt",
    "Giám sát trạng thái máy chủ Core Banking"
]
for f in funcs:
    add_p(f'• {f}', size=13, space_after=2)

add_p('b. Yêu cầu phi chức năng.', bold=True, size=13, space_after=2)
add_p('- Độ bảo mật: Mã hóa mã PIN, tự động khóa thẻ khi nhập sai quá 3 lần để chống tin tặc dò mật khẩu.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=2)
add_p('- Nền tảng: Hệ thống được xây dựng bằng ngôn ngữ C# .NET và giao diện GUI Windows Forms, hệ quản trị cơ sở dữ liệu Microsoft SQL Server 2022.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=2)
add_p('- Yêu cầu phần cứng hệ thống: Hệ điều hành Windows 10/11 trở lên, Bộ xử lý CPU Core i5 trở lên, RAM tối thiểu 8GB (khuyến nghị 16GB), Ổ cứng SSD còn trống tối thiểu 1GB.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=2)
add_p('- Hiệu năng: Tốc độ phản hồi giao dịch dưới 1.5 giây, đảm bảo phục vụ đồng thời nhiều cây ATM không bị đơ máy.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=6)

add_p('1.2.3. Phạm vi thực hiện dự án.', bold=True, size=13, space_after=4)
add_p('Dự án tập trung vào quy trình xử lý giao dịch tại trạm ATM và đồng bộ dữ liệu về trung tâm ngân hàng, phục vụ khách hàng cá nhân và đội ngũ kỹ thuật viên tiếp quỹ ATM.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=6, indent=True)

add_p('1.2.4. Ước tính chi phí.', bold=True, size=13, space_after=4)
add_p('- Chi phí phần cứng: 50.000.000 VNĐ cho máy chủ và thiết bị lưu trữ.', size=13, space_after=2)
add_p('- Chi phí phát triển phần mềm: 80.000.000 VNĐ bao gồm chi phí nhân công và công cụ phát triển.', size=13, space_after=2)
add_p('- Chi phí bảo trì và nâng cấp: 20.000.000 VNĐ/năm cho việc duy trì và cập nhật hệ thống.', size=13, space_after=2)
add_p('- Tổng chi phí dự toán: 150.000.000 VNĐ.', bold=True, size=13, space_after=12)

doc.add_page_break()

# =============================================================
# CHƯƠNG 2: PHÂN TÍCH THIẾT KẾ HỆ THỐNG
# =============================================================
add_p('CHƯƠNG 2: PHÂN TÍCH THIẾT KẾ HỆ THỐNG', align=WD_ALIGN_PARAGRAPH.CENTER, bold=True, size=14, space_after=12)

add_p('2.1. Xác định các Actor và Usecase tổng quát của hệ thống.', bold=True, size=13, space_after=4)
add_p('2.1.1. Actor và Usecase tổng quát.', bold=True, size=13, space_after=4)

add_p('Bảng 2.1.1: Các Actor và Usecase tổng quát của hệ thống.', align=WD_ALIGN_PARAGRAPH.CENTER, italic=True, size=12, space_after=4)

tbl_actor = doc.add_table(rows=4, cols=3)
tbl_actor.alignment = WD_TABLE_ALIGNMENT.CENTER
headers_act = ['STT', 'Actor', 'Use case']
for c_idx, h in enumerate(headers_act):
    cell = tbl_actor.cell(0, c_idx)
    cell.text = h
    set_cell_border(cell)
    p = cell.paragraphs[0]
    p.alignment = WD_ALIGN_PARAGRAPH.CENTER
    p.runs[0].font.name = 'Times New Roman'
    p.runs[0].font.size = Pt(12)
    p.runs[0].font.bold = True

actors_data = [
    ("1", "Khách (Guest)", "- Đăng nhập thẻ ATM & PIN"),
    ("2", "Khách hàng (Customer)", "- Vấn tin số dư\n- Rút tiền mặt\n- Chuyển khoản\n- Đổi mã PIN\n- Xem lịch sử giao dịch"),
    ("3", "Kỹ thuật viên & Admin", "- Quản lý máy ATM\n- Tiếp quỹ tiền mặt\n- Khóa / Mở khóa thẻ\n- Xem nhật ký hệ thống")
]

for r_idx, (stt, act, uc) in enumerate(actors_data, start=1):
    for c_idx, val in enumerate([stt, act, uc]):
        cell = tbl_actor.cell(r_idx, c_idx)
        cell.text = val
        set_cell_border(cell)
        p = cell.paragraphs[0]
        p.alignment = WD_ALIGN_PARAGRAPH.CENTER if c_idx == 0 else WD_ALIGN_PARAGRAPH.LEFT
        for run in p.runs:
            run.font.name = 'Times New Roman'
            run.font.size = Pt(11)

add_p('', space_after=6)
add_p('Hình 2.1.1: Biểu đồ Use case tổng quát.', align=WD_ALIGN_PARAGRAPH.CENTER, italic=True, size=12, space_after=12)

# --- 2.2. Phân tích chi tiết từng chức năng ---
add_p('2.2. Phân tích, thiết kế từng chức năng của hệ thống.', bold=True, size=13, space_after=6)

# 2.2.1. Đăng nhập
add_p('2.2.1. Chức năng Đăng nhập.', bold=True, size=13, space_after=4)
add_p('Hình 2.2.1: Biểu đồ Use case chức năng Đăng nhập.', align=WD_ALIGN_PARAGRAPH.CENTER, italic=True, size=12, space_after=4)
add_p('- Đặc tả Usecase Đăng nhập:', bold=True, size=13, space_after=2)
add_p('+ Tác nhân: Khách hàng (Guest).', size=13, space_after=2)
add_p('+ Mô tả: Khách hàng đưa thẻ ATM vào cây ATM và nhập mã PIN để xác thực danh tính. Khi xác thực thành công, hệ thống mở khóa các chức năng giao dịch tài chính.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=2)
add_p('+ Các sự kiện:', bold=True, size=13, space_after=2)
add_p('• Tác nhân nhập số thẻ và mã PIN vào form Đăng nhập.', size=13, space_after=2)
add_p('• Form đăng nhập sẽ gửi dữ liệu đến control Đăng nhập (thông qua Socket gửi về Core Server).', size=13, space_after=2)
add_p('• Nếu thông tin số thẻ không tồn tại hoặc thẻ bị khóa thì thông báo đăng nhập thất bại và yêu cầu nhập lại.', size=13, space_after=2)
add_p('• Nếu mã PIN sai thì tăng số lần sai (sai quá 3 lần tự động khóa thẻ).', size=13, space_after=2)
add_p('• Nếu thông tin đúng, hệ thống thông báo đăng nhập thành công và đưa tác nhân vào màn hình Menu chính của hệ thống.', size=13, space_after=4)
add_p('Hình 2.2.2: Biểu đồ trình tự cho chức năng Đăng nhập.', align=WD_ALIGN_PARAGRAPH.CENTER, italic=True, size=12, space_after=8)

# 2.2.2. Vấn tin số dư
add_p('2.2.2. Chức năng Vấn tin số dư.', bold=True, size=13, space_after=4)
add_p('Hình 2.2.3: Biểu đồ Usecase Vấn tin số dư.', align=WD_ALIGN_PARAGRAPH.CENTER, italic=True, size=12, space_after=4)
add_p('- Đặc tả Usecase Vấn tin số dư:', bold=True, size=13, space_after=2)
add_p('+ Tác nhân: Khách hàng.', size=13, space_after=2)
add_p('+ Mô tả: Khách hàng kiểm tra số dư hiện tại của tài khoản ngân hàng trên màn hình cây ATM.', size=13, space_after=2)
add_p('+ Các sự kiện: Tác nhân nhấn nút Vấn tin số dư $\\rightarrow$ Hệ thống gửi truy vấn về Server $\\rightarrow$ Server đọc số dư từ bảng TaiKhoan $\\rightarrow$ Hiển thị số dư lên màn hình.', size=13, space_after=4)
add_p('Hình 2.2.4: Biểu đồ trình tự chức năng Vấn tin số dư.', align=WD_ALIGN_PARAGRAPH.CENTER, italic=True, size=12, space_after=8)

# 2.2.3. Rút tiền mặt
add_p('2.2.3. Chức năng Rút tiền mặt.', bold=True, size=13, space_after=4)
add_p('Hình 2.2.5: Use case chức năng Rút tiền mặt.', align=WD_ALIGN_PARAGRAPH.CENTER, italic=True, size=12, space_after=4)
add_p('- Đặc tả Usecase: Rút tiền mặt', bold=True, size=13, space_after=2)
add_p('+ Tác nhân: Khách hàng.', size=13, space_after=2)
add_p('+ Tiền điều kiện: Khách hàng đã đăng nhập thành công và cây ATM còn tiền mặt.', size=13, space_after=2)
add_p('+ Luồng sự kiện chính (Main Flow):', bold=True, size=13, space_after=2)
add_p('1. Khách hàng chọn chức năng Rút tiền và chọn hạn mức số tiền.', size=13, space_after=2)
add_p('2. Hệ thống gửi yêu cầu rút tiền về Server.', size=13, space_after=2)
add_p('3. Server kích hoạt khóa luồng đa luồng (Concurrency Lock) theo số tài khoản để chống rút tiền trùng.', size=13, space_after=2)
add_p('4. Server kiểm tra: Nếu số dư đủ và khay tiền còn tiền $\\rightarrow$ Trừ tiền trong CSDL $\\rightarrow$ Nhả tiền mặt $\\rightarrow$ Ghi nhật ký GiaoDich thành công.', size=13, space_after=2)
add_p('5. Nhả khóa luồng và thông báo nhận tiền.', size=13, space_after=4)
add_p('Hình 2.2.6: Biểu đồ trình tự cho chức năng Rút tiền mặt.', align=WD_ALIGN_PARAGRAPH.CENTER, italic=True, size=12, space_after=8)

# 2.2.4. Chuyển khoản
add_p('2.2.4. Chức năng Chuyển khoản.', bold=True, size=13, space_after=4)
add_p('Hình 2.2.7: Use case chức năng Chuyển khoản.', align=WD_ALIGN_PARAGRAPH.CENTER, italic=True, size=12, space_after=4)
add_p('- Đặc tả Usecase: Chuyển khoản nội bộ', bold=True, size=13, space_after=2)
add_p('+ Tác nhân: Khách hàng.', size=13, space_after=2)
add_p('+ Luồng sự kiện chính: Khách hàng nhập số tài khoản đích $\\rightarrow$ Hệ thống hiển thị tên người nhận $\\rightarrow$ Khách hàng nhập số tiền và xác nhận $\\rightarrow$ Server thực hiện Transaction kép trừ tiền người gửi và cộng tiền người nhận.', size=13, space_after=4)
add_p('Hình 2.2.8: Biểu đồ trình tự cho chức năng Chuyển khoản.', align=WD_ALIGN_PARAGRAPH.CENTER, italic=True, size=12, space_after=8)

# 2.2.5. Đổi mã PIN
add_p('2.2.5. Chức năng Đổi mã PIN.', bold=True, size=13, space_after=4)
add_p('Hình 2.2.9: Biểu đồ Use case chức năng Đổi mã PIN.', align=WD_ALIGN_PARAGRAPH.CENTER, italic=True, size=12, space_after=4)
add_p('- Đặc tả Usecase: Đổi mã PIN', bold=True, size=13, space_after=2)
add_p('+ Tác nhân: Khách hàng.', size=13, space_after=2)
add_p('+ Luồng sự kiện chính: Khách hàng nhập PIN cũ $\\rightarrow$ Nhập PIN mới 2 lần $\\rightarrow$ Hệ thống kiểm tra trùng khớp $\\rightarrow$ Cập nhật MaPIN mới vào bảng TheATM.', size=13, space_after=4)
add_p('Hình 2.2.10: Biểu đồ trình tự chức năng Đổi mã PIN.', align=WD_ALIGN_PARAGRAPH.CENTER, italic=True, size=12, space_after=8)

# 2.2.6. Xem lịch sử giao dịch
add_p('2.2.6. Chức năng Xem lịch sử giao dịch.', bold=True, size=13, space_after=4)
add_p('Hình 2.2.11: Biểu đồ use case chức năng Xem lịch sử giao dịch.', align=WD_ALIGN_PARAGRAPH.CENTER, italic=True, size=12, space_after=4)
add_p('- Đặc tả Usecase: Xem lịch sử giao dịch', bold=True, size=13, space_after=2)
add_p('+ Tác nhân: Khách hàng.', size=13, space_after=2)
add_p('+ Luồng sự kiện chính: Khách hàng chọn In sao kê / Xem lịch sử $\\rightarrow$ Server truy vấn bảng GiaoDich theo SoTaiKhoan $\\rightarrow$ Hiển thị danh sách các giao dịch gần nhất lên lưới dữ liệu.', size=13, space_after=4)
add_p('Hình 2.2.12: Biểu đồ trình tự chức năng Xem lịch sử giao dịch.', align=WD_ALIGN_PARAGRAPH.CENTER, italic=True, size=12, space_after=8)

# 2.2.7. Khóa thẻ tự động
add_p('2.2.7. Chức năng Khóa thẻ tự động.', bold=True, size=13, space_after=4)
add_p('Hình 2.2.13: Biểu đồ use case chức năng Khóa thẻ tự động.', align=WD_ALIGN_PARAGRAPH.CENTER, italic=True, size=12, space_after=4)
add_p('- Đặc tả Usecase: Khóa thẻ tự động khi sai PIN 3 lần', bold=True, size=13, space_after=2)
add_p('+ Tác nhân: Khách hàng / Hệ thống bảo mật.', size=13, space_after=2)
add_p('+ Luồng sự kiện chính: Mỗi lần nhập sai PIN, biến SoLanSaiPIN tăng 1. Khi đạt mốc 3, Server tự động gán IsLocked = 1 và thông báo khóa thẻ vĩnh viễn.', size=13, space_after=4)
add_p('Hình 2.2.14: Biểu đồ trình tự chức năng Khóa thẻ tự động.', align=WD_ALIGN_PARAGRAPH.CENTER, italic=True, size=12, space_after=8)

# 2.2.8. Tiếp quỹ máy ATM
add_p('2.2.8. Chức năng Quản lý máy ATM & Tiếp quỹ tiền mặt.', bold=True, size=13, space_after=4)
add_p('Hình 2.2.15: Biểu đồ use case chức năng Tiếp quỹ máy ATM.', align=WD_ALIGN_PARAGRAPH.CENTER, italic=True, size=12, space_after=4)
add_p('- Đặc tả Usecase: Tiếp quỹ máy ATM', bold=True, size=13, space_after=2)
add_p('+ Tác nhân: Kỹ thuật viên ATM / Quản trị viên.', size=13, space_after=2)
add_p('+ Luồng sự kiện chính: Kỹ thuật viên đăng nhập quyền quản trị $\\rightarrow$ Chọn cây ATM $\\rightarrow$ Nhập số lượng tờ nạp thêm vào từng khay (500k, 200k, 100k, 50k) $\\rightarrow$ Hệ thống cập nhật bảng KhayTienATM và tính lại tổng tiền mặt.', size=13, space_after=4)
add_p('Hình 2.2.16: Biểu đồ trình tự chức năng Tiếp quỹ máy ATM.', align=WD_ALIGN_PARAGRAPH.CENTER, italic=True, size=12, space_after=8)

# 2.3. Biểu đồ lớp
add_p('2.3. Biểu đồ lớp của hệ thống.', bold=True, size=13, space_after=4)
add_p('Hệ thống được thiết kế theo mô hình Hướng đối tượng phân tầng gồm 5 cụm: Nhóm Client - ATM (ThietBiATM, TheATM, SocketClient); Nhóm Truyền tải dữ liệu (YeuCauGiaoDich, PhanHoiGiaoDich); Nhóm Server & Đa luồng (BankServer, ClientHandler, BoXuLyGiaoDich, ConcurrencyLockManager); Nhóm Người dùng & Tài khoản (KhachHang, TaiKhoan); và Nhóm Lịch sử giao dịch (GiaoDich, GiaoDichRutTien, GiaoDichChuyenKhoan).', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=6, indent=True)
add_p('Hình 2.2.17: Biểu đồ lớp của hệ thống.', align=WD_ALIGN_PARAGRAPH.CENTER, italic=True, size=12, space_after=12)

doc.add_page_break()

# =============================================================
# CHƯƠNG 3: GIAO DIỆN SẢN PHẨM
# =============================================================
add_p('CHƯƠNG 3: GIAO DIỆN SẢN PHẨM', align=WD_ALIGN_PARAGRAPH.CENTER, bold=True, size=14, space_after=12)

giao_dien_list = [
    ("3.1. Giao diện trang đăng nhập.", "Hình 3.1: Giao diện trang đăng nhập."),
    ("3.2. Giao diện trang Menu chính.", "Hình 3.2. Giao diện trang Menu chính."),
    ("3.3. Giao diện trang vấn tin số dư.", "Hình 3.3. Giao diện trang vấn tin số dư."),
    ("3.4. Giao diện trang rút tiền mặt.", "Hình 3.4. Giao diện trang rút tiền mặt."),
    ("3.5. Giao diện trang chuyển khoản.", "Hình 3.5. Giao diện trang chuyển khoản."),
    ("3.6. Giao diện trang đổi mã PIN.", "Hình 3.6. Giao diện trang đổi mã PIN."),
    ("3.7. Giao diện trang xem lịch sử giao dịch.", "Hình 3.7. Giao diện trang xem lịch sử giao dịch."),
    ("3.8. Giao diện trang quản trị máy chủ Server Monitor.", "Hình 3.8. Giao diện trang quản trị máy chủ Server Monitor.")
]

for title, cap in giao_dien_list:
    add_p(title, bold=True, size=13, space_after=4)
    add_p(f'[Khung dán ảnh chụp thực tế màn hình ứng dụng: {cap}]', align=WD_ALIGN_PARAGRAPH.CENTER, italic=True, size=11, space_after=4)
    add_p(cap, align=WD_ALIGN_PARAGRAPH.CENTER, italic=True, size=12, space_after=14)

doc.add_page_break()

# =============================================================
# KẾT LUẬN & DANH MỤC TÀI LIỆU THAM KHẢO
# =============================================================
add_p('KẾT LUẬN.', align=WD_ALIGN_PARAGRAPH.CENTER, bold=True, size=14, space_after=12)

add_p('Sau quá trình học tập và thực hiện các bài tập cũng như dự án của môn Lập trình .NET, nhóm chúng em đã hoàn thành đề tài “Phát triển phần mềm Desktop Application để quản lý hệ thống giao dịch ngân hàng và mạng lưới ATM phân tán” và đạt được những mục tiêu đã đặt ra. Môn học không chỉ giúp chúng em nắm vững kiến thức về lập trình hướng đối tượng và kỹ thuật xây dựng ứng dụng trên nền tảng C#, mà còn tạo điều kiện để nhóm áp dụng những kiến thức đó vào một bài toán thực tế.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=6, indent=True)

add_p('Trong quá trình triển khai, nhóm đã tập trung nghiên cứu và phát triển phần mềm hỗ trợ hệ thống ngân hàng với các chức năng chính như xác thực thẻ ATM, vấn tin số dư, rút tiền mặt, chuyển khoản nội bộ, đổi mã PIN, và theo dõi nhật ký giao dịch. Các tính năng được xây dựng hướng đến mục tiêu nâng cao hiệu quả quản lý, mang lại giao diện thân thiện, dễ sử dụng và đáp ứng đúng nhu cầu nghiệp vụ thực tế. Ứng dụng hoạt động ổn định, sử dụng cơ sở dữ liệu quan hệ SQL Server 2022 để quản lý thông tin khách hàng, thẻ và khay tiền một cách khoa học, đảm bảo tốc độ truy xuất nhanh và độ chính xác cao. Đặc biệt, giải pháp khóa luồng tài khoản (Concurrency Lock) giúp giải quyết triệt để vấn đề rút tiền trùng lặp khi nhiều cây ATM cùng hoạt động.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=6, indent=True)

add_p('Tuy nhiên, do hạn chế về thời gian và kinh nghiệm, nhóm nhận thấy sản phẩm vẫn còn một số điểm cần hoàn thiện thêm, như mở rộng thêm các tính năng thanh toán hóa đơn tự động, tối ưu hóa thuật toán mã hóa giao thức mạng và tích hợp ứng dụng di động. Qua môn học này, nhóm chúng em đã học được nhiều bài học quý báu về quy trình phát triển phần mềm, kỹ năng làm việc nhóm, tư duy giải quyết vấn đề và lập trình chuyên nghiệp. Chúng em rất mong nhận được những ý kiến đóng góp từ thầy cô và bạn bè để tiếp tục cải thiện kỹ năng và nâng cao chất lượng sản phẩm. Nhóm em xin chân thành cảm ơn sự hướng dẫn tận tình của TS. Trần Trung và ThS. Vũ Thị Tân trong suốt quá trình học tập và thực hiện dự án.', align=WD_ALIGN_PARAGRAPH.JUSTIFY, size=13, space_after=16, indent=True)

add_p('DANH MỤC TÀI LIỆU THAM KHẢO.', align=WD_ALIGN_PARAGRAPH.CENTER, bold=True, size=14, space_after=12)
add_p('[1] Slide bài giảng môn Lập trình .NET, TS. Trần Trung, ThS. Vũ Thị Tân (2025).', size=13, space_after=4)
add_p('[2] Phương Lan, Hoàng Đức Hải (2022), Lập trình windows với C#.NET và SQL Server. NXB Lao động – Xã hội.', size=13, space_after=4)
add_p('[3] Microsoft Learn (2024), Socket Programming in C# and .NET Desktop Application Architecture. Microsoft Docs.', size=13, space_after=4)

# Lưu file kết quả
out_file = r'D:\BCNET\EPU_BankSystem\Docs\BAO_CAO_CHUAN_MAU_CO_TAN_EPU.docx'
doc.save(out_file)
print('Hoàn thành xuất file Word chuẩn 100% mẫu cô Tân tại:', out_file)
