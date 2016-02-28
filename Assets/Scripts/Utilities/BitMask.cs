
public static class BitMask
{
    /// <summary>
    /// Check if a layer mask contains a layer.
    /// </summary>
    /// <param name="mask">A layer mask</param>
    /// <param name="layer">Layer to check</param>
    /// <returns>True if the mask contains the layer</returns>
    public static bool Contains(int mask, int layer)
    {
        return (((mask >> layer) & 1) == 1);
    }
}
