using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLayer.DAL
{
    public class MapperConfig
    {
        public static IMapper ConfigureDisplayMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentModel>()
                    .ForMember(dest => dest.SemesterId, opt => opt.MapFrom(src => (int)src.SemesterId));

                cfg.CreateMap<Teacher, TeacherModel>()
                    .ForMember(dest => dest.SemesterId, opt => opt.MapFrom(src => (int)src.SemesterId));

                cfg.CreateMap<Address, AddressModel>()
                    .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => (int)src.StudentId));
            });

            var mapper = config.CreateMapper();
            return mapper;
        }
        public static IMapper ConfigureInsertMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentModel, Student>()
                    .ForMember(dest => dest.StudentId, opt => opt.Ignore());

                cfg.CreateMap<TeacherModel, Teacher>()
                    .ForMember(dest => dest.TeacherId, opt => opt.Ignore());

                cfg.CreateMap<AddressModel, Address>();
            });

            var mapper = config.CreateMapper();
            return mapper;
        }
        public static IMapper ConfigureUpdateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentModel, Student>()
                    .ForMember(dest => dest.SemesterId, opt => opt.MapFrom(src => src.SemesterId));

                cfg.CreateMap<TeacherModel, Teacher>()
                    .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId));

                cfg.CreateMap<AddressModel, Address>();
            });

            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
