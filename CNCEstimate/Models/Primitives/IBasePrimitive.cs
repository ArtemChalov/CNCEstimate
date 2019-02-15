
namespace Primitives
{
    /// <summary>
    /// Base to Primives objects
    /// </summary>
    public interface IBasePrimitive
    {
        /// <summary>
        /// Primitive tag
        /// </summary>
        string Tag {get;}
        /// <summary>
        /// Primitive Length
        /// </summary>
        double Length { get; set; }
        /// <summary>
        /// Сoeffiсient 1
        /// </summary>
        double A { get; set; }
        /// <summary>
        /// Сoeffiсient 2
        /// </summary>
        double B { get; set; }
        /// <summary>
        /// Cutting speed in millimeter per minute
        /// </summary>
        double Speed { get; set; }
        /// <summary>
        /// The time spend to cut process
        /// </summary>
        double Time { get; }
    }
}
