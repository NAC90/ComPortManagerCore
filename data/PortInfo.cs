using ComPortManagerCore.interfaces;

namespace ComPortManagerCore.data
{
    /// <summary>
    /// <inheritdoc cref="IComPortInfo"/>
    /// </summary>
    public class PortInfo : IComPortInfo
    {
        /// <summary>
        /// Bastic constructor for PortInfo class
        /// </summary>
        /// <param name="name">the name of the port</param>
        /// <param name="port">the port to connect</param>
        public PortInfo(string name, string port)
        {
            Name = name;
            Port = port;
            UniqueName = $"{Name}_{Port}";
        }

        /// <summary>
        /// <inheritdoc cref="IComPortInfo.Name"/>
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// <inheritdoc cref="IComPortInfo.UniqueName"/>
        /// </summary>
        public string UniqueName { get; }

        /// <summary>
        /// <inheritdoc cref="IComPortInfo.Port"/>
        /// </summary>
        public string Port { get; }

    }
}
