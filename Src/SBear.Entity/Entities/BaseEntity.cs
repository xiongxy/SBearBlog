using System;
using System.Collections.Generic;
using System.Text;

namespace SBear.Entity.Entities
{
    public abstract class TopBaseEntity
    {
        private Guid _id;
        public virtual Guid Id
        {
            get
            {
                if (_id == Guid.Empty)
                {
                    _id = Guid.NewGuid();
                }
                return _id;
            }
            set => _id = value;
        }
    }
    /// <summary>
    /// Entity 的基类，所有的entity对象都应该继承这个类，这样会使所有的Entity 对应的数据表都有一个主键
    /// </summary>
    public abstract class BaseEntity : TopBaseEntity
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string UpdateBy { get; set; }
    }
}
