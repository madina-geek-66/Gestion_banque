using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_banque.entity;

namespace Gestion_banque.interfaces
{
    internal interface ICrud<T>
    {
        void create();
        void read(T t);
        
        void update(T t);
        void delete(T t);
    }
}
