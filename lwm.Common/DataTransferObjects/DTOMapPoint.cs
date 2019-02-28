using lwm.Common.Base;
using lwm.Common.Interfaces;
using System.Runtime.Serialization;

namespace lwm.Common
{
    public class DTOMapPoint : BaseDataTransferObject, IDataTransferObject
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public decimal Lon { get; set; }
        [DataMember]
        public decimal Lat { get; set; }
        [DataMember]
        public int Type { get; set; }
        [DataMember]
        public int Timeout { get; set; }
    }
}
