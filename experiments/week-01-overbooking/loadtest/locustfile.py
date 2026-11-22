
from locust import HttpUser, task
from gevent import sleep

class TicketBuyer(HttpUser):

    def on_start(self):
        # Mỗi người dùng ảo đặt vé đúng một lần
        with self.client.post(
            "/bookings",
            name="POST /bookings",
            catch_response=True
        ) as response:

            if response.status_code == 201:
                response.success()

            elif response.status_code == 409:
                # Hết vé là kết quả nghiệp vụ hợp lệ
                response.success()

            else:
                response.failure(
                    f"HTTP {response.status_code}"
                )

    @task
    def idle(self):
        # Giữ người dùng ảo hoạt động,
        # không gửi thêm yêu cầu mua vé
        sleep(60)
