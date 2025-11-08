namespace GameEngine.Models;

/// <summary>
/// Модель снежинки
/// </summary>
internal class Snowflake
{
    /// <summary>
    /// Свойство положения снежинки по x
    /// </summary>
    public float X { get; set; }

    /// <summary>
    /// Свойство положения снежинки по y
    /// </summary>
    public float Y { get; set; }

    /// <summary>
    /// Свойство длины стороны снежинки
    /// </summary> 
    public int Size { get; set; }
}