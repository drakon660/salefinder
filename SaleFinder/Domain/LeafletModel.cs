using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SaleFinder.Domain
{
    public class LeafletModel
    {
        public int Id { get; set; }
        public int Week { get; set; }
        public string DownloadUrl { get; set; }
        public string FileName { get; set; }
        public string Hash { get; set; }
        public string GroupName { get; set; }
        public DateTime SaleTime { get; set; }
        public LeafletModelStatus Status { get; set; }
        public virtual List<LeafletPageModel> Pages { get; set; }
    }

    public class LeafletPageModel
    {
        public int Id { get; set; }
      
        public int PageNumber { get; set; }
        public string Text { get; set; }

        //public int LeafletModelId { get; set; }
        public virtual LeafletModel LeafletModel { get; set; }
    }

    public enum LeafletModelStatus
    {
        Ready,
        Downloaded,
        Processed,
    }
}
