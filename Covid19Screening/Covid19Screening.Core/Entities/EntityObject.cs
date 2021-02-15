using Covid19Screening.Core.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Covid19Screening.Core.Entities
{

    public class EntityObject : IEntityObject
    {
        #region IEnityObject Members

        [Key]
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp
        {
            get;
            set;
        }

        #endregion
    }
}
