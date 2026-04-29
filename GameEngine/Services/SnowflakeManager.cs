using GameEngine.Models;

namespace GameEngine.Services
{
    /// <summary>
    /// Менеджер, содержащий логику создания и движеия снежинок
    /// </summary>
    internal class SnowflakeManager
    {
        // Количество снежинок
        private const int AmountOfSnowflakes = 1500;

        // Коэффициент скорости движения снежинок
        private const float SpeedCoefficient = 0.1f;

        // Минимальный размер снежинки
        private const int MinSnowflakeSize = 5;

        // Максимальный размер снежинки
        private const int MaxSnowflakeSize = 15;

        private readonly int screenWidth;
        private readonly int screenHeight;

        private readonly Random random = new Random();

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="screenWidth">Длина экрана игры</param>
        /// <param name="screenHeight">Ширина экрана игры</param>
        public SnowflakeManager(int screenWidth, int screenHeight)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            CreateSnowFlakes();
        }

        /// <summary>
        /// Список снежинок
        /// </summary>
        public List<Snowflake> Snowflakes { get; private set; } = new();

        private void CreateSnowFlakes()
        {
            for (var i = 0; i < AmountOfSnowflakes; i++)
            {
                var snowflake = new Snowflake
                {
                    Size = random.Next(MinSnowflakeSize, MaxSnowflakeSize),

                };
                snowflake.X = random.Next(-snowflake.Size, screenWidth + snowflake.Size);
                snowflake.Y = random.Next(-screenHeight - snowflake.Size, -snowflake.Size);
                Snowflakes.Add(snowflake);
            }
        }

        /// <summary>
        /// Фрейм действия игры, который отвечает за падание снежинок
        /// </summary>
        public void Update()
        {
            foreach (var snowflake in Snowflakes)
            {
                snowflake.Y += snowflake.Size * SpeedCoefficient;
                if (snowflake.Y > screenHeight + snowflake.Size)
                {
                    snowflake.Y = -snowflake.Size;
                    snowflake.X = random.Next(-snowflake.Size, screenWidth + snowflake.Size);
                }
            }
        }
    }
}
