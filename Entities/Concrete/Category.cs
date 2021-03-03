using Core.Entities;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Category:IEntity
    {
        //Çıplak Class Kalmasın : classın bağlı olduğu bir inheritance
        //yok ise ilerde sorun yaşama ihitmalin yüksektir.
        //classları işaretleme eğilimi duyarız, gruplama eğilimi : inheritance
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
