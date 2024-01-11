using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Controlers
{
    internal class DefaultMessageControler
    {
        private readonly ITelegramBotClient _telegramClient;

        public DefaultMessageControler(ITelegramBotClient telegramClient)
        {
            _telegramClient = telegramClient;
        }

        public async Task Handle(Message message, CancellationToken ct)
        {
            Console.WriteLine($"Контроллер {GetType().Name} получил сообщение");
            await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"Получено сообщение не поддерживаемого формата", cancellationToken: ct);
        }

    }
}
