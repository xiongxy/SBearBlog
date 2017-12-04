using System;

namespace SBear.Entities
{
    /// <summary>
    /// 泛型实体基类
    /// </summary>
    /// <typeparam name="TPrimaryKey">主键类型</typeparam>
    public abstract class BaseEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }
    /// <summary>
    /// 定义默认主键类型为Guid的实体基类
    /// </summary>
    public abstract class BaseEntity : BaseEntity<Guid>
    {
        public long IdentityId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
