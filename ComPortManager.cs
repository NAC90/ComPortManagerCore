using System.Management;
using System.IO.Ports;
using ComPortManagerCore.interfaces;
using ComPortManagerCore.data;

namespace ComPortManagerCore
{
    /// <summary>
    /// <inheritdoc cref="IComPortManager"/>
    /// </summary>
    public class ComPortManager : IComPortManager
    {
        /// <summary>
        /// <inheritdoc cref="IComPortManager.GetAvailableComPorts"/>
        /// </summary>
        public IEnumerable<IComPortInfo> GetAvailableComPorts()
        {
            Dictionary<string, string> ports = GetArduinoComPorts();
            var comPorts = new List<IComPortInfo>();

            foreach (var p in ports)
            {
                comPorts.Add(new PortInfo(p.Value, p.Key));
            }
            return comPorts;
        }

        #region private fucntions

        private static Dictionary<string, string> GetArduinoComPorts()
        {
            var ports = new Dictionary<string, string>();
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption like '%(COM%'"))
            {
                try
                {
                    var portnames = SerialPort.GetPortNames();
                    var captions = searcher.Get().Cast<ManagementBaseObject>().ToList().Select(p => p["Caption"].ToString());
                    foreach (var (caption, port) in
                        from string caption in captions
                        let port = portnames.FirstOrDefault(p => caption.Contains($"({p})"))
                        select (caption, port))
                    {
                        ports.Add(port, caption.Replace($"({port})", ""));
                    }
                }
                catch { }
            }
            return ports;
        }

        #endregion
    }
}
