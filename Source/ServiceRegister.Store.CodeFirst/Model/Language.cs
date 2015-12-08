using System;

namespace ServiceRegister.Store.CodeFirst.Model
{
    public class Language
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}