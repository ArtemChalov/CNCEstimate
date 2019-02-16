
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
        /// Primitive normalized length
        /// </summary>
        double NormalizedLength { get; set; }
        /// <summary>
        /// Length were the machine are braking to stop or change direction.
        /// </summary>
        double EdgeLength { get; set; }
        /// <summary>
        /// Сoeffiсient used to calculate the normalized length
        /// </summary>
        double BrakeCoefficient { get; set; }
        /// <summary>
        /// Some coeffiсient
        /// </summary>
        double Coeff { get; set; }
    }
}
