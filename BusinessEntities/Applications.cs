using SqlSugar;
using System;

namespace BusinessEntities
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("Applications")]
    public partial class Applications
    {
        public Applications()
        {


        }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string ApplicationName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true)]
        public Guid ApplicationId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Description { get; set; }

    }
}
