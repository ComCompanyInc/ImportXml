using BackendApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Repositories.ExtensionBase
{
    public interface ISearchData<T>
    {
        public Task<T> GetEnitityByAttributes(
            T entityData
        );
    }
}
