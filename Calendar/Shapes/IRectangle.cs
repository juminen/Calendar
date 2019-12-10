namespace Calendar.Shapes
{
    interface IRectangle
    {
        double Height { get; }
        Coordinate TopLeftLocation { get;  }
        double Width { get;  }
    }
}