using vm = AcademicXXI.ViewModel.ViewModel;
using domain = AcademicXXI.Domain;
using AutoMapper;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Threading.Tasks;

namespace AcademicXXI.ViewModel.MapExtensionMethod
{
    public static class GenericExtensionMethod
    {
        /// <summary>
        /// Method that allow to convert a entity to vm and vice versa
        /// </summary>
        /// <typeparam name="Object"></typeparam>
        /// <param name="Ojbect"></param>
        /// <returns>TEntityDestination</returns>
        public static TEntityDestination GenericConvert<TEntityDestination>(this vm.BaseDomain obj) where TEntityDestination : class
        {
            return Mapper.Map<TEntityDestination>(obj);
        }
        public static TEntityDestination GenericConvert<TEntityDestination>(this domain.BaseDomain obj) where TEntityDestination : class
        {
            return Mapper.Map<TEntityDestination>(obj);
        }

        /// <summary>
        /// Method that allow to convert List Entity to List VM and vice versa
        /// </summary>
        /// <typeparam name="List"></typeparam>
        /// <param name="list"></param>
        /// <returns>List<TEntityDestination></returns>
        public static List<TEntityDestination> GenericConvertList<TEntityDestination>(this IEnumerable list) where TEntityDestination : class
        {
            return Mapper.Map<List<TEntityDestination>>(list);
        }

        public static List<TEntityDestination> GenericConvertListAsync<TEntityDestination>(this Task<IEnumerable> list) where TEntityDestination : class
        {
            return Mapper.Map<List<TEntityDestination>>(list);
        }
    }
}
