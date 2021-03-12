using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleAppSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            int menu = 0;
            do
            {
                global::System.Console.WriteLine("1-Task");
                global::System.Console.WriteLine("2-Task");
                global::System.Console.WriteLine("3-Task");
                Console.WriteLine("0-EXIT");
                Console.Write(">>");
                Int32.TryParse(Console.ReadLine(), out menu);




                switch (menu)
                {
//                    Задание №1
//Создать объект точки подключения. Вывести следующую информацию: IPи
//порт, тип сети, порт.
//The IPEndPoint is: 192.168.1.1:8000
//The AddressFamily is: InterNetwork
//The address is: 192.168.1.1, and the port is: 8000
                    case 1:
                        {
                            IPAddress iPAddress = IPAddress.Parse("212.42.76.252");
                            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 80);
                            Socket socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.IP);

                            try
                            {
                                socket.Connect(iPEndPoint);
                                Console.WriteLine($"The IPEndPoint : {iPEndPoint.Address.ToString()}");
                                Console.WriteLine($"The AdressFamily is : {socket.AddressFamily}");
                                Console.WriteLine($"The adress is : {iPAddress}, and the port is: {iPEndPoint}");
                                Console.WriteLine();
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            finally
                            {
                                socket.Shutdown(SocketShutdown.Both);
                                socket.Close();
                            }

                            


                        }break;

//                        Задание №2
//Вывести на экран список всех адресов домена microsoft.com.
                    case 2:
                        {
                            IPAddress[] addresses= Dns.GetHostAddresses("microsoft.com");
                            Console.WriteLine("List of adress microsoft.com");
                            foreach (IPAddress address  in addresses)
                            {
                                Console.WriteLine($"{address}");
                            }
                        }break;

//                        Задание №3
//С использованием класса Socket напишите клиентское приложение.
//Используя разработанное приложение, оправьте GET-запрос на шлюз по
//умолчанию вашей сети и отобразите в консоли возвращенный результат.

                    case 3:
                        {
                            IPAddress address = IPAddress.Loopback ;
                            IPEndPoint iPEndPoint = new IPEndPoint(address, 1024);
                            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                            socket.Bind(iPEndPoint);
                            socket.Listen(15);




                            Console.WriteLine("Server started at port 1024");
                            try
                            {
                                while (true)
                                {
                                    Socket ns = socket.Accept();
                                    ns.Send(Encoding.ASCII.GetBytes($"Server {ns.LocalEndPoint} send answer Hello World"));
                                    Console.WriteLine($"Создан новый сокет {ns.LocalEndPoint}");
                                    Console.WriteLine($"К нам подключился клиент {ns.RemoteEndPoint}");
                                   
                                    ns.Shutdown(SocketShutdown.Both);
                                    ns.Close();
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }


                            Console.WriteLine(address);

                        }
                        break;

                }


            } while (menu!=0);
        }
    }
}
