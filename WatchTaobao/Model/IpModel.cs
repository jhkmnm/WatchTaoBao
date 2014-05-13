using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchTaobao.Model
{
    /// <summary>
    /// Ip:实体类
    /// </summary>
    [Serializable]
    public partial class IpModel
    {
        public IpModel()
        { }
        #region Model
        private int _id;
        private string _ip;
        private string _ipport;
        private int? _isuse;
        private int? _iptype;

        /// <summary>
        /// 已经使用的次数
        /// </summary>
        public int UsedNumber { get; set; }

        public int DaiLiType { get; set; }

        /// <summary>
        /// 最后使用时间
        /// </summary>
        public DateTime LastUseTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// Ip地址
        /// </summary>
        public string Ip
        {
            set { _ip = value; }
            get { return _ip; }
        }
        /// <summary>
        /// Ip端口
        /// </summary>
        public string IpPort
        {
            set { _ipport = value; }
            get { return _ipport; }
        }
        /// <summary>
        /// ip地址是否可用
        /// </summary>
        public int? IsUse
        {
            set { _isuse = value; }
            get { return _isuse; }
        }
        /// <summary>
        /// 代理IP的类型1：国内 2：国外
        /// </summary>
        public int? IpType
        {
            set { _iptype = value; }
            get { return _iptype; }
        }
        #endregion Model
    }

    public class IpUrl
    {
        public int ID { get; set; }
        public string Url { get; set; }

        public int DaiLi { get; set; }

    }
}
