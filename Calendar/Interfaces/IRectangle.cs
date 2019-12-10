using Calendar.Model.Geometry;

namespace Calendar.Interfaces
{
    interface IRectangle
    {
        double Height { get; }
        double Width { get; }
        Coordinate TopLeftLocation { get; }
    }
}
