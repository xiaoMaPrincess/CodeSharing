using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQ
{
    class Program
    {
        static void Main(string[] args)
        {

            ////创建连接工厂  生产者
            //ConnectionFactory factory = new ConnectionFactory
            //{
            //    UserName = "admin",//用户名
            //    Password = "Princess",//密码
            //    HostName = "127.0.0.1"//rabbitmq ip
            //};
            //// 创建连接
            //var connection = factory.CreateConnection();
            ////创建队列
            //var channel = connection.CreateModel();
            ////声明一个队列
            //channel.QueueDeclare("hello", false, false, false, null);
            //Console.WriteLine("\nRabbitMQ连接成功!");
            //var sendBytes = Encoding.UTF8.GetBytes("hello world");
            ////发布消息
            //channel.BasicPublish("", "hello", null, sendBytes);


            //channel.Close();
            //connection.Close();


            //创建连接工厂  生产者
            ConnectionFactory factory2 = new ConnectionFactory
            {
                UserName = "admin",//用户名
                Password = "Princess",//密码
                HostName = "127.0.0.1"//rabbitmq ip
            };


            //创建连接
            var connection2 = factory2.CreateConnection();
            //创建通道
            var channel2 = connection2.CreateModel();

            //事件基本消费者
            EventingBasicConsumer consumer = new EventingBasicConsumer(channel2);

            //接收到消息事件
            consumer.Received += (ch, ea) =>
            {
                var message = Encoding.UTF8.GetString(ea.Body);
                Console.WriteLine($"收到消息： {message}");
                //确认该消息已被消费
                channel2.BasicAck(ea.DeliveryTag, false);
            };
            //启动消费者 设置为手动应答消息
            channel2.BasicConsume("hello", false, consumer);
            Console.WriteLine("消费者已启动");
            Console.ReadKey();
            channel2.Dispose();
            connection2.Close();

            Console.ReadKey();
            Console.WriteLine("Hello World!");
        }
    }
}
