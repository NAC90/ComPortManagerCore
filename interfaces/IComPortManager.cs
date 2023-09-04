namespace ComPortManagerCore.interfaces
{
    /// <summary>
    /// Used to receive com port information for stream deck connection
    /// </summary>
    public interface IComPortManager
    {
        /// <summary>
        /// Get all available com prts used for stream deck connection
        /// </summary>
        IEnumerable<IComPortInfo> GetAvailableComPorts();
    }
}
