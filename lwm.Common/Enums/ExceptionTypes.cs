using System;

namespace BWDS.Common.Enums
{
    [Serializable]
    public enum ExceptionTypes : byte
    {
        /// <summary>
        /// Hiçbiri.
        /// </summary>
        None = 0,

        /// <summary>
        ///  Hata
        /// </summary>
        Exception = 1,

        /// <summary>
        /// Uyarı
        /// </summary>
        Warning = 2,

        /// <summary>
        /// Bilgi
        /// </summary>
        Information = 3,

        /// <summary>
        /// Onay
        /// </summary>
        Confirmation = 4
    }
}
