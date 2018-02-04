namespace Autofixture.Tutorial
{
    public struct ImmutablePoint
    {
        public ImmutablePoint(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X { get; }
        public float Y { get; }
    }
}