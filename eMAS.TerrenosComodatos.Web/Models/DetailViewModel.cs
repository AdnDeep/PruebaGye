using System;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Web.Models
{
    public class ColumnViewModel 
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool visible { get; set; }
    }
    public class DetailViewModel
    {
        public int ColsCount { get { return lsColumns.Count; } }
        public List<ColumnViewModel> lsColumns { get; set; }
        public DetailViewModel()
        {
            lsColumns = new List<ColumnViewModel>();
        }
        public void addColumnInfo(ColumnViewModel column) 
        {
            lsColumns.Add(column);
        }
    }
}
