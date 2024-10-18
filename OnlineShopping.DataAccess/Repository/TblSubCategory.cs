using System;
using System.Collections.Generic;

namespace OnlineShopping.DataAccess.Repository;

public partial class TblSubCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int CatId { get; set; }

    public virtual TblCategory Cat { get; set; } = null!;

    public virtual ICollection<TblItem> TblItems { get; set; } = new List<TblItem>();

    public virtual ICollection<TblProduct> TblProducts { get; set; } = new List<TblProduct>();
}
