using System;
using System.Buffers.Text;

namespace DataAccessLayer.Models
{
    public class Item
    {
        public Item()
        {
                
        }

        public string ItemName { get; set; }
        public bool needFix { get; set; }
        public string borrowedTo { get; set; }
    }
}