using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;

namespace Core.DataAccess
{
    // Generic Repository Design Pattern
    // Generic Constraint - Kısıtlama
    // class: - referans tip olabilir demek
    // IEntity - IEntity imzalı classları ve IEntity i kabul et sadece dedik
    // new() - newlenebilir olmalı - bu sayede IEntity yi alabilme ihtimalini kaldırdık
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //baktık bu kodlar her varlık dal ın da tekrar ediyor, o yüzden bir generic interface e attık
        //istenilen filtreye göre arama yapmak için expression kullanıyoruz
        // filter=null - isterse filtrelesin demek
        List<T> GetAll(Expression<Func<T,bool>> filter=null);

        // filter - kesin bir filtre olsun
        T Get(Expression<Func<T,bool>> filter);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
