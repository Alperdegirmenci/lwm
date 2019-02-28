using System;

namespace BWDS.Common
{
    [Serializable]
    public enum ResultCode : byte
    {
        /// <summary>
        /// Hiçbiri
        /// </summary>
        NONE = 0,

        /// <summary>
        /// Başarılı Login
        /// </summary>
        LOGIN_SUCCESS = 1,

        /// <summary>
        /// Başarısız Login
        /// </summary>
        LOGIN_FAILED = 2,

        /// <summary>
        /// Başarılı Public Login
        /// </summary>
        IDENTITY_VERIFICATION_SUCCESS = 3,

        /// <summary>
        /// Başarısız Public Login
        /// </summary>
        IDENTITY_VERIFICATION_FAILED = 4,

        /// <summary>
        /// Kullanıcı Bulunamadı
        /// </summary>
        USER_NOT_FOUND = 5,

        /// <summary>
        /// File Upload Başarılı
        /// </summary>
        FILE_UPLOAD_SUCCESS = 6,

        /// <summary>
        /// File Upload Başarısız
        /// </summary>
        FILE_UPLOAD_FAILED = 7,

        /// <summary>
        /// Kullanıcı Bulundu
        /// </summary>
        USER_FOUND = 8,

    }
}
