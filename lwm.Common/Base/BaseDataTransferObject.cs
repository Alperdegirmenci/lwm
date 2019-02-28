using System;
using lwm.Common.Interfaces;
using System.Reflection;
using System.Runtime.Serialization;

namespace lwm.Common.Base
{

    /// <summary>
    ///
    /// </summary>
    [DataContract]
    [Serializable]
    public class BaseDataTransferObject : IDataTransferObject
    {
        #region Private Members

        private string _recordUserCode;
        private DateTime _recordDate;
        private int _resultCode;
        private string _resultMessage;

        #endregion Private Members

        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string RecordUserCode
        {
            get { return _recordUserCode; }
            set
            {
                if (_recordUserCode != value)
                {
                    _recordUserCode = value;
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime RecordDate
        {
            get { return _recordDate; }
            set
            {
                if (_recordDate != value)
                {
                    _recordDate = value;
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int ResultCode
        {
            get { return _resultCode; }
            set
            {
                if (_resultCode != value)
                {
                    _resultCode = value;
                }
            }
        }


        /// <summary>
        ///
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string ResultMessage
        {
            get { return _resultMessage; }
            set
            {
                if (_resultMessage != value)
                {
                    _resultMessage = value;
                }
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="source"></param>
        public void FillBaseProperties(BaseDataTransferObject source)
        {
            RecordDate = source.RecordDate;
            RecordUserCode = source.RecordUserCode;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public override bool Equals(object dto)
        {
            return compare(dto, false);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="includeInheritedProperties"></param>
        /// <returns></returns>
        public bool Equals(object dto, bool includeInheritedProperties)
        {
            return compare(dto, includeInheritedProperties);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public BaseDataTransferObject Copy()
        {
            BaseDataTransferObject result = new BaseDataTransferObject();
            result.FillBaseProperties(this);
            return result;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="includeInheritedProperties"></param>
        /// <returns></returns>
        private bool compare(object dto, bool includeInheritedProperties)
        {
            if (dto == null || dto.GetType() != this.GetType()) return false;

            PropertyInfo[] properties = null;
            if (includeInheritedProperties)
            {
                properties = (dto.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public));
            }
            else
            {
                properties = (dto.GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public));
            }

            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo propertyInfo = properties[i];
                object propValue = null;
                object thisValue = null;
                try
                {
                    propValue = propertyInfo.GetValue(dto, null);
                    thisValue = this.GetType().GetProperty(propertyInfo.Name).GetValue(this, null);
                }
                catch (TargetParameterCountException)
                {
                    propValue = propertyInfo.GetValue(dto, new object[] { null });
                    thisValue = this.GetType().GetProperty(propertyInfo.Name).GetValue(this, new object[] { null });
                }

                if (!(Convert.ToString(propValue).Equals(Convert.ToString(thisValue))))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        /// TODO: Hashcode
        public override int GetHashCode()
        {
            return 1;
        }

        #endregion Private Methods
    }
}
