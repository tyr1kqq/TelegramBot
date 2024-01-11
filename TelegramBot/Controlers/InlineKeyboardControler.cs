﻿using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Controlers
{
    internal class InlineKeyboardControler
    {
        private readonly ITelegramBotClient _telegramClient;

        public InlineKeyboardControler(ITelegramBotClient telegramClient)
        {
            _telegramClient = telegramClient;
        }

        public async Task Handle(CallbackQuery? callbackQuery, CancellationToken ct)
        {
            Console.WriteLine($"Контроллер {GetType().Name} обнаружил нажатие на кнопку");

            await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id, $"Обнаружено нажатие на кнопку", cancellationToken: ct);
        }
    }
}
