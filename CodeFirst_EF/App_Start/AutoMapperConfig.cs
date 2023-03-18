using AutoMapper;
using CodeFirst_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst_EF.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper mapper;

        public static void Configuration()
        {
            MapperConfiguration configuration = new MapperConfiguration(t => 
            {
                t.CreateMap<Student, StudentViewModel>();
                t.CreateMap<StudentViewModel,Student>();
                t.CreateMap<StudentCreateViewModel, Student>();
            });
            mapper = configuration.CreateMapper();
        }
    }
}