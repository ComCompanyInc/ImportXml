using BackendApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Repositories.ExtensionBase
{
    public interface ISearchData<T>
    {
        /// <summary>
        /// Метод взятия обьектов по уникальным полям сущности
        /// </summary>
        /// <param name="entityData">Обьект для поиска из таблицы по его полям</param>
        /// <returns>Найденый обьект по пттрибутам в переданном обьекте</returns>
        public Task<T> GetEnitityByAttributes(
            T entityData
        );

        /// <summary>
        /// Метод обновления полей существующей сущности
        /// </summary>
        /// <param name="existingEntity">Существующая сущность в которой требуется обновить атрибуты</param>
        /// <param name="entityData">Обьект с атрибутами для обновления</param>
        /// <returns>Обьект с обновленными данными</returns>
        public Task<T> UpdateObject(
            T existingEntity, T entityData
        );    
    }
}
