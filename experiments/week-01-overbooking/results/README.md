# Kết quả kiểm thử Overbooking Tuần 1

Thư mục này lưu dữ liệu Locust để đối chiếu hai lần kiểm thử của thí nghiệm Overbooking Tuần 1.

- `failed-run/` lưu dữ liệu lần kiểm thử đầu tiên, thất bại do API chưa lắng nghe tại `127.0.0.1:5080`.
- `week1-retest_*.csv` là dữ liệu của lần kiểm thử lại đã tái hiện lỗi Overbooking.

PostgreSQL ghi nhận tổng 100 vé, đã bán 300 vé, vượt 200 vé. Số liệu PostgreSQL được ghi nhận riêng bằng truy vấn SQL và ảnh minh chứng. Các tệp CSV của Locust chỉ ghi thống kê yêu cầu HTTP.
