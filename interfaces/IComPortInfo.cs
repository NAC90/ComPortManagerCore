namespace ComPortManagerCore.interfaces
{
    /// <summary>
    /// Used to store com port information
    /// </summary>
    public interface IComPortInfo
    {
        /// <summary>
        /// The name of the com port
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The unique name of the com port
        /// </summary>
        string UniqueName { get; }

        /// <summary>
        /// The port number
        /// </summary>
        string Port { get; }
    }
}
