using System;

namespace BWDS.Common.Enums
{
    [Serializable]
    public enum TraceEventCategories : int
    {
        /// <summary>
        ///
        /// </summary>
        None = 0,

        /// <summary>
        ///  DAL SP Çağrımı
        /// </summary>
        DALSPC = 1,

        /// <summary>
        ///  DAL Catch Exception
        /// </summary>
        DALCEX = 2,

        /// <summary>
        ///  TileRequest
        /// </summary>
        TILEREQ = 1001,

        /// <summary>
        ///  TileRequest
        /// </summary>
        TILECRT = 1001,

        /// <summary>
        /// Do
        /// </summary>
        MAPDO = 2001,

        /// <summary>
        ///  EVAL
        /// </summary>
        MAPEVAL = 2002,

        /// <summary>
        ///  Eski SP Çağrımı
        /// </summary>
        OLDSPC = 3001,

        /// <summary>
        ///  Eski Catch Exception
        /// </summary>
        OLDCEX = 3002,

        /// <summary>
        ///  Eski SQL çağırma
        /// </summary>
        OLDSQL = 3003,

        /// <summary>
        ///  Datatable
        /// </summary>
        OLDDTB = 3004,

        /// <summary>
        ///
        /// </summary>
        UICOM = 3005,

        /// <summary>
        ///
        /// </summary>
        UIACTION = 3006,

        /// <summary>
        ///
        /// </summary>
        HOSTIIS = 3007,

        /// <summary>
        ///
        /// </summary>
        SRVCALL = 3008,

        /// <summary>
        ///
        /// </summary>
        SRVEX = 3009,

        /// <summary>
        ///
        /// </summary>
        ATTGET = 3010,

        /// <summary>
        ///
        /// </summary>
        ATTADD = 3011,

        /// <summary>
        ///
        /// </summary>
        ATTDEL = 3012,

        /// <summary>
        ///
        /// </summary>
        RESGET = 3013,

        /// <summary>
        ///
        /// </summary>
        RESADD = 3014,

        /// <summary>
        ///
        /// </summary>
        RESDEL = 3015,

        /// <summary>
        ///
        /// </summary>
        SRVREQ = 3016,

        /// <summary>
        ///
        /// </summary>
        SRVRES = 3017,

        /// <summary>
        ///
        /// </summary>
        COMEX = 3018,

        /// <summary>
        ///
        /// </summary>
        DALPAR = 3019,

        /// <summary>
        ///
        /// </summary>
        OLDPAR = 3020,

        /// <summary>
        /// MAPCEX
        /// </summary>
        MAPCEX = 3021,

        /// <summary>
        /// OLDLOG
        /// </summary>
        OLDLOG = 3022,

        /// <summary>
        ///
        /// </summary>
        LOADTST = 3023,

        /// <summary>
        ///
        /// </summary>
        WEBEX = 4000,

        /// <summary>
        ///
        /// </summary>
        WEBREQ = 4001,

        /// <summary>
        ///
        /// </summary>
        WEBRES = 4002,

        /// <summary>
        ///
        /// </summary>
        WEBCALL = 4003,

        /// <summary>
        ///
        /// </summary>
        APICALL = 5000,

        /// <summary>
        ///
        /// </summary>
        APIRES = 5001,

        /// <summary>
        ///
        /// </summary>
        APIEX = 5002,

        /// <summary>
        ///
        /// </summary>
        APIREQ = 5003,

        /// <summary>
        ///
        /// </summary>
        APILOGIN = 5004


    }
}
