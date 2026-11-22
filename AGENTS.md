
# AGENTS.md – QUY TẮC LÀM VIỆC CỦA CODEX

## 1. Thông tin dự án

Tên đề tài:
Xây dựng nền tảng quản lý và đặt vé sự kiện trực tuyến
tích hợp các chức năng AI hỗ trợ người dùng và nhà tổ chức.

Đây là đồ án tốt nghiệp ngành Công nghệ phần mềm.

Dự án thực hiện theo đề cương chi tiết của giảng viên
hướng dẫn, với kế hoạch gồm 10 tuần.

Mục tiêu của Codex là hỗ trợ phân tích, lập trình, kiểm thử
và quản lý mã nguồn theo đúng yêu cầu được giao.

## 2. Nguyên tắc ưu tiên

1. Đề cương của giảng viên là nguồn yêu cầu chính.
2. Không tự ý thay đổi phạm vi, công nghệ hoặc chức năng.
3. Nếu yêu cầu chưa rõ, phải báo cáo điểm chưa rõ.
4. Không tự thêm chức năng ngoài đề cương.
5. Không xây dựng toàn bộ hệ thống khi chỉ được giao
   một nhiệm vụ nhỏ.
6. Không tự quyết định thay người dùng đối với những
   thay đổi lớn về kiến trúc hoặc dữ liệu.
7. Nếu không tìm thấy đề cương trong repository,
   phải báo cho người dùng và yêu cầu chỉ rõ tài liệu.

## 3. Quy tắc thực hiện theo tiến độ

Dự án thực hiện theo kế hoạch 10 tuần của giảng viên.

- Chỉ thực hiện nhiệm vụ thuộc tuần hoặc giai đoạn
  người dùng đang yêu cầu.
- Không tự triển khai nội dung của các tuần tiếp theo.
- Có thể phân tích sự phụ thuộc giữa các tuần,
  nhưng không tự triển khai trước.
- Mỗi nhiệm vụ cần có sản phẩm đầu ra và cách kiểm tra.
- Khi chuyển sang tuần mới, phải đối chiếu lại đề cương.

GIAI ĐOẠN HIỆN TẠI: TUẦN 1.

Các công việc Tuần 1:
- Tìm hiểu nghiệp vụ đặt vé và lỗi Overbooking.
- Khảo sát ít nhất 3 hệ thống bán vé thực tế.
- Khảo sát ít nhất 20 người từng mua vé.
- Vẽ BPMN cho hai quy trình nghiệp vụ.
- Thí nghiệm Overbooking bằng ASP.NET Core,
  PostgreSQL và Locust.
- Thử mô hình AI nhỏ bằng Ollama, đo tốc độ phản hồi.
- Quản lý kết quả bằng Git.

Các công việc Tuần 2–10 chỉ thực hiện khi người dùng
giao nhiệm vụ tương ứng.

## 4. Công nghệ theo đề cương

Backend:
- C# và ASP.NET Core (.NET 10).
- Entity Framework Core, Npgsql.

Frontend:
- React, TypeScript, Vite.

Cơ sở dữ liệu:
- PostgreSQL 16.
- pgvector cho dữ liệu vector.
- Redis kết hợp Lua script.
- Apache Kafka.

Kiến trúc:
- Microservices.
- API Gateway sử dụng YARP.

AI:
- Ollama chạy cục bộ.
- Mô hình ngôn ngữ nhỏ.
- RAG, gợi ý sự kiện và ML.NET.

Triển khai:
- Docker Compose cho môi trường phát triển.
- Kubernetes cục bộ ở giai đoạn triển khai, kiểm thử.

Kiểm thử:
- Locust.
- xUnit.

Không tự thay thế công nghệ đã chốt nếu chưa được
người dùng cho phép.

## 5. Quy tắc sử dụng Docker và tài nguyên

Máy phát triển sử dụng Windows và có giới hạn
về dung lượng ổ đĩa, RAM và CPU.

BẮT BUỘC:

1. Không tự động tạo hoặc khởi động toàn bộ hệ thống.
2. Không tự bật Kubernetes khi chưa được yêu cầu.
3. Không tự tải các mô hình Ollama dung lượng lớn.
4. Không tự build hàng loạt Docker images.
5. Không tự tạo nhiều database hoặc container
   không phục vụ nhiệm vụ hiện tại.
6. Ưu tiên chạy các thành phần tối thiểu cần thiết.
7. Trước khi tải image/model hoặc thực hiện thao tác
   tốn nhiều dung lượng, phải báo rõ mục đích,
   dung lượng dự kiến và xin phép.
8. Không tự ý chạy docker system prune,
   docker volume prune hoặc lệnh xóa dữ liệu Docker.
9. Không tự xóa Docker volumes, images hoặc database.
10. Khi sử dụng Docker Compose, chỉ khởi động
    những dịch vụ cần thiết.

Ollama ưu tiên chạy ngoài Kubernetes theo đề cương.

## 6. Quy tắc chỉnh sửa mã nguồn

Trước khi sửa code:
- Đọc các file liên quan.
- Xác định chức năng đang được yêu cầu.
- Kiểm tra những phần đã triển khai.
- Tránh tạo file hoặc module trùng lặp.

Trong khi sửa:
- Chỉ chỉnh sửa những file thuộc phạm vi nhiệm vụ.
- Không tự ý refactor toàn bộ project.
- Không xóa chức năng đang hoạt động.
- Không làm thay đổi API ngoài phạm vi yêu cầu.
- Giữ cấu trúc dự án rõ ràng.
- Viết code dễ đọc, dễ giải thích khi bảo vệ đồ án.

Sau khi sửa:
- Kiểm tra lỗi build hoặc syntax khi phù hợp.
- Chạy những bài test cần thiết và an toàn.
- Báo cáo file nào đã thay đổi.
- Báo cáo những phần chưa kiểm thử được.
- Không tự khẳng định chức năng hoạt động tốt
  nếu chưa có bằng chứng kiểm chứng.

## 7. Quy tắc bảo vệ dữ liệu thực nghiệm

Dữ liệu khảo sát, kết quả kiểm thử và minh chứng
là tài liệu phục vụ đồ án tốt nghiệp.

- Không tự xóa file CSV, kết quả kiểm thử hoặc báo cáo.
- Không tự sửa số liệu thực nghiệm.
- Không tự tạo số liệu giả rồi trình bày là số liệu thật.
- Không ghi đè kết quả của những lần kiểm thử trước.
- Không reset PostgreSQL nếu chưa được cho phép.
- Giữ lại lịch sử thí nghiệm khi cần.
- Khi phân tích kết quả phải phân biệt dữ liệu thực tế
  với ví dụ minh họa.

Đối với thí nghiệm Overbooking Tuần 1:
- Đây là API cố ý có Race Condition.
- Không tự sửa lỗi Race Condition khi chưa được yêu cầu.
- Không tự thay thế bằng Redis hoặc Kafka.
- Không làm mất dữ liệu và minh chứng của thí nghiệm.

## 8. Quy tắc tài liệu và báo cáo

- Tài liệu phân tích và khảo sát ưu tiên định dạng Word.
- Sơ đồ nghiệp vụ, UML, ERD ưu tiên dùng draw.io.
- Mã nguồn được quản lý trong VS Code.
- Có thể sử dụng Markdown cho README và hướng dẫn kỹ thuật.
- Không bắt buộc chuyển tài liệu Word sang Markdown.
- Báo cáo phải bám sát dữ liệu và yêu cầu thực tế.
- Không đưa ra kết luận thiết kế trước giai đoạn tương ứng.
- Không tự tạo thông tin khảo sát hoặc nguồn tham khảo.

## 9. Quy tắc Git và GitHub

- Sử dụng Git để quản lý phiên bản.
- Tuân thủ quy tắc commit và tag theo tuần của đề cương.
- Không tự động commit, push hoặc tạo tag.
- Chỉ thực hiện các thao tác trên khi người dùng yêu cầu.
- Không sử dụng git reset --hard hoặc git clean -fd
  khi chưa được phê duyệt.
- Không tự ghi đè các thay đổi chưa commit.
- Không commit file .env, mật khẩu, token hoặc API key.
- Không commit dữ liệu cá nhân nhạy cảm,
  thư mục build hay mô hình AI dung lượng lớn.

## 10. Quy trình làm việc bắt buộc

Khi nhận nhiệm vụ mới:

Bước 1: Đọc yêu cầu người dùng và phần đề cương liên quan.

Bước 2: Kiểm tra tình trạng các file có liên quan.

Bước 3: Trình bày ngắn gọn:
- Mục tiêu cần thực hiện.
- Những file dự kiến thay đổi.
- Cách thực hiện.
- Cách kiểm tra kết quả.

Bước 4: Thực hiện nhiệm vụ trong phạm vi được giao.

Bước 5: Kiểm tra kết quả.

Bước 6: Báo cáo bằng tiếng Việt:
- Đã làm gì?
- Đã thay đổi file nào?
- Đã kiểm tra những gì?
- Kết quả ra sao?
- Còn vấn đề gì chưa hoàn thành?

Với thay đổi lớn, phá hủy dữ liệu hoặc tốn nhiều
tài nguyên, phải xin phép trước khi thực hiện.

## 11. Quy tắc giao tiếp

- Luôn giải thích bằng tiếng Việt dễ hiểu.
- Người dùng đang học các công nghệ trong đề cương.
- Giải thích lý do sử dụng công nghệ khi cần.
- Không chỉ đưa code mà không giải thích chức năng.
- Không tự ý mở rộng nhiệm vụ.
- Ưu tiên giải pháp đơn giản và đúng yêu cầu.
- Khi phát hiện lỗi, phân tích nguyên nhân trước
  khi chỉnh sửa.
- Nếu chưa chắc chắn, phải nói rõ mức độ không chắc chắn.

## 12. Bảo vệ file quy tắc

- Không tự chỉnh sửa AGENTS.md.
- Không tự thay đổi đề cương của giảng viên.
- Chỉ cập nhật quy tắc khi người dùng yêu cầu.
