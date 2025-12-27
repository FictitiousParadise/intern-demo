using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace TheOneCatBa.Services
{
    public class Filter
    {
        public string keySearch { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
    public abstract class BaseService <Entity,Key> where Entity : class
    {
        public abstract List<Entity> GetAll(Filter filter);
        public abstract void Delete(Key key);
        public abstract Entity Insert(Entity entity);
        public abstract Entity GetById(Key key);
        public abstract void Update(Entity entity);
    }
}
