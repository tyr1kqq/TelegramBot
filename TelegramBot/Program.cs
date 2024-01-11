using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using TelegramBot.Configuration;
using TelegramBot.Controlers;
using VoiceTexterBot.Controlers;
using VoiceTexterBot.Services;

namespace TelegramBot
{
    public class Program
    {
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            // Объект, отвечающий за постоянный жизненный цикл приложения
            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) => ConfigureServices(services)) // Задаем конфигурацию
                .UseConsoleLifetime() // Позволяет поддерживать приложение активным в консоли
                .Build(); // Собираем

            Console.WriteLine("Сервис запущен");
            // Запускаем сервис
            await host.RunAsync();
            Console.WriteLine("Сервис остановлен");


        }

        static AppSettings BuildAppSettings()
        {
            return new AppSettings()
            {
                BotToken = "6750819365:AAFd5bOCZ8AFvecbGSIeEusF4hfEVAmq_SM"
            };
        }


        static void ConfigureServices(IServiceCollection services)
        {

            AppSettings appSettings = BuildAppSettings();
            services.AddSingleton(BuildAppSettings());
            // Подключаем контроллеры сообщений и кнопок 
            services.AddTransient<DefaultMessageControler>();
            services.AddTransient<InlineKeyboardControler>();
            services.AddTransient<TextMessageController>();
            services.AddTransient<VoiceMessageControler>();

            services.AddSingleton<IStorage , MemoryStorage>();

            // Регистрируем объект TelegramBotClient c токеном подключения
            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient("6750819365:AAFd5bOCZ8AFvecbGSIeEusF4hfEVAmq_SM"));
            // Регистрируем постоянно активный сервис бота
            services.AddHostedService<Bot>();
        }
    }
}