using Course_Display.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DynamicModelDemo
{
    public class CacheKeyFactory : IModelCacheKeyFactory
    {
        public object Create(DbContext context)
            => context is CoursedbContext CdbContext
                ? (context.GetType(), CdbContext.CourseList)
                : (object)context.GetType();
    }
}