using System;
using Microsoft.Extensions.DependencyInjection;
using TicTacToe.Interfaces;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IPlayerRepository, PlayerRepository>()
                .AddSingleton<IGame, Game>()
                .AddSingleton<IBoard, GameBoard>()
                .AddSingleton<PlayerForX>()
                .AddSingleton<PlayerForO>()
                .AddTransient<Func<string, IPlayer>>(serviceProvider => key =>
                {
                    return key switch
                    {
                        "PlayerX" => serviceProvider.GetService<PlayerForX>(),
                        "PlayerO" => serviceProvider.GetService<PlayerForO>(),
                        _ => serviceProvider.GetService<PlayerForX>(),
                    };
                })
                .BuildServiceProvider();

            var game = new Game(serviceProvider.GetService<IBoard>(), serviceProvider.GetService<IPlayerRepository>());
            game.Play();
        }
    }
}
