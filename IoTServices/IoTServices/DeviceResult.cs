using System;

namespace IoTServices
{
    public class DeviceResult
    {
        public string IDTessera { get; set; }
        public string IDGateway { get; set; }
        public string Response { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Status { get; set; }
    }

    public class SwipeInput
    {
        public string IDTessera { get; set; }
        public string IDGateway { get; set; }
    }
}
