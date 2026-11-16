using System;
using System.Net.Sockets;
using System.Text;

namespace Bank.Client
{
    /// <summary>
    /// Lớp chuyên trách gửi/nhận gói tin Socket TCP từ cây ATM lên Server Ngân hàng
    /// </summary>
    public static class AtmClientSocket
    {
        // Địa chỉ IP của Server (127.0.0.1 nếu chạy cùng máy, hoặc IP Radmin VPN khi chạy khác máy)
        public static string ServerIp = "127.0.0.1";
        public static int ServerPort = 8888;

        /// <summary>
        /// Gửi một gói lệnh lên Server và nhận chuỗi phản hồi về
        /// </summary>
        public static string SendCommand(string command)
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    // Chờ kết nối tối đa 3 giây, nếu quá thời gian thì báo lỗi
                    var result = client.BeginConnect(ServerIp, ServerPort, null, null);
                    bool success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(3));

                    if (!success || !client.Connected)
                    {
                        return "ERROR|Không thể kết nối tới Server Ngân hàng! Vui lòng kiểm tra Server đã bật chưa.";
                    }

                    client.EndConnect(result);

                    // 1. Gửi lệnh đi (mã hóa UTF-8 tiếng Việt)
                    NetworkStream stream = client.GetStream();
                    byte[] data = Encoding.UTF8.GetBytes(command);
                    stream.Write(data, 0, data.Length);

                    // 2. Chờ Server phản hồi kết quả về
                    byte[] buffer = new byte[2048];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    if (bytesRead > 0)
                    {
                        return Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    }
                    else
                    {
                        return "ERROR|Server không trả về dữ liệu!";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"ERROR|Lỗi kết nối Socket: {ex.Message}";
            }
        }

        /// <summary>
        /// Gửi gói tin ĐĂNG KÝ cây ATM với Server
        /// </summary>
        public static (bool Success, string Status) RegisterAtm(string atmId, string name)
        {
            string resp = SendCommand($"REGISTER_ATM|{atmId}|{name}");
            string[] parts = resp.Split('|');
            if (parts[0] == "REGISTER_SUCCESS")
            {
                string status = parts.Length > 2 ? parts[2] : "Online";
                return (true, status);
            }
            return (false, "Offline");
        }

        /// <summary>
        /// Gửi nhịp tim (Heartbeat) định kỳ lên Server
        /// </summary>
        public static (bool Connected, bool IsMaintenance) SendHeartbeat(string atmId)
        {
            string resp = SendCommand($"HEARTBEAT|{atmId}");
            string[] parts = resp.Split('|');

            if (parts[0] == "HEARTBEAT_ACK")
            {
                bool isMaint = parts.Length > 2 && parts[2] == "MAINTENANCE";
                return (true, isMaint);
            }
            return (false, false);
        }
    }
}
