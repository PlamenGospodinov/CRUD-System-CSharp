namespace CRUD.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Detail
    {
        public int ID { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public DateTime DOB { get; set; }
    }
}
