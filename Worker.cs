//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Okhta_Park
{
    using System;
    using System.Collections.Generic;
    
    public partial class Worker
    {
        public int Id { get; set; }
        public Nullable<int> WorkerTypeId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> LastEnter { get; set; }
        public Nullable<int> EnterTypeId { get; set; }
    
        public virtual EnterType EnterType { get; set; }
        public virtual WorkerType WorkerType { get; set; }
    }
}
