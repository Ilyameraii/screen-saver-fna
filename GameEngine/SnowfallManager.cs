using System.Drawing;

namespace GameEngine
{
    internal class SnowfallManager
    {
        /// <summary>
        /// Количество снежинок
        /// </summary>
        private const int AmountOfSnowflakes = 1500;

        /// <summary>
        /// Коэффициент скорости движения снежинок
        /// </summary>
        private const float SpeedCoefficient = 0.1f;

        /// <summary>
        /// Минимальный размер снежинки
        /// </summary>
        private const int MinSnowflakeSize = 10;

        /// <summary>
        /// Максимальный размер снежинки
        /// </summary>
        private const int MaxSnowflakeSize = 30;

        private readonly int screenWidth;
        private readonly int screenHeight;

        private readonly Random random = new Random();

        public SnowfallManager(int screenWidth, int screenHeight)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            CreateSnowFlakes();
        }
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
